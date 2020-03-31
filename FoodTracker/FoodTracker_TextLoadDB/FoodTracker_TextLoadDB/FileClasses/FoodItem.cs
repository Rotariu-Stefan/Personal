using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FoodTracker_TextLoadDB
{
    public enum Measure     //possible types of measurement for for food
    {
        Grams,
        ML,
        Pieces
    }
    public class FoodItem   //reprezents 1 type of food (either basic food or dish made from more foods+amounts)
    {
        #region Fields
        public double _fat      //fat value per measure unit
        { get; }
        public double _carbs    //carbs value per measure unit
        { get; }
        public double _protein  //protein value per measure unit
        { get; }
        public Measure _measure     //=> macros values are for 100g(in case Grams), or for 100ML(in case ML), or 1 piece(in case Piece)
        { get; }
        public String _name     //name of the food
        { get; }
        public String _brand    //brand that produces food
        { get; }
        #endregion

        #region Constructors
        public FoodItem()       //init a non-food item?
        {
            _fat = 0;
            _carbs = 0;
            _protein = 0;
            _measure = 0;
            _name = "NoName";
            _brand = "";
        }
        public FoodItem(String name, String brand, double fat, double carbs, double protein, Measure measure)   //init food item by values
        {
            _name = name;
            _brand = brand;
            _fat = fat;
            _carbs = carbs;
            _protein = protein;
            _measure = measure;
        }
        public FoodItem(Match match)        //init food item by a Regex match(from any food entry text) with several groups for respective values
        {
            String str = match.Groups["Amount"].Value;  //amount format: 11 OR 11g OR 11ML
            _measure = Measure.Pieces;      //measure stays Pieces if no letter is found
            foreach (char c in str)
                if (Char.IsLetter(c))       //or changes to Grams/ML in case 'g'/else(would be an 'M') found
                    if (c == 'g')
                    {
                        _measure = Measure.Grams;
                        break;
                    }
                    else
                    {
                        _measure = Measure.ML;
                        break;
                    }

            _name = match.Groups["Name"].Value;
            _brand = match.Groups["Brand"].Value;

            String[] strm = match.Groups["Macros"].Value.Split('/');    //macro group format: 11/11/11
            _fat = Convert.ToDouble(strm[0]);
            _carbs = Convert.ToDouble(strm[1]);
            _protein = Convert.ToDouble(strm[2]);
        }
        public FoodItem(String foodItemStr) : this(MainForm.regexEntry.Match(foodItemStr)) { }  //init with string that gets matched
        #endregion

        #region Printing
        public String getMacros()       //get macros in string format: 11/11/11
        {
            return _fat + "/" + _carbs + "/" + _protein;
        }
        public override String ToString()   //get food item data in string format: g/ml/[ ] name brand 11/11/11
        {
            String measureStr;
            if (_measure == Measure.Grams)
                measureStr = "g";
            else if (_measure == Measure.ML)
                measureStr = "ml";
            else
                measureStr = "";

            return $"{measureStr} {_name} {(_brand == "" ? "" : '@' + _brand + " ")}{_fat}/{_carbs}/{_protein}";
        }
        public String ToStringNice()    //get food item data in nicer string format
        {
            String measureStr;
            if (_measure == Measure.Grams)
                measureStr = "(per 100g)";
            else if (_measure == Measure.ML)
                measureStr = "(per 100ml)";
            else
                measureStr = "(per 1piece)";
            return $"{_name} {(_brand == "" ? "" : '@' + _brand + " ")}{_fat}/{_carbs}/{_protein}{measureStr} ";
        }
        #endregion

        #region Operators
        public static bool operator ==(FoodItem f1, FoodItem f2)    //perform == test on 2 foods by name and brand
        {
            if (f1 is null && f2 is null)
                return true;
            if (f1 is null || f2 is null)
                return false;
            return (f1._name == f2._name) && (f1._brand == f2._brand);
        }
        public static bool operator !=(FoodItem f1, FoodItem f2)    //perform != test on 2 foods by name and brand
        {
            if (f1 is null && f2 is null)
                return false;
            if (f1 is null || f2 is null)
                return true;
            return (f1._name != f2._name) || (f1._brand != f2._brand);
        }
        public override bool Equals(object obj)     //perform Equals test on 2 foods by name and brand
        {
            if (this is null && obj is null)
                return true;
            if (obj is null || obj is null)
                return false;
            if (obj == DBNull.Value)
                return false;
            FoodItem f2 = (FoodItem)obj;
            return (this._name == f2._name) && (this._brand == f2._brand);
        }
        public override int GetHashCode()       //hashcode generated override
        {
            var hashCode = 188360536;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_brand);
            return hashCode;
        }
        public static bool operator <(FoodItem f1, FoodItem f2)     //perform < test on 2 foods by name and brand
        {
            if (f1 is null && !(f2 is null))
                return true;
            if (f2 is null)
                return false;
            return (f1._name + f1._brand).ToLower().CompareTo((f2._name + f2._brand).ToLower()) < 0;    //if first name+brand is before the 2nd
        }
        public static bool operator >(FoodItem f1, FoodItem f2)     //perform > test on 2 foods by name and brand
        {
            if (f1 is null)
                return false;
            if (f2 is null && !(f1 is null))
                return true; ;
            return (f1._name + f1._brand).ToLower().CompareTo((f2._name + f2._brand).ToLower()) > 0;     //if first name+brand is after the 2nd
        }
        #endregion
    }
}
