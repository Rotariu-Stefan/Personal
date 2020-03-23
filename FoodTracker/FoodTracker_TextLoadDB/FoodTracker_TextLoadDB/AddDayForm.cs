using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace FoodTracker_TextLoadDB
{
    public partial class AddDayForm : Form
    {
        DayEntry _day;

        #region Constructors
        public AddDayForm()
        {
            InitializeComponent();

            _day = new DayEntry();

            comboBox_measure.SelectedIndex = 0;
            listBox_foodItems.Items.AddRange(MainForm.Foods.ToArray());
            if (listBox_foodItems.Items.Count != 0)
                listBox_foodItems.SelectedIndex = 0;
            comboBox_meals.DataSource = new BindingSource(_day._mealEntries, "");
            comboBox_meals.ValueMember = "_name";

            updateDay();
        }
        public AddDayForm(DateTime date)
        {
            InitializeComponent();

            foreach (DayEntry day in MainForm.Days)
                if (day._date == date)
                {
                    _day = day.Clone();
                    break;
                }
            if (_day == null)
            {
                _day = new DayEntry();
                _day._date = date;
            }
            textBox_activ.Text = _day._activ;
            textBox_noteScore.Text = _day._note._grade;
            textBox_noteText.Text = _day._note._text;

            comboBox_measure.SelectedIndex = 0;
            listBox_foodItems.Items.AddRange(MainForm.Foods.ToArray());
            if(listBox_foodItems.Items.Count!=0)
                listBox_foodItems.SelectedIndex = 0;
            comboBox_meals.DataSource = new BindingSource(_day._mealEntries, "");
            comboBox_meals.ValueMember = "_name";

            updateDay();
        }
        #endregion

        #region UI updates
        private void updateDay()
        {
            output.Clear();
            output.AppendText(_day.ToString() + "\n\n");
            label_title.Text = $"DAY: {_day._date.ToString("dd/MM/yyyy")}";
            label_subtitle.Text=_day._note.ToStringInfo();
            textBox_activ.Text = _day._activ;
            this.Update();
        }
        protected override bool ProcessTabKey(bool forward)
        {
            switch(this.ActiveControl.Name)
            {
                case "textBox_amount":
                    textBox_searchFood.Focus();
                    return true;
                case "textBox_searchFood":
                    textBox_amount.Focus();
                    return true;
                case "textBox_pattern":
                    return true;
                case "textBox_protein":
                    comboBox_measure.Focus();
                    return true;
                case "comboBox_measure":
                    textBox_foodName.Focus();
                    return true;
                default:
                    return base.ProcessTabKey(forward);
            }
        }
        private void listBox_foodItems_SelectedValueChanged(object sender, EventArgs e)
        {
            FoodItem selFood = (FoodItem)listBox_foodItems.SelectedItem;
            comboBox_measure.SelectedIndex = (int)selFood._measure;
            textBox_amount.Text = selFood._measure == Measure.Pieces ? "1" : "100";
            textBox_foodName.Text = selFood._name;
            textBox_brand.Text = selFood._brand;
            textBox_fat.Text = selFood._fat.ToString();
            textBox_carbs.Text = selFood._carbs.ToString();
            textBox_protein.Text = selFood._protein.ToString();
        }
        private void comboBox_meals_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox_meals.SelectedItem == null)
            {
                textBox_noteMealScore.Clear();
                textBox_noteMealText.Clear();
                button_addFood.Enabled = false;
                button_setMealNote.Enabled = false;
                textBox_amount.ReadOnly = true;
                textBox_searchFood.ReadOnly = true;
                button_setMealPortion.Enabled = false;
            }
            else
            {
                textBox_noteMealScore.Text = (comboBox_meals.SelectedItem as MealEntry)._note._grade;
                textBox_noteMealText.Text= (comboBox_meals.SelectedItem as MealEntry)._note._text;
                button_addFood.Enabled = true;
                button_setMealNote.Enabled = true;
                textBox_amount.ReadOnly = false;
                textBox_searchFood.ReadOnly = false;
                button_setMealPortion.Enabled = true;
            }
        }
        #endregion

        #region Buttons
        private void button_setActiv_Click(object sender, EventArgs e)
        {
            if (MainForm.regexDayActiv.IsMatch(textBox_activ.Text))
            {
                _day._activ = textBox_activ.Text;
                updateDay();
            }
            else
            {
                MessageBox.Show("Invalid Activity!");
                textBox_activ.Text = _day._activ;
            }
        }
        private void button_addNote_Click(object sender, EventArgs e)
        {
            _day._note = new Note(textBox_noteScore.Text, textBox_noteText.Text);
            updateDay();
        }
        private void button_setMealNote_Click(object sender, EventArgs e)
        {
            ((MealEntry)comboBox_meals.SelectedItem)._note = new Note(textBox_noteMealScore.Text, textBox_noteMealText.Text);
            updateDay();
        }
        private void button_setMealPortion_Click(object sender, EventArgs e)
        {
            (comboBox_meals.SelectedItem as MealEntry)._portion = Convert.ToDouble(textBox_portion.Text);
            updateDay();
        }
        private void button_addMeal_Click(object sender, EventArgs e)
        {
            _day.addMealEntry(new MealEntry());
            _day._mealEntries.Last()._note = new Note(textBox_noteMealScore.Text, textBox_noteMealText.Text);
            _day._mealEntries.Last()._name = "Meal" + _day._mealEntries.Count;
            _day._mealEntries.Last()._portion = Convert.ToDouble(textBox_portion.Text);
            ((BindingSource)comboBox_meals.DataSource).ResetBindings(false);
            comboBox_meals.SelectedItem = _day._mealEntries.Last();
            if (!button_setMealNote.Enabled) button_setMealNote.Enabled = true;
            if (!button_setMealPortion.Enabled) button_setMealPortion.Enabled = true;

            updateDay();
        }
        private void button_addFood_Click(object sender, EventArgs e)
        {
            if (textBox_amount.Text == "")
            {
                MessageBox.Show("Needs Amount!");
                return;
            }
            FoodItem food = null;
            if (radio_list.Checked)
            {
                food = (FoodItem)listBox_foodItems.SelectedItem;
                if (food != null)
                    _day._mealEntries[comboBox_meals.SelectedIndex].addFoodEntry(new FoodEntry(food, Convert.ToDouble(textBox_amount.Text)));
                else
                    MessageBox.Show("Invalid Selection for Food!");
                textBox_amount.Clear();
                textBox_searchFood.Clear();
                textBox_searchFood.Focus();
            }
            else if (radio_pattern.Checked)
            {
                if (MainForm.regexEntry.Match(textBox_pattern.Text).Success)
                {
                    _day._mealEntries[comboBox_meals.SelectedIndex].addFoodEntry(new FoodEntry(textBox_pattern.Text));
                    food = _day._mealEntries[comboBox_meals.SelectedIndex]._foodEntries.Last()._food;
                }
                else
                    MessageBox.Show("Invalid Pattern for Food!");
                textBox_pattern.Clear();
                textBox_pattern.Focus();
            }
            else
            {
                try
                {
                    food = new FoodItem(textBox_foodName.Text, textBox_brand.Text,
                        Convert.ToDouble(textBox_fat.Text), Convert.ToDouble(textBox_carbs.Text), Convert.ToDouble(textBox_protein.Text),
                        (Measure)comboBox_measure.SelectedIndex);
                    _day._mealEntries[comboBox_meals.SelectedIndex].addFoodEntry(new FoodEntry(food, Convert.ToDouble(textBox_amount.Text)));
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Invalid Entry Values! {ex.Message}");
                }
                textBox_foodName.Clear();
                textBox_brand.Clear();
                textBox_fat.Clear();
                textBox_carbs.Clear();
                textBox_protein.Clear();
                textBox_foodName.Focus();
            }

            if ( food != null)
            {
                ((MealEntry)comboBox_meals.SelectedItem).checkAndCorrect();
                _day.checkAndCorrect();
                ((BindingSource)comboBox_meals.DataSource).ResetBindings(false);
            }
            updateDay();
        }
        private void button_search_Click(object sender, EventArgs e)
        {
            listBox_foodItems.Items.Clear();
            foreach (FoodItem food in MainForm.Foods)
                if ((food._name + " " + food._brand).ToLower().Contains(textBox_searchFood.Text.ToLower()))
                    listBox_foodItems.Items.Add(food);
            if (listBox_foodItems.Items.Count != 0)
                listBox_foodItems.SetSelected(0, true);
        }
        private void button_commit_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < MainForm.Days.Count && MainForm.Days[i]._date < _day._date)
                i++;
            if (i < MainForm.Days.Count && _day._date == MainForm.Days[i]._date)
                MainForm.Days[i] = _day;
            else
                MainForm.Days.Insert(i, _day);

            Close();
        }
        #endregion

        #region Radio
        private void radio_list_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_list.Checked)
            {
                textBox_searchFood.ReadOnly = false;
                listBox_foodItems.Enabled = true;
            }
            else
            {
                textBox_searchFood.ReadOnly = true; ;
                listBox_foodItems.Enabled = false;
            }
        }
        private void radio_pattern_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_pattern.Checked)
            {
                textBox_pattern.ReadOnly = false;
                textBox_amount.ReadOnly = true;
            }
            else
            {
                textBox_pattern.ReadOnly = true;
                textBox_amount.ReadOnly = false;
            }
        }
        private void radio_Values_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_Values.Checked)
            {
                textBox_foodName.ReadOnly = false;
                textBox_brand.ReadOnly = false;
                textBox_fat.ReadOnly = false;
                textBox_carbs.ReadOnly = false;
                textBox_protein.ReadOnly = false;
                comboBox_measure.Enabled = true;
            }
            else
            {
                textBox_foodName.ReadOnly = true;
                textBox_brand.ReadOnly = true;
                textBox_fat.ReadOnly = true;
                textBox_carbs.ReadOnly = true;
                textBox_protein.ReadOnly = true;
                comboBox_measure.Enabled = false;
            }
        }
        #endregion

        #region KeyPress&TextChange Checks
        private void checkNumberPasted(tbpaste tb)
        {
            if (tb.pasted)
            {
                if (!MainForm.regexNumberValue.IsMatch(tb.Text))
                {
                    MessageBox.Show($"Invalid value pasted for {tb.Name} - Not a valid Number!");
                    tb.pasted = false;
                    tb.dot = false;
                    tb.Clear();
                    return;
                }
                tb.pasted = false;
            }
            if (tb.Text.Contains('.'))
                tb.dot = true;
            else
                tb.dot = false;
        }
        private void checkNotePasted(tbpaste tb)
        {
            if (tb.pasted)
            {
                if (!new Regex(@"^[~\+\-]+$").IsMatch(tb.Text))
                {
                    MessageBox.Show($"Invalid value pasted for {tb.Name} - Not a valid Score!");
                    tb.pasted = false;
                    tb.Clear();
                    return;
                }
                tb.pasted = false;
            }
        }
        private void foodEnter(KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button_addFood.PerformClick();
                e.Handled = true;
            }
            else e.Handled = false;
        }
        private void foodEnterOrNr(tbpaste tb, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button_addFood.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
                if (tb.dot)
                    e.Handled = true;
                else
                {
                    e.Handled = false;
                    tb.dot = true;
                }
            else if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void noteEnter(KeyPressEventArgs e)
        {
            if (new List<char> { '-', '+', '~' }.Contains(e.KeyChar) || Char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textBox_noteScore_KeyPress(object sender, KeyPressEventArgs e) => noteEnter(e);
        private void textBox_noteMealScore_KeyPress(object sender, KeyPressEventArgs e) => noteEnter(e);
        private void textBox_portion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button_setMealPortion.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
                if (textBox_portion.dot)
                    e.Handled = true;
                else
                {
                    e.Handled = false;
                    textBox_portion.dot = true;
                }
            else if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textBox_amount_KeyPress(object sender, KeyPressEventArgs e) => foodEnterOrNr(textBox_amount, e);
        private void textBox_searchFood_KeyPress(object sender, KeyPressEventArgs e) => foodEnter(e);
        private void textBox_searchFood_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                //output.AppendText("UP");
                if (listBox_foodItems.SelectedIndex > 0) listBox_foodItems.SelectedIndex -= 1;
            }
            else if (e.KeyData == Keys.Down)
            {
                //output.AppendText("DOWN");
                if (listBox_foodItems.SelectedIndex != listBox_foodItems.Items.Count - 1) listBox_foodItems.SelectedIndex += 1;
            }
        }
        private void textBox_pattern_KeyPress(object sender, KeyPressEventArgs e) => foodEnter(e);
        private void textBox_foodName_KeyPress(object sender, KeyPressEventArgs e) => foodEnter(e);
        private void textBox_brand_KeyPress(object sender, KeyPressEventArgs e) => foodEnter(e);
        private void textBox_fat_KeyPress(object sender, KeyPressEventArgs e) => foodEnterOrNr(textBox_fat, e);
        private void textBox_carbs_KeyPress(object sender, KeyPressEventArgs e) => foodEnterOrNr(textBox_carbs, e);
        private void textBox_protein_KeyPress(object sender, KeyPressEventArgs e) => foodEnterOrNr(textBox_protein, e);

        private void textBox_amount_TextChanged(object sender, EventArgs e) => checkNumberPasted(textBox_amount);
        private void textBox_searchFood_TextChanged(object sender, EventArgs e) => button_search.PerformClick();
        private void textBox_fat_TextChanged(object sender, EventArgs e) => checkNumberPasted(textBox_fat);
        private void textBox_carbs_TextChanged(object sender, EventArgs e) => checkNumberPasted(textBox_carbs);
        private void textBox_protein_TextChanged(object sender, EventArgs e) => checkNumberPasted(textBox_protein);
        private void textBox_noteScore_TextChanged(object sender, EventArgs e) => checkNotePasted(textBox_noteScore);
        private void textBox_noteMealScore_TextChanged(object sender, EventArgs e) => checkNotePasted(textBox_noteMealScore);
        private void textBox_portion_TextChanged(object sender, EventArgs e) => checkNumberPasted(textBox_portion);
        #endregion

        private void button_WTF_Click(object sender, EventArgs e)
        {
            output.AppendText($"TESTING...");
            Stopwatch timer = Stopwatch.StartNew();

            timer.Stop();
            output.AppendText($"\n...DONE! ({timer.Elapsed})\n");
        }
    }
}
