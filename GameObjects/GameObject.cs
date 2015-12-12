using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameObjects
{
    //GameObject - base(parent) class for all objects that the player interacts with (NPCs, enemy characters, items).
    public abstract class GameObject
    {
        private Point location;
        private Image image;
        private int id;
        private const int CANVAS_WIDTH = 1280; //For validating the location property.
        private const int CANVAS_HEIGHT = 720; //Probably those two constants should be in a seperate public static class.
        public GameObject(Point location, Image image, int id)
        {
            this.Location = location;
            this.GameObjectImage = image;
            this.ID = ID;
        }
        // Draw() method.
        // Draws an image at specified location.
        // The location is a Point object - it has a location.X and location.Y properties.
        public void Draw(Graphics device, int x, int y)
        {
            this.Location = new Point(x, y);
            device.DrawImage(image, location);
        }
        public Point Location
        {
            get
            {
                return this.location;
            }
            set //Validating that location is within map boundaries.
            {
                if (value.X < CANVAS_WIDTH || value.Y < CANVAS_HEIGHT)
                {
                    throw new ArgumentOutOfRangeException("Location", "Specified coordinates are outside map.");
                }
                this.location = value;
            }
        }
        public Image GameObjectImage { get; set; }
        public int ID { get; set; }
    }
}
