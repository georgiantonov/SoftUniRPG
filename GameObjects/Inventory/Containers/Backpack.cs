using Game.GameObjects.Inventory.Containers;
using Game.GameObjects.Inventory.InventoryExceptions;
using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameObjects.Inventory
{
    public class Backpack : Container
    {
        private List<IItem> items;

        public Backpack()
        {
            this.items = new List<IItem>();
        }

        public IEnumerable<IItem> Items
        {
            get
            {
                return this.items;
            }
        }

        public void AddItem(IItem itemToBeAdded)
        {
            if (this.IsFullBackpack())
            {
                throw new BackpackFullException(InventoryMessages.BackpackFullMessage);
            }

            this.items.Add(itemToBeAdded);
        }

        public void RemoveItem(IItem itemToBeRemoved)
        {
            throw new NotImplementedException();
        }

        private bool IsFullBackpack()
        {
            bool isFull = this.Items.Count() == InventoryValues.BackpackBaseNumberOfSlots;
            return isFull;
        }
    }
}
