using Game.GameObjects.Inventory.ItemSlots.ArmorItemSlots;
using Game.GameObjects.Inventory.ItemSlots.WeaponItemSlots;
using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameObjects.Inventory
{
    public class Inventory : IInventory
    {
        private MainHandSlot mainHandSlot;
        private OffHandSlot offHandSlot;
        private ChestArmorSlot chestSlot;
        private HeadArmorSlot headSlot;
        private FeetArmorSlot feetSlot;
        private HandArmorSlot handSlot;

        private Backpack backPack;

        public Inventory()
        {

        }

        public MainHandSlot MainHandSlot
        {
            get
            {
                return this.mainHandSlot;
            }
            set
            {
                this.mainHandSlot = value;
            }
        }

        public OffHandSlot OffHandSlot
        {
            get
            {
                return this.offHandSlot;
            }
            set
            {
                this.offHandSlot = value;
            }
        }

        public ChestArmorSlot ChestSlot
        {
            get
            {
                return this.chestSlot;
            }
            set
            {
                this.chestSlot = value;
            }
        }

        public HeadArmorSlot HeadSlot
        {
            get
            {
                return this.headSlot;
            }
            set
            {
                this.headSlot = value;
            }
        }

        public FeetArmorSlot FeetSlot
        {
            get
            {
                return this.feetSlot;
            }
            set
            {
                this.feetSlot = value;
            }
        }

        public HandArmorSlot HandSlot
        {
            get
            {
                return this.handSlot;
            }
            set
            {
                this.handSlot = value;
            }
        }

        public Backpack BackPack
        {
            get
            {
                return this.backPack;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
