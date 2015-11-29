using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameObjects.Inventory
{
    public class InventoryManager
    {
        private Inventory inventory;

        public InventoryManager()
        {
            this.inventory = new Inventory();
        }
    }
}
