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

        List<int> scores = new List<int>();
        List<string> players = new List<string>();
        Dictionary<string, int> myDict = new Dictionary<string, int>();

        public int score;

        public int playerscore
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }

        public Form1()
        {

            InitializeComponent();

        }

        private void start_Click(object sender, EventArgs e)
        {
            //this.Hide();
            game gl = new game();
            gl.playername = pname.Text;
            gl.ShowDialog();
            label3.Text = gl.score.ToString();
            //this.Close();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            myDict.Add(pname.Text, int.Parse(label3.Text));
            pname.Clear();
            textBox1.Text = displayPlayers(myDict);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            myDict.Add("Tfue", 48);
            myDict.Add("Faker", 36);
            myDict.Add("LeBron O'Neill", 47);
            myDict.Add("Shaquille James", 46);
            textBox1.Text = displayPlayers(myDict);

        }

        public string displayPlayers(Dictionary<string, int> myDict)
        {
            return string.Join(Environment.NewLine, myDict);
        }


    }
}
