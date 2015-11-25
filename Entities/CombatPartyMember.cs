using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public class CombatPartyMember
    {
        public int health;
        public int attackPower;
        public Image img;

        public List<Skill> skills = new List<Skill>();

        public CombatPartyMember(int health, int attackPower, Image img)
        {
            this.health = health;
            this.attackPower = attackPower;
            this.img = img;

            Skill s = new Skill();
            s.damagePerTurn = 2;
            s.initialDamage = 3;
            s.duration = 1;
            s.name = "Bleed";
            skills.Add(s);
        }
    }
}
