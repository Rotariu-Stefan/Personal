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
    public class arb
    {
        #region fields
        public bool ord;
        private node p_rad;
        private int p_len;

        public node rad
        {
            get
            {
                return p_rad;
            }
            set
            {
                p_rad = value;
            }
        }
        public int len
        {
            get
            {
                return p_len;
            }
            set
            {
                p_len = value;
            }
        }

        public arb()
        {
            rad = null;
            len = 0;
            ord = true;
        }
        public arb(double v)
        {
            rad = new node(v);
            len = 1;
            ord = true;
        }
        public arb(node r)
        {
            rad = r;
            len = 1;
            ord = true;
        }
        #endregion

        #region adds
        #region custom
        public void addDr(node pr, double v)
        {
            if (pr.ndr == null)
            {
                pr.ndr = new node(v);
                pr.ndr.par = pr;
                len++;
            }
            ord = false;
        }
        public void addDr(node pr, node c)
        {
            if (pr.ndr == null)
            {
                pr.ndr = c;
                c.par = pr;
                len++;
            }
            ord = false;
        }
        public void addSt(node pr, double v)
        {
            if (pr.nst == null)
            {
                pr.nst = new node(v);
                pr.nst.par = pr;
                len++;
            }
            ord = false;
        }
        public void addSt(node pr, node c)
        {
            if (pr.nst == null)
            {
                pr.nst = c;
                c.par = pr;
                len++;
            }
            ord = false;
        }
        #endregion

        #region auto
        public node addAuTo(node n)
        {
            if (len == 0)
                return null;
            else
                return addA(rad, n);
        }
        private node addA(node t, node n)
        {
            if (t.val > n.val)
            {
                if (t.nst == null)
                    return t;
                else
                    return addA(t.nst, n);
            }
            else
            {
                if (t.ndr == null)
                    return t;
                else
                    return addA(t.ndr, n);
            }
        }
        public node addAuTo(double v)
        {
            if (len == 0)
                return null;
            else
                return addA(rad, v);
        }
        private node addA(node t, double v)
        {
            if (t.val > v)
            {
                if (t.nst == null)
                    return t;
                else
                    return addA(t.nst, v);
            }
            else
            {
                if (t.ndr == null)
                    return t;
                else
                    return addA(t.ndr, v);
            }
        }
        #endregion
        #endregion

        #region sort
        public void sort()
        {
            while (ord == false)
            {
                ord = true;
                srt(rad, null, null);
            }
        }
        private void srt(node n,node inf,node sup)
        {
            if (inf != null)
                if (n.val < inf.val)
                {
                    ord = false;
                    swap(n, inf);
                }
            if (sup != null)
                if (n.val > sup.val)
                {
                    ord = false;
                    swap(n, sup);
                }

            if(n.nst!=null)
                srt(n.nst, inf, n);
            if(n.ndr!=null)
                srt(n.ndr, n, sup);
        }
        public void swap(node n1, node n2)
        {
            double ax=n1.val;
            n1.val = n2.val;
            n2.val = ax;
        }
        #endregion

        #region search
        public node search(double v)
        {
            if (ord == false)
                MessageBox.Show("Tree not ordered !");
            if (rad.val == v)
                return rad;
            else if (rad.val > v)
                return sh(rad.nst, v);
            else
                return sh(rad.ndr, v);
        }
        private node sh(node n, double v)
        {
            if (n == null)
                return null;
            if (n.val == v)
                return n;
            else if (n.val > v)
                return sh(n.nst, v);
            else
                return sh(n.ndr, v);
        }
        #endregion

        #region delete
        public void delete(node n)        
        {            
            if (n != null)
            {
                if (n.ndr == null)
                {
                    if (n.nst == null)
                    {
                        if (len<=1)
                        {
                            rad = new node();
                            rad.Text = "--";
                            len = 0;
                        }
                        else
                        {
                            n.Dispose();
                            if (n.par.ndr == n)
                                n.par.ndr = null;
                            else
                                n.par.nst = null;
                            len--;
                        }
                    }
                    else
                    {
                        n.val = n.nst.val;
                        delete(n.nst);
                    }
                }
                else
                {
                    n.val = n.ndr.val;
                    delete(n.ndr);
                }

            }
        }
        #endregion

        public override string ToString()
        {
            string r = "";
            Queue<node> q = new Queue<node>();
            q.Enqueue(rad);

            while (q.Count > 0)
            {
                node n = q.Dequeue();
                r += n + " ";

                if (n.nst != null)
                {
                    q.Enqueue(n.nst);
                    r += n.nst + " ";
                }
                else
                    r += "null ";

                if (n.ndr != null)
                {
                    q.Enqueue(n.ndr);
                    r += n.ndr + "\n";
                }
                else
                    r += "null\n";
            }
            return r;
        }
    }
}
