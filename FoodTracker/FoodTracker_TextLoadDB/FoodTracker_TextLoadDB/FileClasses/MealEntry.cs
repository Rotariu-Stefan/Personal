using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FoodTracker_TextLoadDB
{
    public class MealEntry      //is a Meal entry containing a list food/amount consumed in a sitting. Usually as part of a day entry
    {
        #region Fields
        public String _name     //name of the meal(is individual but can be duplicated across days)
        { get; set; }
        public List<FoodEntry> _foodEntries //list of the food entries(foods and amounts)
        { get; }
        public Note _note   //note object for extra description/effects of this particular meal
        { get; set; }
        public double _fatEntry         //given fat value for amount entered
        { get; set; }
        public double _carbsEntry       //given carbs value for amount entered
        { get; set; }
        public double _proteinEntry     //given protein value for amount entered
        { get; set; }
        public double _portion          //portion of the meal that was actually consumed
        { get; set; }
        #endregion

        #region Constructors
        public MealEntry()      //init empty meal
        {
            _name = "";
            _foodEntries = new List<FoodEntry>();
            _note = new Note();
            _portion = 1;
            _fatEntry = 0;
            _carbsEntry = 0;
            _proteinEntry = 0;
        }
        public MealEntry(List<FoodEntry> foodEntries, Note note)    //init unnamed meal, values are calculated from entries
        {
            _name = "";
            _foodEntries = foodEntries;
            _note = note;
            _portion = 1;
            _fatEntry = calcFat();
            _carbsEntry = calcCarbs();
            _proteinEntry = calcProtein();
        }
        public MealEntry(List<FoodEntry> foodEntries, Note note, double fat, double carbs, double protein, double portion)  //init unnamed meal,all other values are given
        {
            _name = "";
            _foodEntries = foodEntries;
            _note = note;
            _portion = portion;
            _fatEntry = fat;
            _carbsEntry = carbs;
            _proteinEntry = protein;
        }
        public MealEntry(List<FoodEntry> foodEntries, Match match)  //init meal entry by a Regex match with several groups for respective values
        {
            _name = match.Groups["Name"].Value;
            _foodEntries = foodEntries;

            String[] strm = match.Groups["Macros"].Value.Split(new string[] { "//" }, StringSplitOptions.RemoveEmptyEntries);   //macro format comes as 11//11//11
            _fatEntry = Convert.ToDouble(strm[0]);
            _carbsEntry = Convert.ToDouble(strm[1]);
            _proteinEntry = Convert.ToDouble(strm[2]);

            _note = new Note(match.Groups["Note"].Value);

            String str = match.Groups["Portion"].Value;     //portion format comes as ===1== or ===0.3== or ===1/2==
            if (str == "=====" || str == "===1==")
                _portion = 1;
            else if (str.Contains('/'))
            {
                String[] strs = str.Replace("=", "").Split('/');
                _portion = Math.Round(Convert.ToDouble(strs[0]) / Convert.ToDouble(strs[1]), 2);
            }
            else
                _portion = Convert.ToDouble(str.Replace("=", ""));

            setCalculatedValues();      //replace current macro with calculated
        }
        public MealEntry(List<FoodEntry> foodEntries, String foodEntryStr) : this(foodEntries, MainForm.regexMealResult.Match(foodEntryStr)) { }    //init with string to be matched
        #endregion

        #region Add/Set
        public void addFoodEntry(FoodEntry foodEntry)
        {
            _foodEntries.Add(foodEntry);
        }
        public void addFoodEntry(Match match)
        {
            _foodEntries.Add(new FoodEntry(match));
        }
        public void addFoodEntry(String foodEntryStr)
        {
            _foodEntries.Add(new FoodEntry(foodEntryStr));
        }
        public void setNote(String noteStr)
        {
            _note = new Note(noteStr);
        }
        public void setEntryMacros(String groupMacros)
        {
            String[] strm = groupMacros.Split(new string[] { "//" }, StringSplitOptions.RemoveEmptyEntries);
            _fatEntry = Convert.ToDouble(strm[0]);
            _carbsEntry = Convert.ToDouble(strm[1]);
            _proteinEntry = Convert.ToDouble(strm[2]);
        }
        public void setPortion(String groupPortion)
        {
            if (groupPortion == "=====" || groupPortion=="===1==")
                _portion = 1;
            else if (groupPortion.Contains('/'))
            {
                String[] strs = groupPortion.Replace("=", "").Split('/');
                _portion = Math.Round(Convert.ToDouble(strs[0]) / Convert.ToDouble(strs[1]), 2);
            }
            else
                _portion = Convert.ToDouble(groupPortion.Replace("=", ""));
        }
        public void setMatchValues(Match match)
        {
            setEntryMacros(match.Groups["Macros"].Value);
            setNote(match.Groups["Note"].Value);
            setPortion(match.Groups["Portion"].Value);
        }
        #endregion

        #region Math
        public double calcFat()     //calculates fat values by adding values from all food entries
        {
            double fat = 0;
            foreach (FoodEntry fe in _foodEntries)
                fat += fe._fatEntry;
            return Math.Round(fat * _portion, 1);
        }
        public double calcCarbs()   //calculates carbs values by adding values from all food entries
        {
            double carbs = 0;
            foreach (FoodEntry fe in _foodEntries)
                carbs += fe._carbsEntry;
            return Math.Round(carbs * _portion, 1);
        }
        public double calcProtein() //calculates protein values by adding values from all food entries
        {
            double protein = 0;
            foreach (FoodEntry fe in _foodEntries)
                protein += fe._proteinEntry;
            return Math.Round(protein * _portion, 1);
        }
        public bool checkMacroEntries() //checks to see if current macro entries are aprox. the same as calculated ones
        {
            double calc = calcFat();
            if (Math.Abs(_fatEntry - calc) > calc * 1 / 20 && calc > 1)
                return false;
            calc = calcCarbs();
            if (Math.Abs(_carbsEntry - calc) > calc * 1 / 20 && calc > 1)
                return false;
            calc = calcProtein();
            if (Math.Abs(_proteinEntry - calc) > calc * 1 / 20 && calc > 1)
                return false;
            return true;
        }
        public void setCalculatedValues()    //Replaces current macro entries with calculated ones
        {
            _fatEntry = calcFat();
            _carbsEntry = calcCarbs();
            _proteinEntry = calcProtein();
        }
        #endregion

        #region Printing
        public String getMacros()   //get current macros in string format: 11/11/11
        {
            return _fatEntry + "/" + _carbsEntry + "/" + _proteinEntry;
        }
        public String getCalcMacros()   //get calculated macros in string format: 11/11/11
        {
            return calcFat() + "/" + calcCarbs() + "/" + calcProtein();
        }
        public override String ToString()   //gets all data into string format
        {
            String res = "";
            foreach (FoodEntry foodEntry in _foodEntries)
                res += foodEntry + "\n";
            res += $"{_name}==={_portion}=={_fatEntry}//{_carbsEntry}//{_proteinEntry} {_note}";
            return res;
        }
        public String ToStringLite()     //gets data into string format but leaves out all the list items
        {
            return $"{_name}==={_portion}=={_fatEntry}//{_carbsEntry}//{_proteinEntry} {_note}";
        }
        #endregion
    }
}
