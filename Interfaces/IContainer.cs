using Game.GameObjects.Inventory.ItemSlots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Interfaces
{
    public interface IContainer
    {
        int NumberOfSlots { get; }

        IEnumerable<CommonSlot> Slots { get; }

        void AddItem(IItem itemToBeAdded);

        void RemoveItem(IItem itemToBeRemoved);
    }
}
