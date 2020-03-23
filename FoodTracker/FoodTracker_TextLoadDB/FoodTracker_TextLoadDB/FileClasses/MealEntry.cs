using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FoodTracker_TextLoadDB
{
    public class MealEntry
    {
        #region Fields
        public String _name
        { get; set; }
        public List<FoodEntry> _foodEntries
        { get; }
        public Note _note
        { get; set; }
        public double _fatEntry
        { get; set; }
        public double _carbsEntry
        { get; set; }
        public double _proteinEntry
        { get; set; }
        public double _portion
        { get; set; }
        #endregion

        #region Constructors
        public MealEntry()
        {
            _name = "";
            _foodEntries = new List<FoodEntry>();
            _note = new Note();
            _portion = 1;
            _fatEntry = 0;
            _carbsEntry = 0;
            _proteinEntry = 0;
        }
        public MealEntry(List<FoodEntry> foodEntries, Note note)
        {
            _name = "";
            _foodEntries = foodEntries;
            _note = note;
            _portion = 1;
            _fatEntry = calcFat();
            _carbsEntry = calcCarbs();
            _proteinEntry = calcProtein();
        }
        public MealEntry(List<FoodEntry> foodEntries, Note note, double fat, double carbs, double protein, double portion)
        {
            _name = "";
            _foodEntries = foodEntries;
            _note = note;
            _portion = portion;
            _fatEntry = fat;
            _carbsEntry = carbs;
            _proteinEntry = protein;
        }
        public MealEntry(List<FoodEntry> foodEntries, Match match)
        {
            _name = match.Groups["Name"].Value;
            _foodEntries = foodEntries;

            String[] strm = match.Groups["Macros"].Value.Split(new string[] { "//" }, StringSplitOptions.RemoveEmptyEntries);
            _fatEntry = Convert.ToDouble(strm[0]);
            _carbsEntry = Convert.ToDouble(strm[1]);
            _proteinEntry = Convert.ToDouble(strm[2]);

            _note = new Note(match.Groups["Note"].Value);

            String str = match.Groups["Portion"].Value;
            if (str == "=====" || str == "===1==")
                _portion = 1;
            else if (str.Contains('/'))
            {
                String[] strs = str.Replace("=", "").Split('/');
                _portion = Math.Round(Convert.ToDouble(strs[0]) / Convert.ToDouble(strs[1]), 2);
            }
            else
                _portion = Convert.ToDouble(str.Replace("=", ""));

            checkAndCorrect();
        }
        public MealEntry(List<FoodEntry> foodEntries, String foodEntryStr) : this(foodEntries, MainForm.regexMealResult.Match(foodEntryStr)) { }
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
        public double calcFat()
        {
            double fat = 0;
            foreach (FoodEntry fe in _foodEntries)
                fat += fe._fatEntry;
            return Math.Round(fat * _portion, 1);
        }
        public double calcCarbs()
        {
            double carbs = 0;
            foreach (FoodEntry fe in _foodEntries)
                carbs += fe._carbsEntry;
            return Math.Round(carbs * _portion, 1);
        }
        public double calcProtein()
        {
            double protein = 0;
            foreach (FoodEntry fe in _foodEntries)
                protein += fe._proteinEntry;
            return Math.Round(protein * _portion, 1);
        }
        public bool checkMacroEntries()
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
        public bool checkAndCorrect()
        {
            double calc = calcFat();
            bool correct = true;
            if (Math.Abs(_fatEntry - calc) > calc * 1 / 20 && calc > 1)
            {
                _fatEntry = calc;
                correct = false;
            }
            calc = calcCarbs();
            if (Math.Abs(_carbsEntry - calc) > calc * 1 / 20 && calc > 1)
            {
                _carbsEntry = calc;
                correct = false;
            }
            calc = calcProtein();
            if (Math.Abs(_proteinEntry - calc) > calc * 1 / 20 && calc > 1)
            {
                _proteinEntry = calc;
                correct = false;
            }
            return correct;
        }
        #endregion

        #region Printing
        public String getMacros()
        {
            return _fatEntry + "/" + _carbsEntry + "/" + _proteinEntry;
        }
        public String getCalcMacros()
        {
            return calcFat() + "/" + calcCarbs() + "/" + calcProtein();
        }
        public override String ToString()
        {
            String res = "";
            foreach (FoodEntry foodEntry in _foodEntries)
                res += foodEntry + "\n";
            res += $"{_name}==={_portion}=={_fatEntry}//{_carbsEntry}//{_proteinEntry} {_note}";
            return res;
        }
        public String ToStringLite()
        {
            return $"{_name}==={_portion}=={_fatEntry}//{_carbsEntry}//{_proteinEntry} {_note}";
        }
        #endregion
    }
}
