using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pac_man
{
    public partial class Form1 : Form
    {
        bool goup, godown, goleft, goright, gameover;
        int score, playerspeed, redghoastspeed, yellowghoastspeed, pinkghoastX, pinkghoastY;
       // string message;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
            resetgame();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void yellowghoast_Click(object sender, EventArgs e)
        {

        }

        private void keysdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                goup = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                godown = true;
            }

            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }
        }

        private void keysdoup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }

            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }

            if (e.KeyCode == Keys.Enter && gameover == true)
            {
                resetgame();
            }
        }

        private void maingametimer(object sender, EventArgs e)
        {
            textscore.Text = "score:" + score;

            if(goleft==true)
            {
                pacman.Left -= playerspeed;
                pacman.Image = Properties.Resources.left;
            }

            if (goright == true)
            {
                pacman.Left += playerspeed;
                pacman.Image = Properties.Resources.right;
            }

            if (godown == true)
            {
                pacman.Top += playerspeed;
                pacman.Image = Properties.Resources.down;
            }

            if (goup == true)
            {
                pacman.Top -= playerspeed;
                pacman.Image = Properties.Resources.Up;
            }

            if(pacman.Left < -10)
            {
                pacman.Left = 680;
            }
            if(pacman.Left > 680)
            {
                pacman.Left = -10;
            }

            if (pacman.Top < -10)
            {
                pacman.Top = 550;
            }
            if (pacman.Top > 550)
            {
                pacman.Top = 0;
            }

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    if((string)x.Tag=="coin"&& x.Visible==true)
                    {
                        if(pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            score += 1;
                            x.Visible = false;
                        }
                    }

                    if((string)x.Tag=="wall")
                    {
                        if(pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameOver("You Lose!");
                        }

                        if(pinkghoast.Bounds.IntersectsWith(x.Bounds))
                        {
                            pinkghoastX = -pinkghoastX;
                        }

                    }

                    if ((string)x.Tag == "ghoast")
                    {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameOver("You Lose!");
                        }

                    }



                }
            }

            redghoast.Left += redghoastspeed;
            if(redghoast.Bounds.IntersectsWith(pictureBox1.Bounds)|| redghoast.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                redghoastspeed = -redghoastspeed;
            }

            yellowghoast.Left -= yellowghoastspeed;
            if (yellowghoast.Bounds.IntersectsWith(pictureBox3.Bounds) || yellowghoast.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                yellowghoastspeed = -yellowghoastspeed;
            }

            pinkghoast.Left -= pinkghoastX;
            pinkghoast.Top -= pinkghoastY;

            if(pinkghoast.Top < 0|| pinkghoast.Top>520)
            {
                pinkghoastY = -pinkghoastY;
            }

            if (pinkghoast.Top < 0 || pinkghoast.Top > 620)
            {
                pinkghoastX = -pinkghoastX;
            }


            if (score==20)
            {
                gameOver("you win");
            }
        }

        private void resetgame()
        {
            textscore.Text = "score:0";
            score = 0;

            redghoastspeed = 5;
            yellowghoastspeed = 5;
            pinkghoastX = 5;
            pinkghoastY = 5;
            playerspeed = 8;

            gameover = false;
            pacman.Left = 70;
            pacman.Top = 230;

            redghoast.Left =353;
            redghoast.Top =40;

            yellowghoast.Left =572;
            yellowghoast.Top =220;

            pinkghoast.Left = 417;
            pinkghoast.Top = 462;

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    x.Visible = true; 
                }
            }

            gametimer.Start();
        }

        private void gameOver(string mssage)
        {
            gameover = true;

            gametimer.Stop();

            textscore.Text = "score:" + score + Environment.NewLine + mssage;
        }

        private void pacman_Click(object sender, EventArgs e)
        {

        }
    }
}
