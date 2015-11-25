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
        public Image mapImage;
        public Image gridImage;
        public Point mapImageOrigin;
        public List<Tile> mapTiles;
        public int mapImageWidth; // These two have to be set to the background image's size
        public int mapImageHeight;
        public StreamReader reader;

        Color pixelColor;
        Color walkableColor = Color.FromArgb(255, 255, 255);
        Color nonWalkableColor = Color.FromArgb(0, 0, 0);
        Pen pen = new Pen(Color.Green);
        
        public bool gridIsDrawn;

        public struct Tile 
        {
            public Point loc;
            public bool walkable;
            public Color color;
        }

        public WorldMap(Form form, Bitmap mapImage, int mapImageWidth, int mapImageHeight)
        {
            this.mapImage = mapImage;
            this.mapTiles = new List<Tile>();
            this.gridImage = new Bitmap(mapImageWidth, mapImageHeight);
            this.mapImageWidth = mapImageWidth;
            this.mapImageHeight = mapImageHeight;
        }

        public void LoadMapTiles(string mapName, Graphics device)
        {
            mapTiles.Clear();
            reader = new StreamReader(@"..\..\Assets\Maps\" + mapName + ".map");
            Bitmap walkableAreas = new Bitmap(@"..\..\Assets\Maps\" + mapName + ".walkable");
            
            int y = 0;

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                for (int x = 0; x < line.Length; x++)
                {
                    Tile t = new Tile();
                    t.loc = new Point(x * 10, y * 10);
                    pixelColor = walkableAreas.GetPixel(x * 10, y * 10);

                    if (pixelColor == walkableColor) //if (line[x].ToString() == "1")
                    {
                        t.color = Color.Green;
                        t.walkable = true;
                    }
                    if (pixelColor == nonWalkableColor) //if (line[x].ToString() == "0")
                    {
                        t.color = Color.Cyan;
                        t.walkable = false;
                    }

                    mapTiles.Add(t);
                }

                y++;
            }
        }

        public bool GetWalkableAt(Point loc)
        {
            foreach (Tile t in mapTiles)
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
        public void DrawMap(Graphics device, int x, int y)
        {
            mapImageOrigin.X = x;
            mapImageOrigin.Y = y;
            device.DrawImage(mapImage, mapImageOrigin);
        }

        // The following three methods show and hide a visible grid of the map tiles, which serves for debugging purposes
        private void DrawGrid(Graphics device, int x, int y)
        {
            System.Diagnostics.Debug.WriteLine(">> Drawing grid...");
            foreach (Tile tile in mapTiles)
            {
                pen.Color = tile.color;
                device.DrawRectangle(pen, tile.loc.X + mapImageOrigin.X, tile.loc.Y + mapImageOrigin.Y, 10, 10);
            }
        }

        private void HideGrid(Graphics device)
        {
            System.Diagnostics.Debug.WriteLine(">> Clearing grid...");
            device.Clear(Color.Transparent);
        }

        public void ToggleGrid(Graphics device, int viewportPosX, int viewportPosY)
        {
            System.Diagnostics.Debug.WriteLine(">> Grid toggle method called, gridIsDrawn: " + gridIsDrawn);
            if (gridIsDrawn == true)
            {
                this.DrawGrid(device, viewportPosX, viewportPosY);
                device.DrawImage(gridImage, mapImageOrigin);
            }
            else
            {
                this.HideGrid(device);
                device.DrawImage(mapImage, mapImageOrigin);
            }
        }
    }
}
