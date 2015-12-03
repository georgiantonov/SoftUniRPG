using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;

using System.Windows.Forms;
using System.IO;

namespace Game
{
    class GEngine
    {
        private Point playerPos;
        private Thread renderThread;

        private const int CANVAS_WIDTH = 1280;
        private const int CANVAS_HEIGHT = 720;
        private const int TILE_SQUARE_SIZE = 10;

        public WorldMap WorldMap { get; set; }

        private int ViewportPosX { get; set; }
        private int ViewportPosY { get; set; }

        private Bitmap FinishedFrame { get; set; }

        private bool isRunning;
        private bool InCombat;

        public Graphics Device { get; set; }
        private Graphics FrameGraphicsDevice { get; set; }

        private PlayerParty PlayerParty { get; set; } // The player object

        public GEngine(Graphics g)
        {
            this.Device = g;
            this.ViewportPosX = 0;
            this.ViewportPosY = 0;
            this.FinishedFrame = new Bitmap(1380, 820);
            this.playerPos = new Point(800, 200);

            // The Drawing device receives the image
            this.FrameGraphicsDevice = Graphics.FromImage(this.FinishedFrame);

            this.PlayerParty = new PlayerParty(
                this.playerPos,
                new Bitmap(@"..\..\Assets\Sprites\Entities\Player\PlayerSprite.png"),
                1); // Change coordinates here to actual starting coordinates
        }

        public void Start()
        {
            renderThread = new Thread(new ThreadStart(Run));
            isRunning = true;   
            renderThread.Start();
        }

        public void Stop()
        {
            try
            {
                this.isRunning = false;
                renderThread.Abort();
            }
            catch (ThreadInterruptedException)
            {
                throw;
            }
        }

        private void Init()
        {
            this.WorldMap = new WorldMap(new Bitmap(@"..\..\Assets\Maps\a001.png"), 1380, 820);
            this.WorldMap.LoadMapTiles("a001", Device);
        }

        private void Update()
        {

        }

        // We listen for mouse clicks on the Canvas (the area covered by the map's image)
        private void Canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                System.Diagnostics.Debug.WriteLine(">> Right-Clicked coordinates:\n>> X: {0} Y: {1}", e.X, e.Y);
                this.playerPos.X = e.X;
                this.playerPos.Y = e.Y;
                //this.Draw();
            }
        }

        // Event handling -- stuff that happens on mouse clicks, on keys pressed or released, etc.
        public void HandleKeyPress(KeyEventArgs e)
        {
            if (!InCombat)
            {
                // Panning the camera in 4 directions
                if (e.KeyCode == Keys.Left) { this.ViewportPosX += TILE_SQUARE_SIZE; }
                if (e.KeyCode == Keys.Right) { this.ViewportPosX -= TILE_SQUARE_SIZE; }
                if (e.KeyCode == Keys.Up) { this.ViewportPosY += TILE_SQUARE_SIZE; }
                if (e.KeyCode == Keys.Down) { this.ViewportPosY -= TILE_SQUARE_SIZE; }

                // Toggling the grid
                if (e.KeyCode == Keys.G)
                {
                    if (this.WorldMap.GridIsDrawn == true)
                    {
                        this.WorldMap.GridIsDrawn = false;
                    }
                    else
                    {
                        this.WorldMap.GridIsDrawn = true;
                    }
                }

                // Disable moving the camera or the player to the left of 0 (X) and above 0 (Y)
                if (this.ViewportPosX > 0) { this.ViewportPosX = 0; }
                if (this.ViewportPosY > 0) { this.ViewportPosY = 0; }
                // Disable moving the camera or the player off the right edge of the map and off the bottom of the map
                if (this.ViewportPosX < -(this.WorldMap.MapImageWidth - CANVAS_WIDTH))
                {
                    this.ViewportPosX = -(this.WorldMap.MapImageWidth - CANVAS_WIDTH);
                }
                if (this.ViewportPosY < -(this.WorldMap.MapImageHeight - CANVAS_HEIGHT))
                {
                    this.ViewportPosY = -(this.WorldMap.MapImageHeight - CANVAS_HEIGHT);
                }
            }
        }

        private void Draw()
        {
            WorldMap.DrawMap(this.FrameGraphicsDevice, this.ViewportPosX, this.ViewportPosY);

            Device.DrawImage(this.FinishedFrame, this.ViewportPosX, this.ViewportPosY);
        }

        private void Run()
        {
            this.Init();

            while (isRunning)
            {
                this.Update();
                this.Draw();
            }

            this.Stop();
        }
    }
}
