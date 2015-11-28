using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameObjects.Inventory.ItemSlots
{
    public class ArmorSlot : ItemSlot
    {
        public ArmorSlot()
            : base()
        {
        }

        public override void EquipItem(IItem itemToBeEquipped)
        {
            throw new NotImplementedException();
        }

        public override void UnEquipItem(IItem itemToBeRemoved)
        {
            throw new NotImplementedException();
        }
    }
}
