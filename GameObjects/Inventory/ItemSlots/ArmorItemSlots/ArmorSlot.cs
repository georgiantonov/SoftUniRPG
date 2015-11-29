using Game.GameObjects.Inventory.InventoryExceptions;
using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameObjects.Inventory.ItemSlots.ArmorItemSlots
{
    public class ArmorSlot : ItemSlot
    {
        protected ArmorSlot()
            : base()
        {
            this.SlotType = ItemSlotType.Armor;
        }

        public override void EquipItem(IItem itemToBeEquipped)
        {
            if (!(itemToBeEquipped is IArmor))
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
