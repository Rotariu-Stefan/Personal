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
    public partial class AddDayForm : Form      //form used to see/add/change Day Entries and all pertaining data in program state
    {
        DayEntry _day;          //current day state being viewed/modified - commit adds this
        List<DayEntry> _daysPrevious;   //previous states of _day for undoing changes

        #region Constructors
        public AddDayForm()         //init new day(with Now)
        {
            InitializeComponent();

            _day = new DayEntry();
            _daysPrevious = new List<DayEntry>();

            comboBox_measure.SelectedIndex = 0;
            listBox_foodItems.Items.AddRange(MainForm.Foods.ToArray());
            listBox_foodItems.ValueMember = "ToStringLite()";
            if (listBox_foodItems.Items.Count != 0)
                listBox_foodItems.SelectedIndex = 0;
            comboBox_meals.DataSource = new BindingSource(_day._mealEntries, "");
            comboBox_meals.ValueMember = "_name";

            updateDay();
        }
        public AddDayForm(DateTime date)    //init this form using the date selected from calendar in MainForm
        {
            InitializeComponent();
            _daysPrevious = new List<DayEntry>();

            foreach (DayEntry day in MainForm.Days)     //searches for DayEntry in Days global list and clones it to set values for this _day(which is temporary until commit)
                if (day._date == date)
                {
                    _day = day.Clone();
                    break;
                }
            if (_day == null)       //creates new DayEntry to add later if not found in Days
            {
                _day = new DayEntry();
                _day._date = date;
            }
            textBox_noteScore.Text = _day._note._grade;
            textBox_noteText.Text = _day._note._text;

            comboBox_measure.SelectedIndex = 0;
            listBox_foodItems.Items.AddRange(MainForm.Foods.ToArray());     //populated listbox with items from Foods
            if (listBox_foodItems.Items.Count != 0)
                listBox_foodItems.SelectedIndex = 0;
            comboBox_meals.DataSource = new BindingSource(_day._mealEntries, "");   //populates combobox with meals from current day with bindingsource for detect changes
            comboBox_meals.ValueMember = "_name";
            if (_day._mealEntries.Count > 0)
            {
                comboBox_meals.SelectedItem = _day._mealEntries.Last();
                textBox_amount.ReadOnly = false;
                textBox_searchFood.ReadOnly = false;

            }

            updateDay();        //calls method that updates various UI things to corespond with changed data
        }
        #endregion

        #region UI updates
        private void updateDay()    //method that updates various UI elementas(Title, Activ,Output text) to corespond with changed data and saves day state for undo
        {
            output.Clear();
            output.AppendText(_day.ToString() + "\n\n");
            label_title.Text = $"DAY: {_day._date.ToString("dd/MM/yyyy")}";
            label_subtitle.Text=_day._note.ToStringInfo();
            textBox_activ.Text = _day._activ;
            this.Update();
            _daysPrevious.Add(_day.Clone());    //adds current day state to undo list
        }
        protected override bool ProcessTabKey(bool forward)     //override the Tab key press event and process it depending on the custom textbox in was detected in
        {
            switch(this.ActiveControl.Name)     //cases depending on current control
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
                    return base.ProcessTabKey(forward); //proceed as normal tab order
            }
        }
        private void listBox_foodItems_SelectedValueChanged(object sender, EventArgs e) //updates UI elements relating to selected food if listbox select changes
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
        private void comboBox_meals_SelectedValueChanged(object sender, EventArgs e)    //updates UI elements relating to selected meal if combobox select changes
        {
            if (comboBox_meals.SelectedItem == null)
            {
                textBox_noteMealScore.Clear();
                textBox_noteMealText.Clear();
                button_addFood.Enabled = false;
                button_setMealNote.Enabled = false;
                button_setMealPortion.Enabled = false;
                radio_list.Checked = true;
                textBox_amount.ReadOnly = true;
                textBox_searchFood.ReadOnly = true;                
            }
            else
            {
                textBox_noteMealScore.Text = (comboBox_meals.SelectedItem as MealEntry)._note._grade;
                textBox_noteMealText.Text= (comboBox_meals.SelectedItem as MealEntry)._note._text;
                button_addFood.Enabled = true;
                button_setMealNote.Enabled = true;
                button_setMealPortion.Enabled = true;
                radio_list.Checked = true;
            }
        }
        #endregion

        #region Buttons - Day Inner Changes
        private void button_setActiv_Click(object sender, EventArgs e)  //sets current activity from textBox_activ text
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
            updateDay();
        }
        private void button_addNote_Click(object sender, EventArgs e)   //create new Note for current day from note textboxes values
        {
            _day._note = new Note(textBox_noteScore.Text, textBox_noteText.Text);
            updateDay();
        }
        private void button_setMealNote_Click(object sender, EventArgs e)   //create new Note for current selected meal from mealnote textboxes values
        {
            ((MealEntry)comboBox_meals.SelectedItem)._note = new Note(textBox_noteMealScore.Text, textBox_noteMealText.Text);
            updateDay();
        }
        private void button_setMealPortion_Click(object sender, EventArgs e)    //sets selected meal portion
        {
            (comboBox_meals.SelectedItem as MealEntry)._portion = Convert.ToDouble(textBox_portion.Text);
            updateDay();
        }
        private void button_addMeal_Click(object sender, EventArgs e)   //adds a new meal(and selects it) for current day
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
        private void button_addFood_Click(object sender, EventArgs e)   //adds a new food(or references from Foods through the process of FoodEntry init) to selected meal
        {
            if (textBox_amount.Text == "")      //checks amount
            {
                MessageBox.Show("Needs Amount!");
                return;
            }
            FoodItem food = null;
            if (radio_list.Checked)             //adds food from the list of all foods
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
            else if (radio_pattern.Checked)     //adds food by matching a string(similar to one written file format)
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
            {                                   //adds new food by creating it with values given by user through custom textboxes
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

            if (food != null)                  //updates MealEntry and FoodEntry calculated values(does the math for macros)
            {
                ((MealEntry)comboBox_meals.SelectedItem).setCalculatedValues();
                _day.setCalculatedValues();
                //((BindingSource)comboBox_meals.DataSource).ResetBindings(false);  TODO:HUH??
            }

            updateDay();
        }
        private void button_search_Click(object sender, EventArgs e)    //search for food in Listbox by text in search textbox(automatically called for every key typed) and selects 1st results
        {
            listBox_foodItems.Items.Clear();
            foreach (FoodItem food in MainForm.Foods)
                if ((food._name + " " + food._brand).ToLower().Contains(textBox_searchFood.Text.ToLower())) //-not case sensitive
                    listBox_foodItems.Items.Add(food);
            if (listBox_foodItems.Items.Count != 0)
                listBox_foodItems.SetSelected(0, true);
        }
        #endregion

        #region Buttons - Form Changes
        private void button_commit_Click(object sender, EventArgs e)    //saves the changes into program state(into Days global list); adds new DayEntry if needed
        {
            int i = 0;
            while (i < MainForm.Days.Count && MainForm.Days[i]._date < _day._date)      //seek correct place in Days list to add the day by date(to maintain order of days)
                i++;
            if (i < MainForm.Days.Count && _day._date == MainForm.Days[i]._date)
                MainForm.Days[i] = _day;                                                //replace if found
            else
                MainForm.Days.Insert(i, _day);                                          //adds new one if not found

            Close();
        }
        private void button_cancel_Click(object sender, EventArgs e) => Close();    //closes form without comitting any changes
        private void button_undo_Click(object sender, EventArgs e)      //undo the last change made to current _day state; can revert back up to when form 1st opened(no changes)
        {   //TODO: OPTIMIZE/Figure out better way(just use list?) Later!
            if (_daysPrevious.Count > 1)
            {
                _daysPrevious.Remove(_daysPrevious.Last());         //removes last(same as current) day object from list
                _day = _daysPrevious.Last().Clone();                //sets current day as a New DayEntry object with 2nd to last values(cloning from _daysPrevious list to avoid values changing in list also because of the reference)

                comboBox_meals.DataSource = new BindingSource(_day._mealEntries, "");   //updates selected meal(in case meal get undone)
                if (_day._mealEntries.Count > 0)
                    comboBox_meals.SelectedItem = _day._mealEntries.Last();

                //resets UI values without calling updateDay() to dupe values don't show up
                output.Clear();                                                 
                output.AppendText(_day.ToString() + "\n\n");
                label_title.Text = $"DAY: {_day._date.ToString("dd/MM/yyyy")}";
                label_subtitle.Text = _day._note.ToStringInfo();
                textBox_activ.Text = _day._activ;
                this.Update();
            }
            else
                MessageBox.Show("Cannot Undo Further!");            //initial state on form open
        }
        #endregion

        #region Radio
        private void radio_list_CheckedChanged(object sender, EventArgs e)      //does some UI stuff in case List radio option de/selected
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
        private void radio_pattern_CheckedChanged(object sender, EventArgs e)   //does some UI stuff in case Pattern radio option de/selected
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
        private void radio_Values_CheckedChanged(object sender, EventArgs e)    //does some UI stuff in case Values radio option de/selected
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
        private void checkNumberPasted(tbpaste tb)      //check if Text entered(either by paste or text change in general) into custom textbox tb is a Number Format: 11 or 1/11 or 11.1
        {
            if (tb.pasted)      //checks if paste event happened in tb
            {
                if (!MainForm.regexNumberValue.IsMatch(tb.Text))    //case not a number format: resets textbox text and flags
                {
                    MessageBox.Show($"Invalid value pasted for {tb.Name} - Not a valid Number!");
                    tb.pasted = false;
                    tb.dot = false;
                    tb.Clear();
                    return;
                }
                tb.pasted = false;      //resets pasted flag if number format
            }
            if (tb.Text.Contains('.'))  //checks if dot is present(whether pasted or textchanged in general) and sets flag for that to be true to stop another dot from being typed in future (there's only 1 dot possible for number format to have)
                tb.dot = true;
            else
                tb.dot = false;
        }
        private void checkNotePasted(tbpaste tb)        //check if Text entered(either by paste or text change in general) into custom textbox tb is a Note Score Format: ~+-
        {
            if (tb.pasted)      //checks if paste event happened in tb
            {
                if (!new Regex(@"^[~\+\-]+$").IsMatch(tb.Text))     //case format is not correct: resets text and flags
                {
                    MessageBox.Show($"Invalid value pasted for {tb.Name} - Not a valid Score!");
                    tb.pasted = false;
                    tb.Clear();
                    return;
                }
                tb.pasted = false;
            }
        }
        private void foodEnter(KeyPressEventArgs e)     //handles Enter for some food related custom textboxes(shortcut so u can enter food faster)
        {
            if (e.KeyChar == 13)    //checks if Enter was typed
            {
                button_addFood.PerformClick();  //triggers addFood buttong click event
                e.Handled = true;               //sets keypress event as handled(stops whatever else was gonna happen like putting char in textbox)
            }
            else e.Handled = false;             //sets keypress event as not handled(continues to do whatever normal keypress things should happen)
        }
        private void foodEnterOrNr(tbpaste tb, KeyPressEventArgs e) //handles Enter for some food related custom textboxes(shortcut so u can enter food faster) that ALSO need to only accept Number Formats
        {
            if (e.KeyChar == 13)    //checks if Enter was typed
            {
                button_addFood.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyChar == '.')  //check if Dot was typed
                if (tb.dot)             //ignores it by setting handling event as handled If a dot already was typed/exists in tb
                    e.Handled = true;
                else
                {
                    e.Handled = false;
                    tb.dot = true;
                }
            else if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))  //checks if a Number of Control key was typed
                e.Handled = false;
            else
                e.Handled = true;   //ignores if not(like a letter etc. - chars that shouldn't be here)
        }
        private void noteEnter(KeyPressEventArgs e)     //handles key stroke events in Note Score textboxes(didn't bother with enter just click the damn button!)
        {
            if (new List<char> { '-', '+', '~' }.Contains(e.KeyChar) || Char.IsControl(e.KeyChar))  //checks characters work with note Score format
                e.Handled = false;
            else
                e.Handled = true;       //ignores if not
        }

        private void textBox_noteScore_KeyPress(object sender, KeyPressEventArgs e) => noteEnter(e);
        private void textBox_noteMealScore_KeyPress(object sender, KeyPressEventArgs e) => noteEnter(e);
        private void textBox_portion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)    //check for Enter press
            {
                button_setMealPortion.PerformClick();   //clicks set portion if true
                e.Handled = true;
            }
            else if (e.KeyChar == '.')      //check for Dot typed
                if (textBox_portion.dot)    //ignored is a dot was already typed
                    e.Handled = true;
                else
                {
                    e.Handled = false;
                    textBox_portion.dot = true;
                }
            else if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))  //check for digit of control char
                e.Handled = false;
            else
                e.Handled = true;   //ignores char if anything else
        }

        private void textBox_amount_KeyPress(object sender, KeyPressEventArgs e) => foodEnterOrNr(textBox_amount, e);
        private void textBox_searchFood_KeyPress(object sender, KeyPressEventArgs e) => foodEnter(e);
        private void textBox_searchFood_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)    //changes food selected in listBox if Up or Down typed in search custom textbox (for ease of use)
        {
            if (e.KeyData == Keys.Up)   //if up typed goes back in list
            {
                //output.AppendText("UP");
                if (listBox_foodItems.SelectedIndex > 0) listBox_foodItems.SelectedIndex -= 1;
            }
            else if (e.KeyData == Keys.Down)    //if down typed goes forward in list
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

        private void button_WTF_Click(object sender, EventArgs e)       ///tests whatever I feel like
        {
            output.AppendText($"TESTING...");
            Stopwatch timer = Stopwatch.StartNew();


            timer.Stop();
            output.AppendText($"\n...DONE! ({timer.Elapsed})\n");
        }
    }
}
