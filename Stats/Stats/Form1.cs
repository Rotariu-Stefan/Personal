using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Stats
{
    public partial class Form1 : Form
    {
        double oval;
        double cval;

        private void docalc(double rval, char am, bool proc, char ri)
        {
            if (ri == 'r')
            {
                if (am == 'a')
                    if (proc == false)
                        cval = cval - rval;
                    else
                        cval = cval - (oval * rval / 100);
                if (am == 'm')
                    if (proc == false)
                        Console.WriteLine("Woot?");
                    else
                        cval = cval - (cval * rval / 100);
            }
            if (ri == 'i')
            {
                if (am == 'a')
                    if (proc == false)
                        cval = cval + rval;
                    else
                        cval = cval + (oval * rval / 100);
                if (am == 'm')
                    if (proc == false)
                        Console.WriteLine("Woot?");
                    else
                        cval = cval + (cval * rval / 100);
            }
        }

        public Form1()
        {
            InitializeComponent();
            cval = 0;
            oval = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox8.Text = "0";
            textBox9.Text = "0";
            textBox10.Text = "0";
            textBox11.Text = "0";
            textBox12.Text = "0";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            oval = Convert.ToDouble(textBox13.Text);
            cval = oval;

            if (radioButton25.Checked == true)
            {
                docalc(Convert.ToDouble(textBox1.Text), radioButton2.Checked == true ? 'a' : 'm', checkBox1.Checked == true ? true : false, radioButton28.Checked == true ? 'r' : 'i');
                docalc(Convert.ToDouble(textBox2.Text), radioButton4.Checked == true ? 'a' : 'm', checkBox2.Checked == true ? true : false, radioButton30.Checked == true ? 'r' : 'i');
                docalc(Convert.ToDouble(textBox4.Text), radioButton8.Checked == true ? 'a' : 'm', checkBox4.Checked == true ? true : false, radioButton32.Checked == true ? 'r' : 'i');
                docalc(Convert.ToDouble(textBox3.Text), radioButton6.Checked == true ? 'a' : 'm', checkBox3.Checked == true ? true : false, radioButton34.Checked == true ? 'r' : 'i');
                docalc(Convert.ToDouble(textBox6.Text), radioButton12.Checked == true ? 'a' : 'm', checkBox6.Checked == true ? true : false, radioButton36.Checked == true ? 'r' : 'i');
                docalc(Convert.ToDouble(textBox5.Text), radioButton10.Checked == true ? 'a' : 'm', checkBox5.Checked == true ? true : false, radioButton38.Checked == true ? 'r' : 'i');

                docalc(Convert.ToDouble(textBox12.Text), radioButton24.Checked == true ? 'a' : 'm', checkBox12.Checked == true ? true : false, radioButton40.Checked == true ? 'r' : 'i');
                docalc(Convert.ToDouble(textBox11.Text), radioButton22.Checked == true ? 'a' : 'm', checkBox11.Checked == true ? true : false, radioButton42.Checked == true ? 'r' : 'i');
                docalc(Convert.ToDouble(textBox10.Text), radioButton20.Checked == true ? 'a' : 'm', checkBox10.Checked == true ? true : false, radioButton44.Checked == true ? 'r' : 'i');
                docalc(Convert.ToDouble(textBox9.Text), radioButton18.Checked == true ? 'a' : 'm', checkBox9.Checked == true ? true : false, radioButton46.Checked == true ? 'r' : 'i');
                docalc(Convert.ToDouble(textBox8.Text), radioButton16.Checked == true ? 'a' : 'm', checkBox8.Checked == true ? true : false, radioButton48.Checked == true ? 'r' : 'i');
                docalc(Convert.ToDouble(textBox7.Text), radioButton14.Checked == true ? 'a' : 'm', checkBox7.Checked == true ? true : false, radioButton50.Checked == true ? 'r' : 'i');
            }

            textBox14.Text = Convert.ToString(cval);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox13.Text = textBox14.Text;
            textBox14.Text = "0";
            oval = Convert.ToDouble(textBox13.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox14.Text = Convert.ToString(1 / Convert.ToDouble(textBox15.Text) * Convert.ToDouble(textBox14.Text));
        }
    }
}
