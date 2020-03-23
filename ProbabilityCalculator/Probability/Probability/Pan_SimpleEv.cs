using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Pan_SimpleEv : UserControl
    {
        private SimpleEvRunner _evRunner;
        public Pan_SimpleEv()
        {
            InitializeComponent();
            _evRunner = new SimpleEvRunner(new Event());
            initializeData();
        }
        public Pan_SimpleEv(string name)
        {
            InitializeComponent();
            _evRunner = new SimpleEvRunner(new Event());
            _evRunner.Name = name;
            initializeData();
        }
        public Pan_SimpleEv(SimpleEvRunner evR)
        {
            InitializeComponent();
            _evRunner = evR;
            initializeData();
        }

        private void initializeData()
        {
            button_showSimpleEv.Text = _evRunner.getName();
            numeric_repeat.Value = _evRunner.Repeat;
        }

        private void button_showSimpleEv_Click(object sender, EventArgs e)
        {
            (new SimpleEvForm(_evRunner)).ShowDialog();
            initializeData();
            ((ComplexEvForm)this.Parent.Parent.Parent).resetName();
        }

        private void button_removeSimpleEv_Click(object sender, EventArgs e)
        {
            ((ComplexEvForm)this.Parent.Parent.Parent).removeEvRunner(_evRunner);
            this.Dispose();
        }

        private void numeric_repeat_ValueChanged(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                _evRunner.Repeat = (int)numeric_repeat.Value;
                ((ComplexEvForm)this.Parent.Parent.Parent).resetName();
            }
        }
    }
}
