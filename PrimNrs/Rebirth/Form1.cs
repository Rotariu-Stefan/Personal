using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rebirth
{
    public partial class Form1 : Form
    {
        bool primtest(int it)
        {
            int i = 2;
            double rz;
            it = Math.Abs(it);
            if (it == 0 || it == 1 || it == 2 || it == 3)
                return true;
            else
            {
                rz = Math.Sqrt(it);
                for (; i <= rz; i++)
                {
                    if (it % i == 0)
                        return false;
                }
                return true;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (primtest(Convert.ToInt32(textBox1.Text)) == true)
                    textBox2.Text = "Prim!";
                else
                    textBox2.Text = "NU Prim!";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nu mere! "+ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int n = Convert.ToInt32(textBox1.Text);
                int x;
                string st = "";
                if (n >= 0)
                {
                    for (x = 0; x <= n; x++)
                        if (primtest(x) == true)
                            st += x + " ";
                }
                else
                {
                    for (x = 0; x >= n; x--)
                        if (primtest(x) == true)
                            st += x + " ";
                }                   
                textBox3.Text = st;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nu mere! " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x=0;
            for (int i = 1; i <= Convert.ToInt32(textBox1.Text); i++)
                x += i;
            textBox4.Text = Convert.ToString(x);
        }
    }
}
