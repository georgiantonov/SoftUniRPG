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
    class Game
    {
        Form gameForm; // The window
        //CombatGUI combatGUI; // A separate window that appears when in combat
        
        // World Maps
        WorldMap worldMap;
        // We'll keep WorldMap objects for our areas in this list
        List<WorldMap> gameAreasList;
              
        PlayerParty playerParty; // The player object
        Point playerPos = new Point(800, 200);

        // Enemies
        // WorldMapEnemy enemy;
        // List<WorldMapEnemy> worldMapEnemiesList;
        
        // Drawing
        PictureBox worldMapCanvas; // We'll be drawing the world map sprites here
        Graphics device;
        Image img;
        
        // Viewport position coordinates. We'll use these to move the camera around and redraw sprites
        int viewportPosX = 0;
        int viewportPosY = 0;

        // The size of each tile, visible when we show the Grid. Tiles should be square
        int tileSquareSize = 10;

        bool inCombat = false;

        public Game(Form form)
        {
            // Game Window ('Form') dimensions
            gameForm = form;

            // The Drawing device receives the image
            img = new Bitmap(gameForm.Width, gameForm.Height);
            device = Graphics.FromImage(img);

            worldMap = new WorldMap(gameForm, new Bitmap(@"..\..\Assets\Maps\a001.png"), 1380, 820);
            worldMap.LoadMapTiles("a001", device);
            
            //combatGUI = new CombatGUI();
            //combatGUI.Visible = true;

            inCombat = false;

            // The player being instantiated on the screen
            Bitmap bmp = new Bitmap(@"..\..\Assets\Sprites\Entities\Player\PlayerSprite.png");
            playerParty = new PlayerParty(playerPos, bmp, 1); // Change coordinates here to actual starting coordinates
            
            // World Map Sprite (Background)
            worldMapCanvas = new PictureBox();
            worldMapCanvas.MouseClick += new MouseEventHandler(this.Canvas_MouseClick);
            worldMapCanvas.Width = gameForm.Width;
            worldMapCanvas.Height = gameForm.Height;
            worldMapCanvas.BackColor = Color.Transparent;
            worldMapCanvas.Parent = gameForm;

            //worldMapEnemiesList = new List<WorldMapEnemy>();
            //bmp = new Bitmap("PlayerSprite.png");
            //enemy = new WorldMapEnemy(new Point(800, 200), bmp, 0);

            // Draw stuff on the screen - the Area Background Image, the Player, NPCs
            Draw();
        }

        // We listen for mouse clicks on the Canvas (the area covered by the map's image)
        private void Canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                System.Diagnostics.Debug.WriteLine(">> Right-Clicked coordinates:\n>> X: {0} Y: {1}", e.X, e.Y);
                playerPos.X = e.X;
                playerPos.Y = e.Y;
                Draw();
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
            if (!inCombat)
            {
                // Panning the camera in 4 directions
                if (e.KeyCode == Keys.Left)     { viewportPosX += tileSquareSize; }
                if (e.KeyCode == Keys.Right)    { viewportPosX -= tileSquareSize; }
                if (e.KeyCode == Keys.Up)       { viewportPosY += tileSquareSize; }
                if (e.KeyCode == Keys.Down)     { viewportPosY -= tileSquareSize; }

                // Toggling the grid
                if (e.KeyCode == Keys.G)
                {
                    if (worldMap.gridIsDrawn == true)
                    {
                        worldMap.gridIsDrawn = false;
                    }
                    else
                    {
                        worldMap.gridIsDrawn = true;
                    }
                }    

                // Disable moving the camera or the player to the left of 0 (X) and above 0 (Y)
                if (viewportPosX > 0)   { viewportPosX = 0; }
                if (viewportPosY > 0)   { viewportPosY = 0; }
                // Disable moving the camera or the player off the right edge of the map and off the bottom of the map
                if (viewportPosX < -(worldMap.mapImageWidth - gameForm.Width)) { viewportPosX = -(worldMap.mapImageWidth - gameForm.Width); }
                if (viewportPosY < -(worldMap.mapImageHeight - gameForm.Height)) { viewportPosY = -(worldMap.mapImageHeight - gameForm.Height); }

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

            Draw();

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
            worldMap.DrawMap(device, viewportPosX, viewportPosY);
            if (worldMap.gridIsDrawn == true)
            {
                worldMap.ToggleGrid(device, viewportPosX, viewportPosY);    
            }

            // Drawing the player
            playerParty.playerSprite.Draw(device, playerPos.X + viewportPosX, playerPos.Y + viewportPosY);

            // Drawing enemies
            //foreach (WorldMapEnemy m in worldMapEnemiesList)
            //{
            //    // check if enemy is alive before drawing them
            //    if (m.alive)
            //    {
            //        m.Draw(device, viewportPosX, viewportPosY);    
            //    }
            //}

            worldMapCanvas.Image = img;

        }
    }
}