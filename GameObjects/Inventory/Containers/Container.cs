using Game.GameObjects.Items;
using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameObjects.Inventory.Containers
{
    public abstract class Container : IContainer
    {
        private int numberOfSlots;
        protected List<IItem> items;

        protected Container()
        {
            this.items = new List<IItem>();
        }

        public int NumberOfSlots
        {
            get
            {
                return this.numberOfSlots;
            }
            set
            {
                this.numberOfSlots = value;
            }
        }

        public IEnumerable<IItem> Items
        {
            get
            {
                return this.items;
            }
        }

        public abstract void AddItem(IItem itemToBeAdded);

        public abstract void RemoveItem(IItem itemToBeRemoved);
    }
}
