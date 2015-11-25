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
        public WorldMapSprite playerSprite;
        public CombatPartyMember member1;

        public PlayerParty(Point location, Image image, int ID)
        {
            this.playerSprite = new WorldMapSprite(location, image, ID);
        }
    }
}
