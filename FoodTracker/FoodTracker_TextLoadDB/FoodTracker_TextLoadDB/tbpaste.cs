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
    public partial class tbpaste : TextBox      //custom textbox with flags and checks for paste events and dot types
    {
        #region Fields
        private const int WM_PASTE = 0x0302;    //code for paste event
        public bool dot                         //true if a dot was typed recently
        { get; set; }
        public bool pasted                      //true if a paste event happened recently
        { get; set; }
        #endregion

        #region init
        public tbpaste()    //init state
        {
            InitializeComponent();
            pasted = false;
            dot = false;
        }
        #endregion

        #region Methods
        protected override void OnPaint(PaintEventArgs pe)  //paint generated
        {
            base.OnPaint(pe);
        }
        
        protected override void WndProc(ref Message m)      //override windows? event that occurs in this textbox
        {
            if (m.Msg == WM_PASTE)      //sets paste flag as true if event was a paste of any kind
                pasted = true;

            base.WndProc(ref m);        //continues with typical textbox handling
        }
        #endregion
    }
}
