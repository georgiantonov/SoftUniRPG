using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Game
{
    public class ActiveSkill
    {
        public Skill skill;
        public CombatPartyMember target;
        public int remainingTurns;
    }
}
