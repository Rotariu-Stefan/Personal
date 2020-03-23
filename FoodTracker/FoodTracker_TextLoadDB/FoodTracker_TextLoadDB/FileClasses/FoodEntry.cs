using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FoodTracker_TextLoadDB
{
    public class FoodEntry
    {
        #region Fields
        public FoodItem _food
        { get; }
        public double _amount
        { get; }
        public double _fatEntry
        { get; set; }
        public double _carbsEntry
        { get; set; }
        public double _proteinEntry
        { get; set; }
        #endregion

        #region Constructors
        public FoodEntry()
        {
            _food = new FoodItem();
            _amount = 0;
            _fatEntry = 0;
            _carbsEntry = 0;
            _proteinEntry = 0;
        }
        public FoodEntry(FoodItem food)
        {
            MainForm.insertOrRefFood(ref food);
            _food = food;
            _amount = (_food._measure == Measure.Pieces) ? 1 : 100;
            _fatEntry = calcFat();
            _carbsEntry = calcCarbs();
            _proteinEntry = calcProtein();
        }
        public FoodEntry(FoodItem food, double amount)
        {
            MainForm.insertOrRefFood(ref food);
            _food = food;
            _amount = amount;
            _fatEntry = calcFat();
            _carbsEntry = calcCarbs();
            _proteinEntry = calcProtein();
        }
        public FoodEntry(FoodItem food, double amount, double fat, double carbs, double protein) : this(food, amount)
        {
            _fatEntry = fat;
            _carbsEntry = carbs;
            _proteinEntry = protein;
        }
        public FoodEntry(Match match)
        {
            FoodItem ftemp = new FoodItem(match);
            MainForm.insertOrRefFood(ref ftemp);
            _food = ftemp;

            String str = new String(match.Groups["Amount"].Value.TakeWhile(c => !Char.IsLetter(c) && c != ' ').ToArray());
            if (str.Contains('/'))
                _amount = Math.Round(Convert.ToDouble(str.Split('/')[0]) / Convert.ToDouble(str.Split('/')[1]), 2);
            else
                _amount = Convert.ToDouble(str);

            checkAndCorrect();
        }
        public FoodEntry(String foodEntryStr) : this(MainForm.regexEntry.Match(foodEntryStr)) { }
        #endregion

        #region Set
        public void setEntryMacros(String groupMacro)
        {
            String[] macros = groupMacro.Split('/');
            _fatEntry = Convert.ToDouble(macros[0]);
            _carbsEntry = Convert.ToDouble(macros[1]);
            _proteinEntry = Convert.ToDouble(macros[2]);
        }
        #endregion

        #region Math
        public double calcFat()
        {
            if (_food._measure == Measure.Pieces) return _amount * _food._fat;
            else return Math.Round(_amount * _food._fat / 100, 1);
        }
        public double calcCarbs()
        {
            if (_food._measure == Measure.Pieces) return _amount * _food._carbs;
            else return Math.Round(_amount * _food._carbs / 100, 1);
        }
        public double calcProtein()
        {
            if (_food._measure == Measure.Pieces) return _amount * _food._protein;
            else return Math.Round(_amount * _food._protein / 100, 1);
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
        public String getCalcMacros()
        {
            return calcFat() + "/" + calcCarbs() + "/" + calcProtein();
        }
        public String getMacros()
        {
            return _fatEntry + "/" + _carbsEntry + "/" + _proteinEntry;
        }
        public override String ToString()
        {
            return $"{_amount}{_food}\n={getMacros()}";
        }
        #endregion

    }
}
