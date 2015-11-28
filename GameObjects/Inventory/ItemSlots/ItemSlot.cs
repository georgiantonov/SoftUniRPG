using Game.GameObjects.Items;
using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameObjects.Inventory
{
    public abstract class ItemSlot : IItemSlot
    {
        private IItem item;
        private bool isEmpty;
        private int slotNumber;

        public ItemSlot()
        {
            this.isEmpty = true;
        }

        public IItem Item
        {
            get
            {
                return this.item;
            }
            set
            {
                this.item = value;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return this.isEmpty;
            }
        }

        public int SlotNumber
        {
            get
            {
                return this.slotNumber;
            }
            protected set
            {
                this.slotNumber = value;
            }
        }

        public abstract void EquipItem(IItem itemToBeEquipped);

        public abstract void UnEquipItem(IItem itemToBeRemoved);
    }
}
