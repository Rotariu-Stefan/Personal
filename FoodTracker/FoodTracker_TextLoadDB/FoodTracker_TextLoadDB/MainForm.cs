using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Data.SqlClient;

namespace FoodTracker_TextLoadDB
{
    public partial class MainForm : Form
    {
        #region Fields
        public static readonly Regex regexEntry = new Regex(
            @"(?<Amount>^\d+([\./]{1}\d+)?(g\b|ml\b|\b)) (?<Name>[^@]+) (@(?<Brand>.+) )?(?<Macros>[\d\.]{1,4}/[\d\.]{1,4}/[\d\.]{1,4}$)");
        public static readonly Regex regexEntryResult = new Regex(
            @"^=(?<Macros>[\d\.]{1,5}/[\d\.]{1,5}/[\d\.]{1,5}$)");
        public static readonly Regex regexMealResult = new Regex(
            @"^(?<Name>.*)(?<Portion>(=====)|(===(\d+/\d+|[\d\.]+)==))(?<Macros>[\d\.]{1,5}//[\d\.]{1,5}//[\d\.]{1,5}) ?(?<Note>([~\+\-]+)?(\(.*\))?$)?");
        public static readonly Regex regexDayResult = new Regex(
            @"(?<Date>^\d\d/\d\d/\d{4})\-\-\-\>(?<Macros>[\d\.]{1,5}\|\|[\d\.]{1,5}\|\|[\d\.]{1,5}) ?(?<Note>([~\+\-]+)?(\(.*\))?$)?");
        public static readonly Regex regexDayActiv = new Regex(
            @"(?<Activ>^((\+SALA)|(\+SAUNA)|(\+EXS))+)$");
        public static readonly Regex regexDayEnd = new Regex(
            @"^\-{3,}$");
        public static readonly Regex regexNumberValue = new Regex(
            @"^\d+([\./]{1}\d+)?$");

        public static List<FoodItem> Foods;
        public static List<DayEntry> Days;
        #endregion

        #region Constructor
        public MainForm()
        {
            InitializeComponent();
            Foods = new List<FoodItem>();
            Days = new List<DayEntry>();
        }
        #endregion

        #region Extra private stuff
        private String prepLine(String rawLine)
        {
            String line = rawLine;
            line = line.Replace(@"\par", "");
            line = line.Replace(@"\b0", "");
            line = line.Replace(@"\b", "");
            line = line.Replace(@"\i0", "");
            line = line.Replace(@"\i", "");
            line = line.Replace(@"\ulnone", "");
            line = line.Replace(@"\ul", "");
            line = line.Trim();
            return line;
        }
        private bool testFoodDupMacro(FoodItem newf, ref FoodItem dbf)
        {
            foreach (FoodItem f in Foods)
                if (newf == f)
                    if (f._fat != newf._fat || f._carbs != newf._carbs || f._protein != newf._protein)
                    {
                        dbf = f;
                        return true;
                    }
                    else
                        return false;
            return false;
        }
        private IEnumerable<DateTime> getDays()
        {
            for (DateTime date = calendar.SelectionStart; date <= calendar.SelectionEnd; date = date.AddDays(1))
                yield return date;
        }
        #endregion

