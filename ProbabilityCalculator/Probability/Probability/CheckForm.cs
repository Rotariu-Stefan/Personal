using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Probability
{
    public partial class CheckForm : Form
    {
        private ComplexEvRunner _evRunner;
        private int _index;

        public CheckForm(ComplexEvRunner evR)
        {
            InitializeComponent();
            _evRunner = evR;
            _index = -1;
            initializeData();
        }
        public CheckForm(ComplexEvRunner evR, int index)
        {
            InitializeComponent();
            _evRunner = evR;
            _index = index;
            initializeData();
        }

        private void initializeData()
        {
            if (_index != -1)
            {
                string chName = _evRunner.getCheckName(_index);
                groupBox_thisCheck.Text = chName + "(" + _evRunner.CheckParamsList[_index] + ")";
                comboBox_checkType.SelectedItem = chName;
                textBox_param.Text = _evRunner.CheckParamsList[_index].ToString();
                button_save.Enabled = false;
            }
            else
            {
                comboBox_checkType.SelectedIndex = 0;
                button_save.Text = "Add";
                button_save.Enabled = true;
            }
            button_cancel.Enabled = false;
        }

        private void comboBox_checkType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_checkType.SelectedIndex)
            {
                case 0:
                    label_checkHelp.Text = "(?) Tests whether ALL events were Success or Fail";
                    label_paramHelp.Text = "(?) 1+ for Success or 0 for Fail events";
                    break;
                case 1:
                    label_checkHelp.Text = "(?) Tests if At LEAST ONE event was Success or Fail";
                    label_paramHelp.Text = "(?) 1+ for Success or 0 for Fail event";
                    break;
                case 2:
                    label_checkHelp.Text = "(?) Tests if At LEAST X number of events were Success";
                    label_paramHelp.Text = "(?) X (minimum number of Success events needed)";
                    break;
                case 3:
                    label_checkHelp.Text = "(?) Tests if At LEAST X number of events were Fail";
                    label_paramHelp.Text = "(?) X (minimum number of Fail events needed)";
                    break;
                case 4:
                    label_checkHelp.Text = "(?) Tests if At MOST X number of events were Success";
                    label_paramHelp.Text = "(?) X (maximum number of Success events allowed)";
                    break;
                case 5:
                    label_checkHelp.Text = "(?) Tests if At MOST X number of events were Fail";
                    label_paramHelp.Text = "(?) X (maximum number of Fail events allowed)";
                    break;
            }
            groupBox_thisCheck.Text = comboBox_checkType.SelectedItem + "(1)";
            textBox_param.Text = "1";
            button_save.Enabled = true;
            button_cancel.Enabled = true;
        }

        private void button_closeForm_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            initializeData();
        }

        private void textBox_param_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            button_cancel.Enabled = true;
            button_save.Enabled = true;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (_index == -1)
            {
                button_save.Text = "Save";
                _index = _evRunner.CheckParamsList.Count;
                _evRunner.addCheck(comboBox_checkType.SelectedItem.ToString(), textBox_param.Text == "" ? 1 : Convert.ToInt32(textBox_param.Text));
            }
            else
                _evRunner.replaceCheck(comboBox_checkType.SelectedItem.ToString(), textBox_param.Text == "" ? 1 : Convert.ToInt32(textBox_param.Text), _index);

            groupBox_thisCheck.Text = comboBox_checkType.SelectedItem + "(" + textBox_param.Text + ")";
            button_save.Enabled = false;
            button_cancel.Enabled = false;
        }
    }
}
