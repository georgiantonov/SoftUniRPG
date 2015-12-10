using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Game
{
    class WorldMap
    {
        private Image mapImage;
        private Image gridImage;
        private Point mapImageOrigin;
        private List<Tile> mapTiles;
        private int mapImageWidth; // These two have to be set to the background image's size
        private int mapImageHeight;
        private StreamReader reader;
        private Color pixelColor;
        private Color walkableColor;
        private Color nonWalkableColor = Color.FromArgb(0, 0, 0);
        private Pen pen = new Pen(Color.Green);
        private bool gridIsDrawn;
        private Image gridCalculatedImage;
        private Graphics gridGraphicsDevice;

        public WorldMap(Bitmap mapImage, int mapImageWidth, int mapImageHeight)
        {
            this.MapImage = mapImage;
            this.MapTiles = new List<Tile>();
            this.GridImage = new Bitmap(mapImageWidth, mapImageHeight);
            this.MapImageWidth = mapImageWidth;
            this.MapImageHeight = mapImageHeight;
            this.WalkableColor = Color.FromArgb(255, 255, 255);
            this.NonWalkableColor = Color.FromArgb(0, 0, 0);
            this.Pen = new Pen(Color.Green);
        }

        public Graphics GridGraphicsDevice
        {
            get
            {
                return this.gridGraphicsDevice;
            }

            set
            {
                this.gridGraphicsDevice = value;
            }
        }

        public Image MapImage
        {
            get
            {
                return this.mapImage;
            }

            set
            {
                this.mapImage = value;
            }
        }

        public Image GridCalculatedImage
        {
            get
            {
                return this.gridCalculatedImage;
            }

            set
            {
                this.gridCalculatedImage = value;
            }
        }

        public Image GridImage
        {
            get
            {
                return this.gridImage;
            }

            set
            {
                this.gridImage = value;
            }
        }

        public Point MapImageOrigin
        {
            get
            {
                return this.mapImageOrigin;
            }

            set
            {
                this.mapImageOrigin = value;
            }
        }

        internal List<Tile> MapTiles
        {
            get
            {
                return this.mapTiles;
            }

            set
            {
                this.mapTiles = value;
            }
        }

        public int MapImageWidth
        {
            get
            {
                return this.mapImageWidth;
            }

            set
            {
                this.mapImageWidth = value;
            }
        }

        public int MapImageHeight
        {
            get
            {
                return this.mapImageHeight;
            }

            set
            {
                this.mapImageHeight = value;
            }
        }

        public StreamReader Reader
        {
            get
            {
                return this.reader;
            }

            set
            {
                this.reader = value;
            }
        }

        public Color PixelColor
        {
            get
            {
                return this.pixelColor;
            }

            set
            {
                this.pixelColor = value;
            }
        }

        public Color WalkableColor
        {
            get
            {
                return this.walkableColor;
            }

            set
            {
                this.walkableColor = value;
            }
        }

        public Color NonWalkableColor
        {
            get
            {
                return this.nonWalkableColor;
            }

            set
            {
                this.nonWalkableColor = value;
            }
        }

        public Pen Pen
        {
            get
            {
                return this.pen;
            }

            set
            {
                this.pen = value;
            }
        }

        public bool GridIsDrawn
        {
            get
            {
                return this.gridIsDrawn;
            }

            set
            {
                this.gridIsDrawn = value;
            }
        }

        public struct Tile
        {
            public Point loc;
            public bool walkable;
            public Color color;
        }

        public void LoadMapTiles(string mapName, Graphics device)
        {
            MapTiles.Clear();
            Reader = new StreamReader(@"..\..\Assets\Maps\" + mapName + ".map");
            Bitmap walkableAreas = new Bitmap(@"..\..\Assets\Maps\" + mapName + ".walkable");

            int y = 0;

            while (!Reader.EndOfStream)
            {
                string line = Reader.ReadLine();

                for (int x = 0; x < line.Length; x++)
                {
                    Tile t = new Tile();
                    t.loc = new Point(x * 10, y * 10);
                    PixelColor = walkableAreas.GetPixel(x * 10, y * 10);

                    if (PixelColor == WalkableColor) //if (line[x].ToString() == "1")
                    {
                        t.color = Color.Green;
                        t.walkable = true;
                    }
                    if (PixelColor == NonWalkableColor) //if (line[x].ToString() == "0")
                    {
                        t.color = Color.Cyan;
                        t.walkable = false;
                    }

                    MapTiles.Add(t);
                }

                y++;
            }

            // Once the tilelist is full, preform an initial drawing of the grid
            GridCalculatedImage = new Bitmap(this.MapImageWidth, this.MapImageHeight);
            GridGraphicsDevice = Graphics.FromImage(this.GridCalculatedImage);

            foreach (Tile tile in MapTiles)
            {
                pen.Color = tile.color;
                GridGraphicsDevice.DrawRectangle(pen, 0 + tile.loc.X, 0 + tile.loc.Y, 10, 10);
            }
        }

        public bool GetWalkableAt(Point loc)
        {
            foreach (Tile t in MapTiles)
            {
                if (t.loc == loc)
                {
                    if (t.walkable)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // For now we don't have levels. There is only one map, and we've set the mapImage and mapImageOrigin properties statically
        public void DrawMap(Graphics FrameGraphicsDevice, int x, int y)
        {
            mapImageOrigin.X = x;
            mapImageOrigin.Y = y;
            FrameGraphicsDevice.DrawImage(MapImage, MapImageOrigin);

            if (gridIsDrawn == true)
            {
                FrameGraphicsDevice.DrawImage(gridCalculatedImage, mapImageOrigin);
            }
        }

        // The following three methods show and hide a visible grid of the map tiles, which serves for debugging purposes
        //private void DrawGrid(Graphics device, int x, int y)
        //{
        //    System.Diagnostics.Debug.WriteLine(">> Drawing grid...");
        //    foreach (Tile tile in MapTiles)
        //    {
        //        Pen.Color = tile.color;
        //        device.DrawRectangle(Pen, tile.loc.X + MapImageOrigin.X, tile.loc.Y + MapImageOrigin.Y, 10, 10);
        //    }
        //}

        //private void HideGrid(Graphics device)
        //{
        //    System.Diagnostics.Debug.WriteLine(">> Clearing grid...");
        //    device.Clear(Color.Transparent);
        //}

        //public void ToggleGrid(Graphics device, int viewportPosX, int viewportPosY)
        //{
        //    System.Diagnostics.Debug.WriteLine(">> Grid toggle method called, gridIsDrawn: " + GridIsDrawn);
        //    if (GridIsDrawn == true)
        //    {
        //        this.DrawGrid(device, viewportPosX, viewportPosY);
        //        device.DrawImage(GridImage, MapImageOrigin);
        //    }
        //    else
        //    {
        //        this.HideGrid(device);
        //        device.DrawImage(MapImage, MapImageOrigin);
        //    }
        //}
    }
}
