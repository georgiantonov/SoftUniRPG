using Game.GameObjects.Inventory.ItemSlots;
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
        private ItemSlotType slotType;

        protected ItemSlot()
        {
            this.IsEmpty = true;
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
            set
            {
                this.isEmpty = value;
            }
        }

        public int SlotNumber
        {
            get
            {
                return this.slotNumber;
            }
            set
            {
                this.slotNumber = value;
            }
        }

        public ItemSlotType SlotType
        {
            get
            {
                return this.slotType;
            }
            set
            {
                this.slotType = value;
            }
        }

        public abstract void EquipItem(IItem itemToBeEquipped);

        public abstract void UnEquipItem(IItem itemToBeRemoved);
    }
}
