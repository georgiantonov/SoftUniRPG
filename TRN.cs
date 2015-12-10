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
        private Game game = new Game();

        public TRN()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = canvas.CreateGraphics();
            game.startGraphics(g);
        }

        private void TRN_Load(object sender, EventArgs e)
        {

        }

        private void TRN_FormClosing(object sender, FormClosingEventArgs e)
        {
            game.StopGame();
        }

        private void TRN_KeyDown(object sender, KeyEventArgs e)
        {
            game.HandleKeyPress(e);
        }
    }
}
