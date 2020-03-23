using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FoodTracker_TextLoadDB
{
    public class DayEntry
    {
        #region Fields
        public List<MealEntry> _mealEntries
        { get; }
        public DateTime _date
        { get; set; }
        public Note _note
        { get; set; }
        public String _activ
        { get; set; }
        public double _fatEntry
        { get; set; }
        public double _carbsEntry
        { get; set; }
        public double _proteinEntry
        { get; set; }
        #endregion

        #region Constructors
        public DayEntry()
        {
            _mealEntries = new List<MealEntry>();
            _date = DateTime.Now;
            _note = new Note();
            _activ = "";
            _fatEntry = 0;
            _carbsEntry = 0;
            _proteinEntry = 0;
        }
        public DayEntry(DateTime date, List<MealEntry> mealEntries, Note note)
        {
            _mealEntries = mealEntries;
            _date = date;
            _note = note;
            _activ = "";
            _fatEntry = calcFat();
            _carbsEntry = calcCarbs();
            _proteinEntry = calcProtein();
        }
        public DayEntry(DateTime date, List<MealEntry> mealEntries, Note note, double fat, double carbs, double protein) : this(date, mealEntries, note)
        {
            _fatEntry = fat;
            _carbsEntry = carbs;
            _proteinEntry = protein;
        }
        public DayEntry(List<MealEntry> mealEntries, Match match)
        {
            _mealEntries = mealEntries;
            _activ = "";

            String[] strd = match.Groups["Date"].Value.Split('/');
            _date = new DateTime(Convert.ToInt32(strd[2]), Convert.ToInt32(strd[1]), Convert.ToInt32(strd[0]));

            _note = new Note(match.Groups["Note"].Value);

            String[] strm = match.Groups["Macros"].Value.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
            _fatEntry = Convert.ToDouble(strm[0]);
            _carbsEntry = Convert.ToDouble(strm[1]);
            _proteinEntry = Convert.ToDouble(strm[2]);

            checkAndCorrect();
        }
        #endregion

        #region Add/Set
        public void addMealEntry(MealEntry mealEntry)
        {
            _mealEntries.Add(mealEntry);
        }
        public void setDate(String groupDate)
        {
            String[] strd = groupDate.Split('/');
            _date = new DateTime(Convert.ToInt32(strd[2]), Convert.ToInt32(strd[1]), Convert.ToInt32(strd[0]));
        }
        public void setNote(String groupNote)
        {
            _note = new Note(groupNote);
        }
        public void setActiv(String groupActiv)
        {
            _activ = groupActiv;
        }
        public void setEntryMacros(String groupMacros)
        {
            String[] strm = groupMacros.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
            _fatEntry = Convert.ToDouble(strm[0]);
            _carbsEntry = Convert.ToDouble(strm[1]);
            _proteinEntry = Convert.ToDouble(strm[2]);
        }
        public void setMatchValues(Match match)
        {
            setDate(match.Groups["Date"].Value);
            setNote(match.Groups["Note"].Value);
            setEntryMacros(match.Groups["Macros"].Value);
        }
        #endregion

        #region Math
        public double calcFat()
        {
            double fat = 0;
            foreach (MealEntry fe in _mealEntries)
                fat += fe._fatEntry;
            return fat;
        }
        public double calcCarbs()
        {
            double carbs = 0;
            foreach (MealEntry fe in _mealEntries)
                carbs += fe._carbsEntry;
            return carbs;
        }
        public double calcProtein()
        {
            double protein = 0;
            foreach (MealEntry fe in _mealEntries)
                protein += fe._proteinEntry;
            return protein;
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
            foreach (MealEntry mealEntry in _mealEntries)
                res += mealEntry + "\n\n";
            if (_activ != "")
                res += _activ + "\n";
            res += $"{_date.ToString("dd/MM/yyyy")}--->{_fatEntry}||{_carbsEntry}||{_proteinEntry} {_note}\n";
            res += "-----------";
            return res;
        }
        public String ToStringLite()
        {
            String res = "";
            if(_activ!="")
                res += _activ + "\n";
            res += $"{_date.ToString("dd/MM/yyyy")}--->{_fatEntry}||{_carbsEntry}||{_proteinEntry} {_note}\n";
            res += "-----------";
            return res;
        }
        #endregion

        public DayEntry Clone()
        {
            List<MealEntry> ml = new List<MealEntry>();
            foreach (var meal in this._mealEntries)
            {
                List<FoodEntry> fl = new List<FoodEntry>();
                foreach (var fentry in meal._foodEntries)
                {
                    fl.Add(new FoodEntry(fentry._food, fentry._amount));
                }
                MealEntry newm = new MealEntry(fl, new Note(meal._note._grade, meal._note._text), meal._fatEntry, meal._carbsEntry, meal._proteinEntry, meal._portion);
                newm._name = meal._name;
                ml.Add(newm);
            }
            DayEntry clone= new DayEntry(this._date, ml, new Note(this._note._grade, this._note._text), this._fatEntry, this._carbsEntry, this._proteinEntry);
            clone.setActiv(this._activ);
            return clone;
        }
    }
}
