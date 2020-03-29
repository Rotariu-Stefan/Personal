using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Probability
{
    public partial class Pan_ComplexEv : UserControl
    {
        private ComplexEvRunner _evRunner;
        public Pan_ComplexEv()
        {
            InitializeComponent();
            _evRunner = new ComplexEvRunner(new Event());
            initializeData();
        }
        public Pan_ComplexEv(string name)
        {
            InitializeComponent();
            _evRunner = new ComplexEvRunner(new Event());
            _evRunner.Name = name;
            initializeData();
        }
        public Pan_ComplexEv(ComplexEvRunner evR)
        {
            InitializeComponent();
            _evRunner = evR;
            initializeData();
        }

        private void initializeData()
        {
            button_showComplexEv.Text = _evRunner.getName();
            numeric_repeat.Value = _evRunner.Repeat;
        }

        private void button_showComplexEv_Click(object sender, EventArgs e)
        {
            (new ComplexEvForm(_evRunner)).ShowDialog();
            initializeData();
            ((ComplexEvForm)this.Parent.Parent.Parent).resetName();
        }

        private void button_removeComplexEv_Click(object sender, EventArgs e)
        {
            ((ComplexEvForm)this.Parent.Parent.Parent).removeEvRunner(_evRunner);
            this.Dispose();
        }

        private void numeric_repeat_ValueChanged(object sender, EventArgs e)
        {
            _evRunner.Repeat = (int)numeric_repeat.Value;
            ((ComplexEvForm)this.Parent.Parent.Parent).resetName();
        }
    }
}
