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
    public partial class SimpleEvForm : Form
    {
        private SimpleEvRunner _evRunner;
        public SimpleEvForm()
        {
            InitializeComponent();
            _evRunner = new SimpleEvRunner(new Event());
            initializeData();
        }
        public SimpleEvForm(string name)
        {
            InitializeComponent();
            _evRunner = new SimpleEvRunner(new Event(name));
            initializeData();
        }
        public SimpleEvForm(Event ev)
        {
            InitializeComponent();
            _evRunner = new SimpleEvRunner(ev);
            initializeData();
        }
        public SimpleEvForm(SimpleEvRunner evR)
        {
            InitializeComponent();
            _evRunner = evR;
            initializeData();
        }

        private void initializeData()
        {
            if (Event.keywords.Contains(_evRunner.getName()))
                comboBox_evType.SelectedItem = _evRunner.getName();
            else
            {
                comboBox_evType.SelectedIndex = 0;
                comboSelect(0);
                setValues(_evRunner.Ev.FavorNr, _evRunner.Ev.PossibleNr);
            }
            checkBox_not.Checked = _evRunner.CheckParam == 0;
            resetName();

            textBox_tries.Text = EventRunner.defaultTries.ToString();

            button_save.Enabled = false;
            button_cancel.Enabled = false;
            textBox_output.Focus();
        }
        private void resetName()
        {
            groupBox_thisSimpleEv.Text = _evRunner.getName();
            textBox_name.Text = _evRunner.getName();
        }

        private void outputLine(string str)
        {
            textBox_output.AppendText(str + "\r\n");
        }
        private void outputLine()
        {
            textBox_output.AppendText("\r\n");
        }

        private void button_closeForm_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void comboSelect(int which)
        {
            if (which == 0)
            {
                textBox_favor.ReadOnly = false;
                textBox_possible.ReadOnly = false;
                textBox_chance.ReadOnly = true;
                radio_values.Checked = true;
            }
            else if(which==1)
            {
                textBox_favor.ReadOnly = true;
                textBox_possible.ReadOnly = true;
                textBox_chance.ReadOnly = false;
                radio_chance.Checked = true;
            }
            else
            {
                textBox_favor.ReadOnly = true;
                textBox_possible.ReadOnly = true;
                textBox_chance.ReadOnly = true;
                radio_values.Checked = false;
                radio_chance.Checked = false;
            }
        }
        private void setValues(int fav, int pos)
        {
            textBox_favor.Text = fav.ToString();
            textBox_possible.Text = pos.ToString();
            textBox_chance.Text = ((double)fav * 100 / (double)pos).ToString();
        }

        private void comboBox_evType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_evType.SelectedIndex)
            {
                case 0:
                    comboSelect(0);
                    break;
                case 1:
                    comboSelect(1);
                    break;
                case 2:
                    comboSelect(2);
                    setValues(1, 1);
                    break;
                case 3:
                    comboSelect(2);
                    setValues(0, 1);
                    break;
                case 4:
                    comboSelect(2);
                    setValues(1, 2);
                    break;
            }
            button_save.Enabled = true;
            button_cancel.Enabled = true;
        }

        private void radio_values_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_values.Checked)
            {
                comboSelect(0);
                comboBox_evType.SelectedIndex = 0;
            }
        }
        private void radio_chance_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_chance.Checked)
            {
                comboSelect(1);
                comboBox_evType.SelectedIndex = 1;
            }
        }

        private void textBox_tries_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void textBox_favor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
            else
            {
                button_save.Enabled = true;
                button_cancel.Enabled = true;
            }
        }
        private void textBox_possible_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
            else
            {
                button_save.Enabled = true;
                button_cancel.Enabled = true;
            }
        }
        private void textBox_chance_KeyPress(object sender, KeyPressEventArgs e) //Need to Make Chance field take 2 Decimals!!
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.')) e.Handled = true;
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) e.Handled = true;
            else
            {
                button_save.Enabled = true;
                button_cancel.Enabled = true;
            }
        }

        private void checkBox_defTries_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_defTries.Checked)
            {
                textBox_tries.Enabled = false;
                textBox_tries.Text = EventRunner.defaultTries.ToString();
            }
            else textBox_tries.Enabled = true;
        }

        private void button_execute_Click(object sender, EventArgs e)   //Maybe implement a Background Worker? +Stop function?
        {
            groupBox_thisSimpleEv.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            outputLine("Calculating...");
            if (checkBox_defTries.Checked)
                outputLine(_evRunner.getMessage());
            else
            {
                int tempTries = 0;
                Int32.TryParse(textBox_tries.Text, out tempTries);
                if (tempTries == 0)
                {
                    textBox_tries.Text = "1";
                    outputLine(_evRunner.getMessage(1));
                }
                else
                    outputLine(_evRunner.getMessage(tempTries));
            }
            outputLine();

            Application.DoEvents();     //this or BG Worker?
            groupBox_thisSimpleEv.Enabled = true;
        }

        private void button_save_Click(object sender, EventArgs e)  //Need to Make Chance field Only take 2 Decimals!!
        {
            try
            {
                switch (comboBox_evType.SelectedIndex)
                {
                    case 0:
                        _evRunner.Ev.setValues(textBox_favor.Text == "" ? 0 : Convert.ToInt32(textBox_favor.Text),
                            textBox_possible.Text == "" ? 0 : Convert.ToInt32(textBox_possible.Text));
                        setValues(_evRunner.Ev.FavorNr, _evRunner.Ev.PossibleNr);
                        if (Event.keywords.Contains(_evRunner.Ev.Name)) _evRunner.Ev.Name = "";
                        break;
                    case 1:
                        _evRunner.Ev.setChance(textBox_chance.Text == "" ? 0 : Convert.ToDouble(textBox_chance.Text) / 100);
                        setValues(_evRunner.Ev.FavorNr, _evRunner.Ev.PossibleNr);
                        if (Event.keywords.Contains(_evRunner.Ev.Name)) _evRunner.Ev.Name = "";
                        break;
                    case 2:
                        _evRunner.Ev = new Event(true);
                        break;
                    case 3:
                        _evRunner.Ev = new Event(false);
                        break;
                    case 4:
                        _evRunner.Ev = new Event();
                        break;
                }

                resetName();
                button_save.Enabled = false;
                button_cancel.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                button_cancel_Click(sender, e);
            }
        }
        private void button_cancel_Click(object sender, EventArgs e)
        {
            initializeData();
        }

        private void button_rename_Click(object sender, EventArgs e)
        {
            _evRunner.Name = textBox_name.Text;
            groupBox_thisSimpleEv.Text = _evRunner.Name;
            if (textBox_name.Text == "") textBox_name.Text = _evRunner.Name;
            button_rename.Enabled = false;
        }

        private void textBox_name_TextChanged(object sender, EventArgs e)
        {
            if (textBox_name.Text != groupBox_thisSimpleEv.Text)
                button_rename.Enabled = true;
        }

        private void checkBox_not_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_not.Checked == true)
                _evRunner.CheckParam = 0;
            else
                _evRunner.CheckParam = 1;
            resetName();
        }
    }
}
