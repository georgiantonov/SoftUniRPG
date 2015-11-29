using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.GameObjects.Inventory.ItemSlots;

namespace Game.Interfaces
{
    public interface IItemSlot
    {
        IItem Item { get; protected set; }

        bool IsEmpty { get; protected set; }

        int  SlotNumber { get; protected set; }

        ItemSlotType SlotType { get; protected set; }
    }
}
