using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Windows.Forms;
using Game.GameObjects;

namespace Game
{
    //A base(parent) class for all objects that represent living characters/creatures.
    public class WorldMapSprite : GameObject
    {
        public WorldMapSprite(Point location, Image image, int id)
            : base(location, image, id)
        {
        }
        public void Move(int x, int y)
        {
            this.Location = new Point(x, y);
        }
    }
}
