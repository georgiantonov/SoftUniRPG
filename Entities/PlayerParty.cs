using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Windows.Forms;
namespace Game
{   
    // The player is an instance of a WorldMapSprite. This class will get more complicated later, when we add more functionality to the game - i.e. things the Player can do
    public class PlayerParty
    {    
        // public because we need to access it from outside the class
        private WorldMapSprite playerSprite;
        private CombatPartyMember member1;
        
        public PlayerParty(Point location, Image image, int ID)
        {
            this.PlayerSprite = new WorldMapSprite(location, image, ID);
        }

        public WorldMapSprite PlayerSprite
        {
            get
            {
                return this.playerSprite;
            }

            set
            {
                this.playerSprite = value;
            }
        }

        public CombatPartyMember Member1
        {
            get
            {
                return this.member1;
            }

            set
            {
                this.member1 = value;
            }
        }
    }
}
