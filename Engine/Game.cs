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
        // We'll keep WorldMap objects for our areas in this list
        private List<WorldMap> GameAreasList { get; set; }

        private GEngine gEngine;

        public void startGraphics(Graphics g)
        {
            gEngine = new GEngine(g);
            gEngine.Start();
        }

        public void StopGame()
        {
            gEngine.Stop();
        }

        public Game()
        {

        }

        public void HandleKeyPress(KeyEventArgs e)
        {
            gEngine.HandleKeyPress(e);
        }

        //private Form GameForm { get; set; } // The window
        //CombatGUI combatGUI; // A separate window that appears when in combat
        // World Maps
        
        // Enemies
        // WorldMapEnemy enemy;
        // List<WorldMapEnemy> worldMapEnemiesList;
        // Drawing

        //private PictureBox WorldMapCanvas { get; set; } // We'll be drawing the world map sprites here

        // Viewport position coordinates. We'll use these to move the camera around and redraw sprites

        // The size of each tile, visible when we show the Grid. Tiles should be square

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
        //void Draw()
        //{

        //    // Drawing the map and the grid underneath it. The grid is only to be used for debugging purposes
        //    this.WorldMap.DrawMap(gEngine.Device, this.ViewportPosX, this.ViewportPosY);
        //    if (this.WorldMap.GridIsDrawn == true)
        //    {
        //        this.WorldMap.ToggleGrid(gEngine.Device, this.ViewportPosX, this.ViewportPosY);    
        //    }

        //    // Drawing the player
        //    this.PlayerParty.PlayerSprite.Draw(
        //        gEngine.Device, this.playerPos.X +
        //        this.ViewportPosX, this.playerPos.Y +
        //        this.ViewportPosY);

        //    // Drawing enemies
        //    //foreach (WorldMapEnemy m in worldMapEnemiesList)
        //    //{
        //    //    // check if enemy is alive before drawing them
        //    //    if (m.alive)
        //    //    {
        //    //        m.Draw(device, viewportPosX, viewportPosY);    
        //    //    }
        //    //}

        //    this.WorldMapCanvas.Image = gEngine.Img;

        //}
    }
}