        #region Button Presses
        private void button_findFile_Click(object sender, EventArgs e)
        {
            openFileDialog_dbtextfile.ShowDialog();
            textBox_filepath.Text = openFileDialog_dbtextfile.FileName;
        }
        private void button_writeFile_Click(object sender, EventArgs e)
        {
            output.AppendText($"Writing to file: {textBox_filepath.Text} ...");
            Stopwatch timer = Stopwatch.StartNew();

            StreamWriter writer = new StreamWriter(textBox_filepath.Text);
            foreach (DayEntry day in Days)
                writer.Write(day + "\n\n");
            writer.WriteLine("LOOOOOOOOOOOL!!!");
            writer.Close();

            timer.Stop();
            output.AppendText($"\n...DONE! ({timer.Elapsed})\n");
        }
        private void button_processFile_Click(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader(textBox_filepath.Text);
            output.AppendText($"Processing file: {textBox_filepath.Text} ...");
            output.Update();

            Days = new List<DayEntry>();
            Foods = new List<FoodItem>();

            Stopwatch timer = Stopwatch.StartNew();

            String line;
            Match m;

            List<FoodEntry> lfe = new List<FoodEntry>();
            List<MealEntry> lme = new List<MealEntry>();
            FoodEntry fe = null;
            String activ = "";

            while ((line = reader.ReadLine()) != null)
            {
                //line = prepLine(line);

                if ((m = regexEntry.Match(line)).Success)
                {
                    fe = new FoodEntry(m);
                    lfe.Add(fe);
                    if (!Foods.Contains(fe._food))
                        Foods.Add(fe._food);

                    //richTextBox_output.AppendText(line + " <----- ENTRY\n");
                }
                else if ((m = regexEntryResult.Match(line)).Success)
                {
                    fe.setEntryMacros(m.Groups["Macros"].Value);

                    //richTextBox_output.AppendText(line + " <----- ERESULT\n");
                }
                else if ((m = regexMealResult.Match(line)).Success)
                {
                    lme.Add(new MealEntry(lfe, m));
                    lfe = new List<FoodEntry>();

                    //richTextBox_output.AppendText(line + " <----- MEAL\n");
                }
                else if ((m = regexDayResult.Match(line)).Success)
                {
                    Days.Add(new DayEntry(lme, m));
                    Days[Days.Count - 1].setActiv(activ);
                    lme = new List<MealEntry>();
                    activ = "";

                    //richTextBox_output.AppendText(line + " <----- DAY\n");
                }
                else if ((m = regexDayActiv.Match(line)).Success)
                {
                    activ = m.Groups["Activ"].Value;

                    //richTextBox_output.AppendText(line + " <----- ACTIV\n");
                }
            }
            reader.Close();

            Foods.Sort((x, y) => (x._name + x._brand).CompareTo(y._name + y._brand));

            timer.Stop();
            output.AppendText($"\n...DONE! ({timer.Elapsed})\n");
            button_intoDB.Enabled = true;
        }
        private void button_seeMealsDay_Click(object sender, EventArgs e)
        {
            output.AppendText($"\nDay Entries for selected period {calendar.SelectionStart.ToString("dd/MM/yyyy")} " +
                $"- {calendar.SelectionEnd.ToString("dd/MM/yyyy")} :\n\n");
            foreach (DayEntry day in Days)
            {
                if (day._date < calendar.SelectionStart)
                    continue;
                if (day._date <= calendar.SelectionEnd)
                    output.AppendText(day + "\n\n");
                else
                    break;
            }
        }
        private void button_addDay_Click(object sender, EventArgs e)
        {
            AddDayForm addF = new AddDayForm(calendar.SelectionStart);
            addF.ShowDialog();
        }
        private void button_searchFood_Click(object sender, EventArgs e)
        {
            output.AppendText("\nFood Items matching Search:\n");
            foreach (FoodItem food in Foods)
                if (food._name.Contains(textBox_searchFood.Text) || food._brand.Contains(textBox_searchFood.Text))
                    output.AppendText(food.ToStringNice() + "\n\n");
        }
        private void button_seeAllFoodItems_Click(object sender, EventArgs e)
        {
            output.AppendText("\nAll Currect Food Items:\n\n");
            foreach (FoodItem food in Foods)
                output.AppendText(food.ToStringNice() + "\n\n");
        }
        private void button_clear_Click(object sender, EventArgs e)
        {
            output.Clear();
        }
        #endregion

        #region Global operations
        public static void insertOrRefFood(ref FoodItem food)  //inserts food into Foods if it's New Or references item in Foods if it Already Exists
        {
            if (food != null)
            {
                if (Foods.Count == 0 || food > Foods.Last())
                    Foods.Add(food);
                else
                {
                    for (int i = 0; i < Foods.Count; i++)
                    {
                        if (Foods[i] < food) continue;
                        if (Foods[i] == food)
                        {
                            food = Foods[i];
                            break;
                        }
                        if (Foods[i] > food)
                        {
                            Foods.Insert(i, food);
                            break;
                        }
                    }
                }
            }
            else
                MessageBox.Show("Will not accept Null Food Item!");
        }
        public static void checkAndCorrectALL()
        {
            foreach (DayEntry de in Days)
            {
                foreach (MealEntry me in de._mealEntries)
                {
                    foreach (FoodEntry fe in me._foodEntries)
                        fe.checkAndCorrect();
                    me.checkAndCorrect();
                }
                de.checkAndCorrect();
            }
        }
        #endregion


