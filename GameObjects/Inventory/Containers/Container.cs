using Game.GameObjects.Inventory.ItemSlots;
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
        protected List<CommonSlot> slots;

        protected Container()
        {
            this.slots = new List<CommonSlot>();
        }

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

        public IEnumerable<CommonSlot> Slots
        {
            get
            {
                return this.slots;
            }
        }

        public abstract void AddItem(IItem itemToBeAdded);

        public abstract void RemoveItem(IItem itemToBeRemoved);
    }
}
