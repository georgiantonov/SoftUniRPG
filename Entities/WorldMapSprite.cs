using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public class WorldMapSprite
    {
        private Point location;
        private Image image;
        private int ID;

        public WorldMapSprite(Point location, Image image, int ID)
        {
            this.location = location;
            this.image = image;
            this.ID = ID;
        }

        // Draw() method
        // Draws an image at specified location
        // The location is a Point object - it has a location.X and location.Y properties
        public void Draw(Graphics device, int x, int y)
        {
            location.X = x;
            location.Y = y;
            device.DrawImage(image, location);
        }

        public void Move(int x, int y)
        {
            location.X = x;
            location.Y = y;
        }
    }
}
