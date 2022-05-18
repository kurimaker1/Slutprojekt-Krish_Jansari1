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
    public partial class Form1 : Form
    {
        //Author: Krish Jansari
        public Form1()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            this.Hide();
            game gl = new game();
            gl.playername = pname.Text;
            gl.ShowDialog();
            this.Close();
        }
    }
}
