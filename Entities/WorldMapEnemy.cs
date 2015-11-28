using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Windows.Forms;
namespace Game
{
    // Enemies are a type of Sprites which can appear on the map - hence they inherit "WorldMapSprite"
    class WorldMapEnemy : WorldMapSprite
    {
        private bool isStatic;
        private bool alive;
        private CombatPartyMember member;

        public WorldMapEnemy(Point location, Image image, int ID, CombatPartyMember member) : base(location, image, ID)
        {
            this.member = member;
            isStatic = true;
            alive = true;
        }
    }
}
