using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Touch
{
    public partial class Form1 : Form
    {
        Random rn;
        blol lol;
        Button b1;

        public Form1()
        {
            InitializeComponent();
            rn = new Random();
            init();
        }

        private void init()
        {
            lol = new blol();
            b1 = new Button();

            #region lol
            lol.MouseMove += delegate(object sender, MouseEventArgs e)
            {
                if (lol.ham==0)
                    lol.Location = new Point(rn.Next(10, Width - 100), rn.Next(10, Height - 150));
                else if(lol.ham==1)
                    lol.Text = "o__O";
            };
            lol.MouseLeave += delegate(object sender, EventArgs e)
            {
                if (lol.ham==1)
                    lol.Text = "0__0";
            };
            lol.Click += delegate(object sender, EventArgs e)
            {
                if (lol.ham == 1)
                {
                    b1.Width = 180;
                    b1.Height = 70;
                    b1.Font = new Font("Arial", 15, FontStyle.Bold);
                    b1.Text = "NOW HAMMER TIME !!";
                    b1.ForeColor = Color.Red;
                    b1.BackColor = Color.Black;
                    b1.Location = new Point(10, Height - 110);

                    lol.cHam();
                    lol.ForeColor = Color.Yellow;
                    lol.Font = new Font("Arial", 10, FontStyle.Bold);
                    lol.Text = "OO00ooooooOOOOOOOO !!!!";
                }
                else
                {
                    // LOL!
                }
            };
            Controls.Add(lol);
            #endregion

            #region b1
            b1.Location = new Point(10, Height - 60);
            b1.Width = 70;
            b1.Height = 30;
            b1.BackColor = Color.Gray;
            b1.Text = "STOP !";
            b1.Font = new Font("Arial", 11, FontStyle.Bold);

            b1.Click += delegate(object sender, EventArgs e)
            {
                if (lol.ham == 0)
                {
                    lol.cHam();
                    lol.Text = "0__0";
                    lol.ForeColor = Color.White;
                    lol.Font = new Font("Arial", 20);
                }
            };
            b1.MouseMove += delegate(object sender, MouseEventArgs e)
            {
                if (lol.ham > 1)
                    b1.Text = "L O L !";
            };
            b1.MouseLeave += delegate(object sender, EventArgs e)
            {
                if (lol.ham > 1)
                    b1.Text = "NOW HAMMER TIME !!";
            };
            Controls.Add(b1);
            #endregion

            timer1.Interval = 100;
            timer1.Enabled = false;
            timer1.Tick += new EventHandler(tralol);
            timer1.Start();
        }

        private void tralol(object sender, EventArgs e)
        {
            if (lol.ham > 1)
            {
                lol.Location = new Point(rn.Next(10, Width - 100), rn.Next(10, Height - 150));
                lol.cHam();
                if (b1.ForeColor == Color.Red)
                    b1.ForeColor = Color.Blue;
                else
                    b1.ForeColor = Color.Red;
                if (lol.ham > 100)
                {
                    lol.Width = 90;
                    lol.Height = 90;
                    lol.BackColor = Color.Black;
                    lol.ForeColor = Color.Red;
                    lol.Text = "CAN'T TOUCH THIS !!";
                    lol.Font = new Font("Arial", 11, FontStyle.Bold);
                    lol.Location = new Point(10, 10);
                    lol.ham = 0;

                    b1.Location = new Point(10, Height - 60);
                    b1.Width = 70;
                    b1.Height = 30;
                    b1.Text = "STOP !";
                    b1.ForeColor = Color.Black;
                    b1.BackColor = Color.Gray;
                    b1.Font = new Font("Arial", 11, FontStyle.Bold);
                }
            }
        }
    }

    public class blol : Button
    {
        private int p_ham;
        public int ham
        {
            get
            {
                return p_ham;
            }
            set
            {
                p_ham = value;
            }
        }

        public blol()
        {
            Width = 90;
            Height = 90;
            BackColor = Color.Black;
            ForeColor = Color.Red;
            Text = "CAN'T TOUCH THIS !!";
            Font = new Font("Arial", 11, FontStyle.Bold);
            Location = new Point(10, 10);
            p_ham = 0;
        }

        public void cHam()
        {
                p_ham++;
        }
    }
}
