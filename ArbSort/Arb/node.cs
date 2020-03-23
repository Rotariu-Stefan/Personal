using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Arb
{
    public class node : Button
    {
        #region fields
        private node p_ndr;
        private node p_nst;
        private node p_par;
        private double p_val;

        public node ndr
        {
            get
            {
                return p_ndr;
            }
            set
            {
                p_ndr = value;
            }
        }
        public node nst
        {
            get
            {
                return p_nst;
            }
            set
            {
                p_nst = value;
            }
        }
        public node par
        {
            get
            {
                return p_par;
            }
            set
            {
                p_par = value;
            }
        }
        public double val
        {
            get
            {
                return p_val;
            }
            set
            {
                p_val = value;
                Text = value.ToString();
            }
        }
        #endregion

        #region constr
        public node()
            : base()
        {
            Font = new Font("Arial", 11, FontStyle.Bold);
            BackColor = Color.LightBlue;
            Height = 25;
            Width = 50;
            Text = "--";
        }
        public node(double v)
            : base()
        {
            Font = new Font("Arial", 11, FontStyle.Bold);
            BackColor = Color.LightBlue;
            Height = 25;
            Width = 50;
            val = v;
        }
        #endregion

        public override string ToString()
        {
            return val.ToString();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            ResumeLayout(false);
        }
    }
}
