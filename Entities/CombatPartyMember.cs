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
        private int health;
        private int attackPower;
        private Image img;
        private List<Skill> skills = new List<Skill>();

        public CombatPartyMember(int health, int attackPower, Image img)
        {
            this.Health = health;
            this.AttackPower = attackPower;
            this.Img = img;

            Skill s = new Skill();
            s.damagePerTurn = 2;
            s.initialDamage = 3;
            s.duration = 1;
            s.name = "Bleed";
            Skills.Add(s);
        }

        public int Health
        {
            get
            {
                return health;
            }

            set
            {
                health = value;
            }
        }

        public int AttackPower
        {
            get
            {
                return attackPower;
            }

            set
            {
                attackPower = value;
            }
        }

        public Image Img
        {
            get
            {
                return img;
            }

            set
            {
                img = value;
            }
        }

        public List<Skill> Skills
        {
            get
            {
                return skills;
            }

            set
            {
                skills = value;
            }
        }
    }
}
