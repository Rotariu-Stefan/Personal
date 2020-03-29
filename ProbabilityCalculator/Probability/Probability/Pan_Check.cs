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
    public partial class Pan_Check : UserControl
    {
        private ComplexEvRunner _evRunner;
        private int Index
        {
            get
            {
                return this.Parent.Controls.IndexOf(this);
            }
        }

        public Pan_Check(ComplexEvRunner evR, int initIndex)
        {
            InitializeComponent();
            _evRunner = evR;
            button_showCheck.Text = _evRunner.getCheckName(initIndex) + "(" + _evRunner.CheckParamsList[initIndex] + ")";
        }

        private void initializeData()
        {            
            button_showCheck.Text = _evRunner.getCheckName(Index) + "(" + _evRunner.CheckParamsList[Index] + ")";
        }

        private void button_removeCheck_Click(object sender, EventArgs e)
        {
            ((ComplexEvForm)this.Parent.Parent.Parent).removeCheck(Index);
            this.Dispose();
        }

        private void button_showCheck_Click(object sender, EventArgs e)
        {
            (new CheckForm(_evRunner, Index)).ShowDialog();
            initializeData();
            ((ComplexEvForm)this.Parent.Parent.Parent).resetName();
        }
    }
}
