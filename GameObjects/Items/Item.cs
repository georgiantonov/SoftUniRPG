using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.GameObjects.Items;
using Game.Interfaces;

namespace Game.GameObjects.Items
{
    public abstract class Item : GameObject, IItem
    {
        public Item(Point location, Image image, int id)
            : base(location, image, id)
        {
            this.ItemState = ItemState.Available;
        }
        public ItemState ItemState { get; set; }
    }
}
