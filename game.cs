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
        int bx2 = 5;
        int by2 = 5;
        int bx3 = 5;
        int by3 = 5;

        public string name;

        public string playername
        {
            get 
            { 
                return name; 
            }
            set 
            { 
                name = value;  
            }
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
            /*
            boll2.Enabled = false;
            boll2.Visible = false;

            boll3.Enabled = false;
            boll3.Visible = false;
            */
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

            if (boll.Left + boll.Width > ClientSize.Width || boll.Left < 0)
            {
                bx = -bx; //gör att bollen studsar på väggar (sidan)
            }
            if (boll.Top < 0 || boll.Bounds.IntersectsWith(platform.Bounds))
            {
                by = -by; //gör att bollen studsar på tak
            }
            if (boll2.Left + boll2.Width > ClientSize.Width || boll2.Left < 0)
            {
                bx2 = -bx2;
            }
            if (boll2.Top < 0 || boll2.Bounds.IntersectsWith(platform.Bounds))
            {
                by2 = -by2;
            }
            if (boll3.Left + boll3.Width > ClientSize.Width || boll3.Left < 0)
            {
                bx3 = -bx3;
            }
            if (boll3.Top < 0 || boll3.Bounds.IntersectsWith(platform.Bounds))
            {
                by3 = -by3;
            }

            if (boll.Top + boll.Height > ClientSize.Height && boll2.Top + boll2.Height > ClientSize.Height && boll3.Top + boll3.Height > ClientSize.Height)
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
                        if (score < 16)
                        {
                            v++;
                        }
                    }
                    if (boll2.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        by2 = -by2;
                        score++;
                        if (score < 16)
                        {
                            v++;
                        }
                    }
                    if (boll3.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        by3 = -by3;
                        score++;
                        if (score < 16)
                        {
                            v++;
                        }
                    }
                }
            }
            if (score > 8)
            {
                boll2.Left += bx2;
                boll2.Top += by2;
                boll2.Enabled = true;
                boll2.Visible = true;
            }
            if (score > 16)
            {
                boll3.Left += bx3;
                boll3.Top += by3;
                boll3.Enabled = true;
                boll3.Visible = true;
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
