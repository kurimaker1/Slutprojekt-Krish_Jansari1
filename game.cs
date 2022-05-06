using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slutprojekt_Krish_Jansari1
{
    public partial class game : Form
    {
        bool höger;
        bool vänster;
        int v = 10;
        int score = 0;
        int bx = 5;
        int by = 5;

        private Random rnd = new Random();
        public game()
        {
            InitializeComponent();
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && platform.Left > 0)
            {
                vänster = true;
            }
            if (e.KeyCode == Keys.Right && platform.Right + platform.Width < 796)
            {
                höger = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                vänster = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                vänster = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }
    }
}
