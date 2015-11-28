using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Interfaces
{
    public interface IContainer
    {
        int NumberOfSlots { get; set; }

        IEnumerable<IItem> Items { get; }

        bool IsFull { get; }

        void AddItem(IItem itemToBeAdded);

        void RemoveItem(IItem itemToBeRemoved);
    }
}
