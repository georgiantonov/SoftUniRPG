using Game.GameObjects.Inventory.InventoryExceptions;
using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameObjects.Inventory.ItemSlots
{
    public abstract class WeaponSlot : ItemSlot
    {
        private ItemSlotType slotType;

        public WeaponSlot()
            : base()
        {
            this.slotType = ItemSlotType.Weapon;
        }

        public ItemSlotType SlotType
        {
            get
            {
                return this.slotType;
            }
        }

        public override void EquipItem(IItem itemToBeEquipped)
        {
            if (!(itemToBeEquipped is IWeapon))
            {
                throw new WrongSlotException(InventoryMessages.WrongSlotMessage);
            }

            this.IsEmpty = false;

            throw new NotImplementedException();
        }

        public override void UnEquipItem(IItem itemToBeRemoved)
        {
            this.IsEmpty = true;
            throw new NotImplementedException();
        }
    }
}
