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
    public partial class MainForm : Form    //the Main Windows Form that shows up upon executing the program
    {
        #region Fields
        //various constant regexes used to match and manipulated text data when init or processing text files with groups for identifying specific values
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
        public static readonly Regex regexDishResult = new Regex(
            @"^\>===(?<Amount>\d+(g\b|ml\b|\b)) (?<Name>[^@]+) (@(?<Brand>.+) )?(?<Macros>[\d\.]{1,4}/[\d\.]{1,4}/[\d\.]{1,4}$)");

        public static List<FoodItem> Foods;     //global list of all Food Items(dishes included) found in current program state
        public static List<DayEntry> Days;      //global list of all Day Entries found in current program state
        #endregion

        #region Constructor
        public MainForm()   //init list and components
        {
            InitializeComponent();
            Foods = new List<FoodItem>();
            Days = new List<DayEntry>();
            DBCommands.loadDefaults();  //load default DB values for DBHelper use
        }
        #endregion

        #region Extra private stuff
        private String prepLine(String rawLine)     //function used to get rid of Word format stuff
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
        private bool testFoodDupMacro(FoodItem newf, ref FoodItem dbf)  //function used to compare macro values of foods with same name
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
        private IEnumerable<DateTime> getDays() //gets collection of dates inbetween selected calendar dates
        {
            for (DateTime date = calendar.SelectionStart; date <= calendar.SelectionEnd; date = date.AddDays(1))
                yield return date;
        }
        #endregion

        #region Button Presses - UI&File
        private void button_findFile_Click(object sender, EventArgs e)      //opens file dialog to search for text files
        {
            openFileDialog_dbtextfile.ShowDialog();
            textBox_filepath.Text = openFileDialog_dbtextfile.FileName;
        }
        private void button_writeFile_Click(object sender, EventArgs e)     //open&Write the current program state data into a text file(with textBox_filepath filename)
        {
            output.AppendText($"Writing to file: {textBox_filepath.Text} ...");
            Stopwatch timer = Stopwatch.StartNew();

            StreamWriter writer = new StreamWriter(textBox_filepath.Text);
            foreach (FoodItem food in Foods)
                if(food is Dish)
                    writer.Write((food as Dish).ToStringFull() + "\n\n");
            foreach (DayEntry day in Days)
                writer.Write(day + "\n\n");
            writer.WriteLine("LOOOOOOOOOOOL!!!");
            writer.Close();

            timer.Stop();
            output.AppendText($"\n...DONE! ({timer.Elapsed})\n");
        }
        private void button_processFile_Click(object sender, EventArgs e)   //open&Read a text file line by line, matchs regex and loads all present info into program state
        {
            StreamReader reader = new StreamReader(textBox_filepath.Text);
            output.AppendText($"Processing file: {textBox_filepath.Text} ...");
            output.Update();

            Days = new List<DayEntry>();        //reinit to get rid of old state
            Foods = new List<FoodItem>();

            Stopwatch timer = Stopwatch.StartNew(); //test performance

            String line;        //current line
            Match m;            //current regex match for line

            List<FoodEntry> lfe = new List<FoodEntry>();    //list of Food entries to be init for next MealEntry
            List<MealEntry> lme = new List<MealEntry>();    //list of Meal entries to be init for next DatEntry
            FoodEntry fe = null;                            //current FoodEntry found
            String activ = "";                              //helps set activity for current DayEntry

            while ((line = reader.ReadLine()) != null)      //go through all lines in text file
            {
                //line = prepLine(line);

                if ((m = regexEntry.Match(line)).Success)   //matches (1st line)of a Food Entry format: 11g name brand 11/11/11
                {
                    fe = new FoodEntry(m);
                    lfe.Add(fe);
                    if (!Foods.Contains(fe._food))
                        Foods.Add(fe._food);

                    //output.AppendText(line + " <----- ENTRY\n");
                }
                else if ((m = regexEntryResult.Match(line)).Success)    //matches (2nd line)result macro values of a Food Entry format: =11/11/11
                {
                    fe.setEntryMacros(m.Groups["Macros"].Value);

                    //output.AppendText(line + " <----- ERESULT\n");
                }
                else if ((m = regexMealResult.Match(line)).Success)     //matches MealEntry values after the Food list format: ===1==111//11//11 +-(desc)
                {
                    lme.Add(new MealEntry(lfe, m));
                    lfe = new List<FoodEntry>();

                    //output.AppendText(line + " <----- MEAL\n");
                }
                else if ((m = regexDayResult.Match(line)).Success)      //matches DayEntry values after the Meal list format: 22/11/2020--->111||111||111 +-(desc)
                {
                    Days.Add(new DayEntry(lme, m));
                    Days[Days.Count - 1].setActiv(activ);
                    lme = new List<MealEntry>();
                    activ = "";

                    //output.AppendText(line + " <----- DAY\n");
                }
                else if ((m = regexDayActiv.Match(line)).Success)       //matches activity for current format: +SALA or +EXS
                {
                    activ = m.Groups["Activ"].Value;

                    //output.AppendText(line + " <----- ACTIV\n");
                }
                else if ((m = regexDishResult.Match(line)).Success)        //matches Dish definition values after the food list format: >===1 Pizza @eu 11/11/11
                {
                    Foods.Add(new Dish(lfe, m));
                    lfe = new List<FoodEntry>();

                    //output.AppendText(line + " <----- DISH\n");
                }
            }
            reader.Close();

            Foods.Sort((x, y) => (x._name + x._brand).CompareTo(y._name + y._brand));       //sorts the Foods list alphabetically by Name and Brand

            timer.Stop();
            output.AppendText($"\n...DONE! ({timer.Elapsed})\n");   //prints time required to do to output
            button_intoDB.Enabled = true;                           //enables loading data to Database
        }
        private void button_seeMealsDay_Click(object sender, EventArgs e)   //print to output the meals in days from selected calendar range
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
        private void button_addDay_Click(object sender, EventArgs e)        //opens the add/see day form
        {
            AddDayForm addF = new AddDayForm(calendar.SelectionStart);
            addF.ShowDialog();
        }
        private void button_searchFood_Click(object sender, EventArgs e)    //searches food item in Foods list to match search term from searchFood textbox - not case sensitive
        {
            output.AppendText("\nFood Items matching Search:\n");
            foreach (FoodItem food in Foods)
                if (food._name.ToLower().Contains(textBox_searchFood.Text.ToLower()) || food._brand.ToLower().Contains(textBox_searchFood.Text.ToLower()))
                    output.AppendText(food is Dish ? (food as Dish).ToStringListed() : food.ToStringNice() + "\n\n");
        }
        private void button_seeAllFoodItems_Click(object sender, EventArgs e)   //prints all items in Foods list to output
        {
            output.AppendText("\nAll Currect Food Items:\n\n");
            foreach (FoodItem food in Foods)
                output.AppendText(food is Dish ? (food as Dish).ToStringListed(): food.ToStringNice() + "\n\n");
        }
        private void button_clear_Click(object sender, EventArgs e)     //clears output of text
        {
            output.Clear();
        }
        #endregion

        #region Button Presses - DB stuff
        private void button_LoadIntoDB_Click(object sender, EventArgs e)    //loads all the currect program state data(Foods and Days) into Database
        {
            output.AppendText($"Inserting Foods and Day Entries into DataBase...\n");
            output.Update();
            Stopwatch timer = Stopwatch.StartNew();

            output.AppendText("\nInsert FoodItems Affected:" + DBCommands.InsertFoodItems(Foods));  //prints to output all DB rows affected/called relating to Foods
            output.AppendText("\nInsert Days Affected: " + DBCommands.InsertDays(Days));            //prints to output all DB rows affected/called relating to Days

            timer.Stop();
            output.AppendText($"\n...DONE! ({timer.Elapsed})\n");
        }
        private void button_GetFromDB_Click(object sender, EventArgs e)     //loads from Database all data into program state data(Foods and Days)
        {
            output.AppendText($"Loading Entries from DataBase...");
            output.Update();
            Stopwatch timer = Stopwatch.StartNew();

            Foods = new List<FoodItem>();
            Days = new List<DayEntry>();

            output.AppendText($"Meal Entry Affected:{DBCommands.SelectDayEntriesAll()}\n");     //prints to output all DB rows affected/called

            timer.Stop();
            output.AppendText($"\n...DONE! ({timer.Elapsed})\n");
            button_intoDB.Enabled = true;                           //enables loading data to Database
        }
        private void buttonPeriodFromDB_Click(object sender, EventArgs e)   //loads from Database data program state data(Foods and Days) from selected calendar range
        {
            output.AppendText($"TESTING...\n");
            Stopwatch timer = Stopwatch.StartNew();

            Days = DBCommands.SelectDayEntries(calendar.SelectionStart, calendar.SelectionEnd, out int x);
            output.AppendText($"Meal Entry Affected:{x}\n");

            timer.Stop();
            output.AppendText($"\n...DONE! ({timer.Elapsed})\n");
        }
        #endregion

        #region Global operations
        public static void insertOrRefFood(ref FoodItem food)  //inserts in ordered way food into Foods if it's New Or references item in Foods if it Already Exists
        {
            if (food != null)
            {
                if (Foods.Count == 0 || food > Foods.Last())    //if food is bigger(alphabetically) to last Item in Foods
                    Foods.Add(food);
                else
                {
                    for (int i = 0; i < Foods.Count; i++)
                    {
                        if (Foods[i] < food) continue;          //keep searching to find index while food is smaller than current index
                        if (Foods[i] == food)                   //if the Same food is found in list references food given to the one in the list
                        {
                            food = Foods[i];
                            break;
                        }
                        if (Foods[i] > food)                    //if food passed the index where it would have to be(but isn't), it inserts it there
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
        public static void setCalculatedValuesAll()         //calls setCalculatedValues() for ALL types of Entries(Food, Meal, Day) - essentially correct any user calculation mistakes
        {
            foreach (DayEntry de in Days)
            {
                foreach (MealEntry me in de._mealEntries)
                {
                    foreach (FoodEntry fe in me._foodEntries)
                        fe.setCalculatedValues();
                    me.setCalculatedValues();
                }
                de.setCalculatedValues();
            }
        }
        #endregion

        #region Tests
        private void button_processFile_Click_TESTIndex(object sender, EventArgs e)         //old function testing processing performace by trying an index method
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
        private void button_processFile_Click_TESTLast(object sender, EventArgs e)          //old function testing processing performace by trying a Last() method
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

        private void button_WTF_Click(object sender, EventArgs e)       //testing whatever stuff comes to mind
        {
            output.AppendText($"TESTING...\n");
            Stopwatch timer = Stopwatch.StartNew();


            timer.Stop();
            output.AppendText($"\n...DONE! ({timer.Elapsed})\n");
        }
    }
}