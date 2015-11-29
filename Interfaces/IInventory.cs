using Game.GameObjects.Inventory.ItemSlots.ArmorItemSlots;
using Game.GameObjects.Inventory.ItemSlots.WeaponItemSlots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Interfaces
{
    public interface IInventory
    {
        MainHandSlot MainHandSlot { get; set; }
        OffHandSlot OffHandSlot { get; set; }
        ChestArmorSlot ChestSlot { get; set; }
        HeadArmorSlot HeadSlot { get; set; }
        FeetArmorSlot FeetSlot { get; set; }
        HandArmorSlot HandSlot { get; set; }
    }
}