        #region Tests
        private void button_processFile_Click_TESTIndex(object sender, EventArgs e)
        {
            Days = new List<DayEntry>();
            Foods = new List<FoodItem>();

            StreamReader reader = new StreamReader(textBox_filepath.Text);
            output.AppendText($"Processing file: {textBox_filepath.Text} ...");
            output.Update();

            Stopwatch timer = Stopwatch.StartNew();

            String line;
            Match m;
            int iday = 0;
            int imeal = 0;
            int ife = 0;

            Days.Add(new DayEntry());
            Days[iday].addMealEntry(new MealEntry());
            while ((line = reader.ReadLine()) != null)
            {
                //line = prepLine(line);

                if ((m = regexEntry.Match(line)).Success)
                {
                    Days[iday]._mealEntries[imeal].addFoodEntry(m);
                    if (!Foods.Contains(Days[iday]._mealEntries[imeal]._foodEntries[ife]._food))
                        Foods.Add(Days[iday]._mealEntries[imeal]._foodEntries[ife]._food);

                    //richTextBox_output.AppendText(line + " <----- ENTRY\n");
                }
                else if ((m = regexEntryResult.Match(line)).Success)
                {
                    Days[iday]._mealEntries[imeal]._foodEntries[ife].setEntryMacros(m.Groups["Macros"].Value);
                    ife++;

                    //richTextBox_output.AppendText(line + " <----- ERESULT\n");
                }
                else if ((m = regexMealResult.Match(line)).Success)
                {
                    Days[iday]._mealEntries[imeal].setMatchValues(m);
                    Days[iday].addMealEntry(new MealEntry());
                    ife = 0;
                    imeal++;

                    //richTextBox_output.AppendText(line + " <----- MEAL\n");
                }
                else if ((m = regexDayResult.Match(line)).Success)
                {
                    Days[iday].setMatchValues(m);
                    Days.Add(new DayEntry());
                    iday++;
                    Days[iday].addMealEntry(new MealEntry());
                    imeal = 0;

                    //richTextBox_output.AppendText(line + " <----- DAY\n");
                }
                else if ((m = regexDayActiv.Match(line)).Success)
                {
                    Days[iday].setActiv(m.Groups["Activ"].Value);

                    //richTextBox_output.AppendText(line + " <----- ACTIV\n");
                }
            }
            reader.Close();

            timer.Stop();
            output.AppendText($"\n...DONE! ({timer.Elapsed})\n");
        }
        private void button_processFile_Click_TESTLast(object sender, EventArgs e)
        {
            Days = new List<DayEntry>();
            Foods = new List<FoodItem>();

            StreamReader reader = new StreamReader(textBox_filepath.Text);
            output.AppendText($"Processing file: {textBox_filepath.Text} ...");
            output.Update();

            Stopwatch timer = Stopwatch.StartNew();

            String line;
            Match m;

            Days.Add(new DayEntry());
            Days.Last().addMealEntry(new MealEntry());
            while ((line = reader.ReadLine()) != null)
            {
                //line = prepLine(line);

                if ((m = regexEntry.Match(line)).Success)
                {
                    Days.Last()._mealEntries.Last().addFoodEntry(m);
                    if (!Foods.Contains(Days.Last()._mealEntries.Last()._foodEntries.Last()._food))
                        Foods.Add(Days.Last()._mealEntries.Last()._foodEntries.Last()._food);

                    //richTextBox_output.AppendText(line + " <----- ENTRY\n");
                }
                else if ((m = regexEntryResult.Match(line)).Success)
                {
                    Days.Last()._mealEntries.Last()._foodEntries[Days.Last()._mealEntries.Last()._foodEntries.Count - 1]
                        .setEntryMacros(m.Groups["Macros"].Value);

                    //richTextBox_output.AppendText(line + " <----- ERESULT\n");
                }
                else if ((m = regexMealResult.Match(line)).Success)
                {
                    Days.Last()._mealEntries.Last().setMatchValues(m);
                    Days.Last().addMealEntry(new MealEntry());

                    //richTextBox_output.AppendText(line + " <----- MEAL\n");
                }
                else if ((m = regexDayResult.Match(line)).Success)
                {
                    Days.Last().setMatchValues(m);
                    Days.Add(new DayEntry());
                    Days.Last().addMealEntry(new MealEntry());

                    //richTextBox_output.AppendText(line + " <----- DAY\n");
                }
                else if ((m = regexDayActiv.Match(line)).Success)
                {
                    Days.Last().setActiv(m.Groups["Activ"].Value);

                    //richTextBox_output.AppendText(line + " <----- ACTIV\n");
                }
            }
            reader.Close();

            timer.Stop();
            output.AppendText($"\n...DONE! ({timer.Elapsed})\n");
        }
        #endregion

        private void button_WTF_Click(object sender, EventArgs e)
        {
            output.AppendText($"TESTING...\n");
            Stopwatch timer = Stopwatch.StartNew();
            
            Days=DBCommands.SelectDayEntries(calendar.SelectionStart, calendar.SelectionEnd, out int x);
            output.AppendText($"Meal Entry Affected:{x}\n");

            timer.Stop();
            output.AppendText($"\n...DONE! ({timer.Elapsed})\n");
        }

        private void button_LoadIntoDB_Click(object sender, EventArgs e)
        {
            output.AppendText($"Inserting Foods and Day Entries into DataBase...\n");
            output.Update();
            Stopwatch timer = Stopwatch.StartNew();

            output.AppendText("\nInsert FoodItems Affected:" + DBCommands.InsertFoodItems(Foods));
            output.AppendText("\nInsert Days Affected: " + DBCommands.InsertDays(Days));

            timer.Stop();
            output.AppendText($"\n...DONE! ({timer.Elapsed})\n");
        }

        private void button_GetFromDB_Click(object sender, EventArgs e)
        {
            output.AppendText($"Loading Entries from DataBase...");
            output.Update();
            Stopwatch timer = Stopwatch.StartNew();

            Foods = new List<FoodItem>();
            Days = new List<DayEntry>();

            output.AppendText($"Meal Entry Affected:{DBCommands.SelectIntoDaysAll()}\n");

            timer.Stop();
            output.AppendText($"\n...DONE! ({timer.Elapsed})\n");
        }
    }
}