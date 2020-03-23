using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodTracker_TextLoadDB
{
    public partial class tbpaste : TextBox
    {
        private const int WM_PASTE = 0x0302;
        public bool dot
        { get; set; }
        public bool pasted
        { get; set; }
        public tbpaste()
        {
            InitializeComponent();
            pasted = false;
            dot = false;
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_PASTE)
                pasted = true;

            base.WndProc(ref m);
        }
    }
}
