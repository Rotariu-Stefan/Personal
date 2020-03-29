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
    public partial class ComplexEvForm : Form
    {
        private ComplexEvRunner _evRunner;
        public ComplexEvForm()
        {
            InitializeComponent();
            _evRunner = new ComplexEvRunner(new Event());
            initializeData();
        }
        public ComplexEvForm(string name)
        {
            InitializeComponent();
            _evRunner = new ComplexEvRunner(new Event(name));
            initializeData();
        }
        public ComplexEvForm(Event ev)
        {
            InitializeComponent();
            _evRunner = new ComplexEvRunner(ev);
            initializeData();
        }
        public ComplexEvForm(EventRunner evR)
        {
            InitializeComponent();
            if (evR is SimpleEvRunner)
                _evRunner = new ComplexEvRunner(evR);
            else _evRunner = (ComplexEvRunner)evR;
            initializeData();
        }

        private void initializeData()
        {
            foreach (EventRunner evR in _evRunner.EvRunnerList)
                if (evR is ComplexEvRunner) pan_complex.Controls.Add(new Pan_ComplexEv((ComplexEvRunner)evR));
                else pan_simple.Controls.Add(new Pan_SimpleEv((SimpleEvRunner)evR));
            pan_complex.Controls.SetChildIndex(button_addComplexEv, pan_complex.Controls.Count);
            pan_simple.Controls.SetChildIndex(button_addSimpleEv, pan_simple.Controls.Count);

            if (_evRunner.CheckMethodsList != null)
            {
                for (int i = 0; i < _evRunner.CheckMethodsList.Length; i++)
                    pan_check.Controls.Add(new Pan_Check(_evRunner, i));
                pan_check.Controls.SetChildIndex(button_addCheck, pan_check.Controls.Count);
            }

            resetName();

            textBox_tries.Text = EventRunner.defaultTries.ToString();
            textBox_output.Focus();
        }
        public void resetName()
        {
            groupBox_thisComplexEv.Text = _evRunner.getName();
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

        public void removeEvRunner(EventRunner evR)
        {
            _evRunner.removeEvents(evR);
            resetName();
        }
        public void removeCheck(int index)
        {
            _evRunner.removeCheck(index);
            resetName();
        }

        private void button_execute_Click(object sender, EventArgs e)   //Maybe implement a Background Worker? +Stop function?
        {
            groupBox_thisComplexEv.Enabled = false;
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
            groupBox_thisComplexEv.Enabled = true;
        }

        private void button_closeForm_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void textBox_tries_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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

        private void button_addComplexEv_Click(object sender, EventArgs e)
        {
            ComplexEvRunner tempRunner = new ComplexEvRunner(new Event());
            _evRunner.addEvents(tempRunner);
            pan_complex.Controls.Add(new Pan_ComplexEv(tempRunner));
            pan_complex.Controls.SetChildIndex(button_addComplexEv, pan_complex.Controls.Count);
            resetName();
        }

        private void button_addSimpleEv_Click(object sender, EventArgs e)
        {
            SimpleEvRunner tempRunner = new SimpleEvRunner(new Event());
            _evRunner.addEvents(tempRunner);
            pan_simple.Controls.Add(new Pan_SimpleEv(tempRunner));
            pan_simple.Controls.SetChildIndex(button_addSimpleEv, pan_simple.Controls.Count);
            resetName();
        }

        private void button_rename_Click(object sender, EventArgs e)
        {
            _evRunner.Name = textBox_name.Text;
            groupBox_thisComplexEv.Text = _evRunner.getName();
            if (textBox_name.Text == "") textBox_name.Text = _evRunner.getName();
            button_rename.Enabled = false;
        }

        private void textBox_name_TextChanged(object sender, EventArgs e)
        {
            if (textBox_name.Text != groupBox_thisComplexEv.Text)
                button_rename.Enabled = true;
        }

        private void button_addCheck_Click(object sender, EventArgs e)
        {
            int chNr = _evRunner.CheckParamsList.Count();

            (new CheckForm(_evRunner)).ShowDialog();

            if (chNr != _evRunner.CheckParamsList.Count())
                pan_check.Controls.Add(new Pan_Check(_evRunner, chNr));
            pan_check.Controls.SetChildIndex(button_addCheck, pan_check.Controls.Count);
            resetName();
        }
    }
}
