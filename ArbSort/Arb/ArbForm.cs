using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Arb
{
    public partial class ArbForm : Form
    {
        arb a;
        node sb;

        public ArbForm()
        {
            InitializeComponent();

            openFileDialog1.InitialDirectory = new DirectoryInfo(Application.StartupPath).Parent.Parent.FullName;
            openFileDialog1.FileName = "arb1.txt";

            saveFileDialog1.InitialDirectory = new DirectoryInfo(Application.StartupPath).Parent.Parent.FullName;
            saveFileDialog1.FileName = "arb2.txt";

            init();
            lol2();

        }

        #region misc/cleanup
        private void init()
        {
            node b = new node(11);
            b.Location = new Point(Width/2-25, 10);
            arbpanel.Controls.Add(b);
            b.Click += delegate(object sender, EventArgs e)
            {
                if (sb != null)
                    sb.BackColor = Color.LightBlue;
                sb = sender as node;
                sb.BackColor = Color.LightPink;
                reset();
            };

            a = new arb(b);
        }
        private void reset()
        {
            if (sb != null)
            {
                if (sb.ndr == null)
                {
                    baddDr.Enabled = true;
                    tbaddDr.Enabled = true;
                }
                else
                {
                    baddDr.Enabled = false;
                    tbaddDr.Enabled = false;
                }
                if (sb.nst == null)
                {
                    baddSt.Enabled = true;
                    tbaddSt.Enabled = true;
                }
                else
                {
                    baddSt.Enabled = false;
                    tbaddSt.Enabled = false;
                }
                bdel.Enabled = true;
                bchange.Enabled = true;
                tbchange.Enabled = true;
            }
            else
            {
                bdel.Enabled = false;
                bchange.Enabled = false;
                tbchange.Enabled = false;
            }

        }
        private void erase()
        {
            arbpanel.Dispose();
            arbpanel = new Panel();
            arbpanel.BackColor = Color.White;
            arbpanel.Width = 1887;
            arbpanel.Height = 212;
            Controls.Add(arbpanel);
            sb = null;
            lol2();
        }
        private void display(node b, Point p)
        {
            int l = p.Y / 35 + 2;
            b.Location = p;
            arbpanel.Controls.Add(b);
            b.Click += delegate(object sender, EventArgs e)
            {
                if (sb != null)
                    sb.BackColor = Color.LightBlue;
                sb = sender as node;
                sb.BackColor = Color.LightPink;
                reset();
            };

            if (b.nst != null)
                display(b.nst, new Point((int)(p.X - Width / Math.Pow(2, l)), (l - 1) * 35));
            if (b.ndr != null)
                display(b.ndr, new Point((int)(p.X + Width / Math.Pow(2, l)), (l - 1) * 35));
        }
        private void lol()
        {
            Button lol = new Button();
            Label llol = new Label();
            llol.Font = new Font("Arial", 11, FontStyle.Bold);
            llol.Height = 60;
            lol.Text = "DON'T CLICK ME !!!";
            lol.Location = new Point(Width - 200, 10);
            lol.Font = new Font("Arial", 11, FontStyle.Bold);
            lol.BackColor = Color.Black;
            lol.ForeColor = Color.White;
            lol.Height = 60;
            lol.Width = 150;
            lol.Click += delegate(object sender, EventArgs e)
            {
                if ((sender as Button).Location.X == 10)
                {
                    llol.Text = "LOL\n MISSED !!!";
                    llol.Location = (sender as Button).Location;
                    (sender as Button).Location = new Point(Width - 200, 10);
                }
                else
                {
                    llol.Text = "LOL\n MISSED !!!";
                    llol.Location = (sender as Button).Location;
                    (sender as Button).Location = new Point(10, 10);
                }
            };
            lol.MouseMove += delegate(object sender, MouseEventArgs e)
            {
                lol.Text = "OMG NOOOO !!";
                lol.ForeColor = Color.Red;
            };
            lol.MouseLeave += delegate(object sender, EventArgs e)
            {
                lol.Text = "HAHA NOOB !!";
                lol.ForeColor = Color.White;
            };
            arbpanel.Controls.Add(lol);
            arbpanel.Controls.Add(llol);
        }
        private void lol2()
        {
            Button lol2 = new Button();
            lol2.Text = "CAN'T TOUCH THIS !!";
            lol2.Location = new Point(Width - 200, 10);
            lol2.Font = new Font("Arial", 11, FontStyle.Bold);
            lol2.BackColor = Color.Black;
            lol2.ForeColor = Color.Red;
            lol2.Height = 50;
            lol2.Width = 150;
            lol2.MouseMove += delegate(object sender, MouseEventArgs e)
            {
                if ((sender as Button).Location.X == 10)
                    (sender as Button).Location = new Point(400, 10);
                else if ((sender as Button).Location.X == 400)
                    (sender as Button).Location = new Point(1000, 10);
                else if ((sender as Button).Location.X == 1000)
                    (sender as Button).Location = new Point(Width - 200, 10);
                else
                    (sender as Button).Location = new Point(10, 10);
            };
            arbpanel.Controls.Add(lol2);
        }
        #endregion

        #region adds
        private void baddDr_Click(object sender, EventArgs e)
        {
            crDrNode(Convert.ToDouble(tbaddDr.Text));
            tbaddDr.Text = string.Empty;
            reset();
        }
        private void crDrNode(double v)
        {
            int l = sb.Location.Y / 35 + 2;
            if (l < 7)
            {
                node b = new node(v);
                b.Location = new Point((int)(sb.Location.X + Width / Math.Pow(2, l)), (l - 1) * 35);

                arbpanel.Controls.Add(b);
                b.Click += delegate(object sender, EventArgs e)
                {
                    if (sb != null)
                        sb.BackColor = Color.LightBlue;
                    sb = sender as node;
                    sb.BackColor = Color.LightPink;
                    reset();
                };

                a.addDr(sb, b);
            }
            else
                MessageBox.Show("Depth limit reached !");
        }

        private void baddSt_Click(object sender, EventArgs e)
        {
            crStNode(Convert.ToDouble(tbaddSt.Text));
            tbaddSt.Text = string.Empty;
            reset();
        }
        private void crStNode(double v)
        {
            int l = sb.Location.Y / 35 + 2;
            if (l < 7)
            {
                node b = new node(v);
                b.Location = new Point((int)(sb.Location.X - Width / Math.Pow(2, l)), (l - 1) * 35);

                arbpanel.Controls.Add(b);
                b.Click += delegate(object sender, EventArgs e)
                {
                    if (sb != null)
                        sb.BackColor = Color.LightBlue;
                    sb = sender as node;
                    sb.BackColor = Color.LightPink;
                    reset();
                };

                a.addSt(sb, b);
            }
            else
                MessageBox.Show("Depth limit reached !");
        }

        private void baddAuto_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(tbaddAuto.Text);
            if (sb != null)
                sb.BackColor = Color.LightBlue;
            sb = a.addAuTo(x);

            if (x < sb.val)
                crStNode(x);
            else
                crDrNode(x);
            sb = null;
            reset();
            tbaddAuto.Text = string.Empty;
        }
        #endregion

        #region change/delete/search
        private void bchange_Click(object sender, EventArgs e)
        {
            sb.val = Convert.ToDouble(tbchange.Text);
            a.ord = false;
            tbchange.Text = string.Empty;
            reset();
        }

        private void bdel_Click(object sender, EventArgs e)
        {
            if (sb != null)
                sb.BackColor = Color.LightBlue;
            a.delete(sb);
            reset();
        }

        private void bsearch_Click(object sender, EventArgs e)
        {
            if (sb != null)
                sb.BackColor = Color.LightBlue;
            sb = a.search(Convert.ToDouble(tbsearch.Text));
            if (sb == null)
                MessageBox.Show("Not Found !");
            else
            {
                sb.BackColor = Color.LightPink;
                reset();
            }
            tbsearch.Text = string.Empty;
        }
        #endregion

        #region file
        private void bload_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                erase();
                a = new arb();

                StreamReader file = new StreamReader(openFileDialog1.FileName);
                string ln;
                Dictionary<string, string[]> d = new Dictionary<string, string[]>();

                while ((ln = file.ReadLine()) != null)
                {
                    string[] x = ln.Split(' ');
                    if (a.len == 0)
                        a = new arb(Convert.ToDouble(x[0]));
                    d.Add(x[0], new string[] { x[1], x[2] });
                }
                file.Close();

                addF(a.rad, d);

            }
            display(a.rad, new Point(Width / 2 - 25, 10));
            reset();
        }
        private void addF(node n, Dictionary<string, string[]> d)
        {
            if (d[n.Text][0] != "null")
            {
                a.addSt(n, Convert.ToDouble(d[n.Text][0]));
                addF(n.nst, d);
            }
            if (d[n.Text][1] != "null")
            {
                a.addDr(n, Convert.ToDouble(d[n.Text][1]));
                addF(n.ndr, d);
            }
        }

        private void bsave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter file = new StreamWriter(saveFileDialog1.FileName);
                file.Write(a.ToString());
                file.Close();
            }
        }
        #endregion

        #region sort/level
        private void bsort_Click(object sender, EventArgs e)
        {
            a.sort();
            if (sb != null)
                sb.BackColor = Color.LightBlue;
            sb = null;
            reset();
        }

        private void blevel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Yet Implemented");
        }
        #endregion

    }
}
