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

        public string name;

        public string playername
        {
            get { return name; }
            set { name = value;  }
        }

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
            if (e.KeyCode == Keys.Right && platform.Left + platform.Width < 796)
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
                höger = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                boll.Left += bx;
                boll.Top += by;

                label1.Text = "Score: " + score + "   Platformfart: " + v + "   Bollfart: " + bx + " " + by;

                if (vänster)
                {
                    platform.Left -= v; //för att gå vänster
                }
                if (höger)
                {
                    platform.Left += v; //för att gå höger
                }
                if (platform.Left < 1)
                {
                    vänster = false; //stoppar platformen från att lämna skärmen på vänster sida
                }
                else if (platform.Left + platform.Width > 796)
                {
                    höger = false; //stoppar på höger sida
                }

                // delen nedan har jag DELVIS tagit från ett pong-spel. Läs mer i logg.txt 2022-05-09

                if (boll.Left + boll.Width > ClientSize.Width || boll.Left < 0)
                {
                    bx = -bx; //gör att bollen studsar på väggar (sidan)
                }
                if (boll.Top < 0 || boll.Bounds.IntersectsWith(platform.Bounds))
                {
                    by = -by; //gör att bollen studsar på tak
                }
                if (boll.Top + boll.Height > ClientSize.Height)
                {
                    gameLose();
                }
                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && x.Tag == "box")
                    {
                        if (boll.Bounds.IntersectsWith(x.Bounds))
                        {
                            this.Controls.Remove(x);
                            by = -by;
                            score++;
                            if (v < 24)
                            {
                                v++;
                                bx++;
                                by++;
                                bx++;
                            }
                        }
                    }
                }
            if (score > 47)
            {
                gameWin();
            }


        }

        private void gameLose()
        {
            timer1.Stop();
            this.Hide();
            lose ls = new lose();
            ls.ShowDialog();
            this.Close();
        }

        private void gameWin()
        {
            timer1.Stop();
            this.Hide();
            win wn = new win();
            wn.ShowDialog();
            this.Close();
        }

        private void game_Load(object sender, EventArgs e)
        {
            label2.Text = name;
        }
    }
}
