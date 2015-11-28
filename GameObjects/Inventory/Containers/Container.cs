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
        private List<IItem> items;
        private bool isFull;

        public int NumberOfSlots
        {
            get
            {
                return this.numberOfSlots;
            }
            protected set
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

        public bool IsFull
        {
            get
            {
                return this.isFull;
            }
        }

        public void AddItem(IItem itemToBeAdded)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(IItem itemToBeRemoved)
        {
            throw new NotImplementedException();
        }
    }
}
