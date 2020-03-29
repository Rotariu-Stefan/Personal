using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FoodTracker_TextLoadDB
{
    public class FoodEntry      //reprezents a single Food entry instance in a Meal or a Dish(FoodItem type and Amount entered with values based on amount)
    {
        #region Fields
        public FoodItem _food   //the type of food
        { get; }
        public double _amount   //the amount consumed/entered
        { get; }
        public double _fatEntry     //given fat value for amount entered
        { get; set; }
        public double _carbsEntry   //given carbs value for amount entered
        { get; set; }
        public double _proteinEntry //given protein value for amount entered
        { get; set; }
        #endregion

        #region Constructors    //various ways to initalize

        public FoodEntry()  //init a non-food/empty entry?
        {
            _food = new FoodItem();
            _amount = 0;
            _fatEntry = 0;
            _carbsEntry = 0;
            _proteinEntry = 0;
        }
        public FoodEntry(FoodItem food) //init with a food: assumes default measure unit and calculates values based on that
        {
            MainForm.insertOrRefFood(ref food);     //if food given is not part of Global Foods list Adds it and Refereces it here. Else it only refereces it from the global list.
            _food = food;
            _amount = (_food._measure == Measure.Pieces) ? 1 : 100;
            _fatEntry = calcFat();
            _carbsEntry = calcCarbs();
            _proteinEntry = calcProtein();
        }
        public FoodEntry(FoodItem food, double amount)  //init with a food+amount: calculated macro values
        {
            MainForm.insertOrRefFood(ref food);     //if food given is not part of Global Foods list Adds it and Refereces it here. Else it only refereces it from the global list.
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
        public FoodEntry(Match match)   //init food entry by a Regex match(from any food entry text) with several groups for respective values
        {
            FoodItem ftemp = new FoodItem(match);
            MainForm.insertOrRefFood(ref ftemp);    //if food given is not part of Global Foods list Adds it and Refereces it here. Else it only refereces it from the global list.
            _food = ftemp;

            String str = new String(match.Groups["Amount"].Value.TakeWhile(c => !Char.IsLetter(c) && c != ' ').ToArray());  //grabs only number from format: 11g or 1/2
            if (str.Contains('/'))
                _amount = Math.Round(Convert.ToDouble(str.Split('/')[0]) / Convert.ToDouble(str.Split('/')[1]), 2);     //in case of fraction format get an actual number
            else
                _amount = Convert.ToDouble(str);

            setCalculatedValues();  //replace current macro with calculated
        }
        public FoodEntry(String foodEntryStr) : this(MainForm.regexEntry.Match(foodEntryStr)) { }   //init with string to be matched
        #endregion

        #region Set
        public void setEntryMacros(String groupMacro)   //sets user entry macros(Not calculated)
        {
            String[] macros = groupMacro.Split('/');
            _fatEntry = Convert.ToDouble(macros[0]);
            _carbsEntry = Convert.ToDouble(macros[1]);
            _proteinEntry = Convert.ToDouble(macros[2]);
        }
        #endregion

        #region Math
        public double calcFat()     //calculates fat value based on food item data and amount
        {
            if (_food._measure == Measure.Pieces) return _amount * _food._fat;
            else return Math.Round(_amount * _food._fat / 100, 1);
        }
        public double calcCarbs()   //calculates carbs value based on food item data and amount
        {
            if (_food._measure == Measure.Pieces) return _amount * _food._carbs;
            else return Math.Round(_amount * _food._carbs / 100, 1);
        }
        public double calcProtein() //calculates protein value based on food item data and amount
        {
            if (_food._measure == Measure.Pieces) return _amount * _food._protein;
            else return Math.Round(_amount * _food._protein / 100, 1);
        }
        public bool checkMacroEntries()     //checks to see if current macro entries are aprox. the same as calculated ones
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
        public void setCalculatedValues()   //Replaces current macro entries with calculated ones
        {
            _fatEntry = calcFat();
            _carbsEntry = calcCarbs();
            _proteinEntry = calcProtein();
        }
        #endregion

        #region Printing
        public String getCalcMacros()   //get calculated macros in string format: 11/11/11
        {
            return calcFat() + "/" + calcCarbs() + "/" + calcProtein();
        }
        public String getMacros()       //get current macros in string format: 11/11/11
        {
            return _fatEntry + "/" + _carbsEntry + "/" + _proteinEntry;
        }
        public override String ToString()   //get data in string format(food&amount And current saved macros)
        {
            return $"{_amount}{_food}\n={getMacros()}";
        }
        public String ToStringLite()        //get data in string format(food&amount)
        {
            return $"{_amount}{_food}";
        }
        #endregion

    }
}
