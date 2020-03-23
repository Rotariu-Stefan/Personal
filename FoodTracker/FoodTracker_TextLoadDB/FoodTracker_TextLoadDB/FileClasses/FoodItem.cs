using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FoodTracker_TextLoadDB
{
    public enum Measure
    {
        Grams,
        ML,
        Pieces
    }
    public class FoodItem
    {
        #region Fields
        public double _fat
        { get; }
        public double _carbs
        { get; }
        public double _protein
        { get; }
        public Measure _measure
        { get; }
        public String _name
        { get; }
        public String _brand
        { get; }
        #endregion

        #region Constructors
        public FoodItem()
        {
            _fat = 0;
            _carbs = 0;
            _protein = 0;
            _measure = 0;
            _name = "NoName";
            _brand = "";
        }
        public FoodItem(String name, String brand, double fat, double carbs, double protein, Measure measure)
        {
            _name = name;
            _brand = brand;
            _fat = fat;
            _carbs = carbs;
            _protein = protein;
            _measure = measure;
        }
        public FoodItem(Match match)
        {
            String str = match.Groups["Amount"].Value;
            _measure = Measure.Pieces;
            foreach (char c in str)
                if (Char.IsLetter(c))
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

            String[] strm = match.Groups["Macros"].Value.Split('/');
            _fat = Convert.ToDouble(strm[0]);
            _carbs = Convert.ToDouble(strm[1]);
            _protein = Convert.ToDouble(strm[2]);
        }
        public FoodItem(String foodItemStr) : this(MainForm.regexEntry.Match(foodItemStr)) { }
        #endregion

        public static Measure measureByString(String str)
        {
            if (str == "Grams")
                return Measure.Grams;
            else if (str == "ML")
                return Measure.ML;
            else
                return Measure.Pieces;
        }

        #region Printing
        public String getMacros()
        {
            return _fat + "/" + _carbs + "/" + _protein;
        }
        public override String ToString()
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
        public String ToStringNice()
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
        public static bool operator ==(FoodItem f1, FoodItem f2)
        {
            if (f1 is null && f2 is null)
                return true;
            if (f1 is null || f2 is null)
                return false;
            return (f1._name == f2._name) && (f1._brand == f2._brand);
        }
        public static bool operator !=(FoodItem f1, FoodItem f2)
        {
            if (f1 is null && f2 is null)
                return false;
            if (f1 is null || f2 is null)
                return true;
            return (f1._name != f2._name) || (f1._brand != f2._brand);
        }
        public override bool Equals(object obj)//TODO:Wtf is this DBnull stuff?
        {
            if (obj == DBNull.Value)
                return false;
            FoodItem f2 = (FoodItem)obj;
            return (this._name == f2._name) && (this._brand == f2._brand);
        }
        public override int GetHashCode()
        {
            var hashCode = 188360536;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_brand);
            return hashCode;
        }
        public static bool operator <(FoodItem f1, FoodItem f2)
        {
            if (f1 is null && !(f2 is null))
                return true;
            if (f2 is null)
                return false;
            return (f1._name + f1._brand).CompareTo(f2._name + f2._brand) == -1;
        }
        public static bool operator >(FoodItem f1, FoodItem f2)
        {
            if (f1 is null)
                return false;
            if (f2 is null && !(f1 is null))
                return true; ;
            return (f1._name + f1._brand).CompareTo(f2._name + f2._brand) == 1;
        }
        #endregion
    }
}
