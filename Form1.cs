using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class TRN : Form
    {
        Game game;

        public TRN()
        {
            InitializeComponent();
            game = new Game(this);
        }

        private void TRN_KeyDown(object sender, KeyEventArgs e)
        {
            game.HandleKeyPress(e);    
        }

    }
}
