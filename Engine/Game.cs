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
    public class Game
    {
        private Point playerPos;

        public Game(Form form)
        {
            this.playerPos = new Point(800, 200);
            this.ViewportPosX = 0;
            this.ViewportPosY = 0;
            this.TileSquareSize = 10;

            // Game Window ('Form') dimensions
            this.GameForm = form;

            // The Drawing device receives the image
            this.Img = new Bitmap(this.GameForm.Width, this.GameForm.Height);
            this.Device = Graphics.FromImage(this.Img);
            this.WorldMap = new WorldMap(
                this.GameForm,
                new Bitmap(@"..\..\Assets\Maps\a001.png"), 1380, 820);
            this.WorldMap.LoadMapTiles("a001", this.Device);
            
            //combatGUI = new CombatGUI();
            //combatGUI.Visible = true;
            this.InCombat = false;

            // The player being instantiated on the screen
            this.PlayerParty = new PlayerParty(
                this.playerPos,
                new Bitmap(@"..\..\Assets\Sprites\Entities\Player\PlayerSprite.png"),
                1); // Change coordinates here to actual starting coordinates
            
            // World Map Sprite (Background)
            this.WorldMapCanvas = new PictureBox();
            this.WorldMapCanvas.MouseClick += new MouseEventHandler(this.Canvas_MouseClick);
            this.WorldMapCanvas.Width = this.GameForm.Width;
            this.WorldMapCanvas.Height = this.GameForm.Height;
            this.WorldMapCanvas.BackColor = Color.Transparent;
            this.WorldMapCanvas.Parent = this.GameForm;

            //worldMapEnemiesList = new List<WorldMapEnemy>();
            //bmp = new Bitmap("PlayerSprite.png");
            //enemy = new WorldMapEnemy(new Point(800, 200), bmp, 0);

            // Draw stuff on the screen - the Area Background Image, the Player, NPCs
            this.Draw();
        }

        private Form GameForm { get; set; } // The window
        //CombatGUI combatGUI; // A separate window that appears when in combat
        // World Maps
        private WorldMap WorldMap { get; set; }

        // We'll keep WorldMap objects for our areas in this list
        private List<WorldMap> GameAreasList { get; set; }

        private PlayerParty PlayerParty { get; set; } // The player object

        // Enemies
        // WorldMapEnemy enemy;
        // List<WorldMapEnemy> worldMapEnemiesList;
        // Drawing

        private PictureBox WorldMapCanvas { get; set; } // We'll be drawing the world map sprites here

        private Graphics Device { get; set; }

        private Image Img { get; set; }

        // Viewport position coordinates. We'll use these to move the camera around and redraw sprites

        private int ViewportPosX { get; set; }

        private int ViewportPosY { get; set; }
        // The size of each tile, visible when we show the Grid. Tiles should be square

        private int TileSquareSize { get; set; }

        private bool InCombat = false;

        // We listen for mouse clicks on the Canvas (the area covered by the map's image)
        private void Canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                System.Diagnostics.Debug.WriteLine(">> Right-Clicked coordinates:\n>> X: {0} Y: {1}", e.X, e.Y);
                this.playerPos.X = e.X;
                this.playerPos.Y = e.Y;
                this.Draw();
            }  
        }

        //This function is now redundant
        //void LoadNewMap(int xMove, int yMove)
        //{
        //    mapX += xMove;
        //    mapY += yMove;
        //    worldMap.LoadMap(mapX + " " + mapY, device);

        //    LoadEnemiesOnMap();
        // }

        // We go through a dat file which corresponds to the current map
        // When we spot a '1' in the file, make an instance of an enemy at these coordinates
        //void LoadEnemiesOnMap()
        //{
        //    worldMapEnemiesList.Clear();

        //    StreamReader reader = new StreamReader(@"MapEntityData\a001.dat");

        //    int y = 0;

        //    while (!reader.EndOfStream)
        //    {
        //        string line = reader.ReadLine();

        //        for (int x = 0; x < line.Length; x++)
        //        {
        //            if (line[x].ToString() == "1")
        //            {
        //                worldMapEnemiesList.Add(new WorldMapEnemy(new Point(x * 10, y * 10), new Bitmap("EnemySprite.png"),
        //                    0, new CombatPartyMember(10, 5, new Bitmap("EnemyCombatSprite.png"))));
        //            }
        //        }
        //        y++;
        //    }
        //}

        // Event handling -- stuff that happens on mouse clicks, on keys pressed or released, etc.
        public void HandleKeyPress(KeyEventArgs e)
        {
            if (!InCombat)
            {
                // Panning the camera in 4 directions
                if (e.KeyCode == Keys.Left)     { this.ViewportPosX += this.TileSquareSize; }
                if (e.KeyCode == Keys.Right)    { this.ViewportPosX -= this.TileSquareSize; }
                if (e.KeyCode == Keys.Up)       { this.ViewportPosY += this.TileSquareSize; }
                if (e.KeyCode == Keys.Down)     { this.ViewportPosY -= this.TileSquareSize; }

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
                if (this.ViewportPosX > 0)   { this.ViewportPosX = 0; }
                if (this.ViewportPosY > 0)   { this.ViewportPosY = 0; }
                // Disable moving the camera or the player off the right edge of the map and off the bottom of the map
                if (this.ViewportPosX < - (this.WorldMap.MapImageWidth - this.GameForm.Width))
                {
                    this.ViewportPosX = -(this.WorldMap.MapImageWidth - this.GameForm.Width);
                }
                if (this.ViewportPosY < - (this.WorldMap.MapImageHeight - this.GameForm.Height))
                {
                    this.ViewportPosY = -(this.WorldMap.MapImageHeight - this.GameForm.Height);
                }

                // Handle player movement with the following
                //Point potentialMove = new Point(p.X + playerParty.playerSprite.location.X, p.Y + playerParty.playerSprite.location.Y);
                //if (worldMap.GetWalkableAt(potentialMove))
                //{
                //    playerParty.playerSprite.Move(p.X, p.Y);
                //}
                //else
                //{
                //    //Load new map if needed/possible
                //    if (potentialMove.X > 10 * 127)
                //    {
                //        //LoadNewMap(1, 0);
                //        playerParty.playerSprite.Move(-1270, 0);
                //    }
                //    if (potentialMove.X < 0)
                //    {
                //        //LoadNewMap(-1, 0);
                //        playerParty.playerSprite.Move(1270, 0);
                //    }
                //    if (potentialMove.Y < 0)
                //    {
                //        //LoadNewMap(0, -1);
                //        playerParty.playerSprite.Move(0, 710);
                //    }
                //    if (potentialMove.Y > 10 * 710)
                //    {
                //        //LoadNewMap(0, 1);
                //        playerParty.playerSprite.Move(0, -710);
                //    }
                //}
            }

            //else
            //{
            //    //Use enemyInCombat variable to remove correct sprite
            //    //If the combat GUI has exited combat, remove our enemy sprite
            //    if (!combatGUI.inCombat)
            //    {
            //        enemyInCombat.alive = false;
            //        KillEnemyInList(enemyInCombat);
            //        inCombat = false;
            //    }
            //}

            this.Draw();

            //DetectCollision();
        }

        //Kill this enemy in the list
        //void KillEnemyInList(WorldMapEnemy m1)
        //{
        //    foreach (WorldMapEnemy m in worldMapEnemiesList)
        //    {
        //        if (m == m1)
        //        {
        //            m.alive = false;
        //        }
        //    }
        //}

        //public void DetectCollision()
        //{
        //    foreach (WorldMapEnemy m in worldMapEnemiesList)
        //    {
        //        //Check if monster is alive before detecting collision
        //        if (m.alive && playerParty.playerSprite.location == m.location)
        //        {
        //            //Create a reference to monster in combat with
        //            enemyInCombat = m;
        //            //combatGUI.StartCombat(playerParty, enemyInCombat.member);
        //            inCombat = true;
        //        }
        //    }
        //}

        // The graphics device draws (shapes or loads image assets) on top of image objects
        void Draw()
        {

            // Drawing the map and the grid underneath it. The grid is only to be used for debugging purposes
            this.WorldMap.DrawMap(this.Device, this.ViewportPosX, this.ViewportPosY);
            if (this.WorldMap.GridIsDrawn == true)
            {
                this.WorldMap.ToggleGrid(this.Device, this.ViewportPosX, this.ViewportPosY);    
            }

            // Drawing the player
            this.PlayerParty.PlayerSprite.Draw(
                this.Device, this.playerPos.X +
                this.ViewportPosX, this.playerPos.Y +
                this.ViewportPosY);

            // Drawing enemies
            //foreach (WorldMapEnemy m in worldMapEnemiesList)
            //{
            //    // check if enemy is alive before drawing them
            //    if (m.alive)
            //    {
            //        m.Draw(device, viewportPosX, viewportPosY);    
            //    }
            //}

            this.WorldMapCanvas.Image = this.Img;

        }
    }
}