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
    public partial class lose : Form
    {
        public lose()
        {
            InitializeComponent();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            this.Hide();
            game gl = new game();
            gl.ShowDialog();
            this.Close();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
