using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker_TextLoadDB
{
    public class Note   //a note that provides a rating and other info describing effects/quality of instances of Meal/Day(maybe food?) Entries
    {
        #region Fields
        public String _grade    //a score/rating on the attatchment
        { get; set; }
        public String _text     //other info/description
        { get; }
        #endregion

        #region Constructors
        public Note()   //init blank Note
        {
            _grade = "";
            _text = "";
        }
        public Note(String grade, String text)  //init Note with values
        {
            _grade = gradeProcess(grade);
            _text = text;
        }
        public Note(String noteStr)     //init Note in print string format: +_(description)
        {
            if (noteStr == "")  //case blank
            {
                _grade = "";
                _text = "";
            }
            else
            {
                int textPos = noteStr.IndexOf('(');
                if (textPos == -1)      //case no description
                {
                    _grade = noteStr;
                    _text = "";
                }
                else
                {       //case both values present - ignores the paranthesis
                    _grade = noteStr.Substring(0, textPos);
                    _text = noteStr.Substring(noteStr.IndexOf('(') + 1, noteStr.Length - noteStr.IndexOf('(') - 2);
                }
            }
        }
        #endregion

        #region Math
        public double gradeAverage()    //returns grade as a number (~ diminishes by 0.5)
        {
            bool kinda = false;
            double result = 0;
            foreach (char g in _grade)
            {
                if (g == '+')
                    result++;
                else if (g == '-')
                    result--;
                else if (g == '~')
                    kinda = true;
            }
            if (kinda)
                if (result < 0) result += 0.5;
                else if (result > 0) result -= 0.5;
            return result;
        }
        private String gradeProcess(String grade)   //init grade as a number(from a matched string)
        {
            if (Double.TryParse(grade, out double s))
            {
                String str = "";
                if (s == 0)
                    return str;
                if (s > 0)
                    while (s > 0)
                    {
                        s -= 1;
                        str += "+";
                    }
                else if (s < 0)
                    while (s < 0)
                    {
                        s += 1;
                        str += "-";
                    }
                if (s != 0)
                    str = "~" + str;
                return str;
            }
            else
                return grade;
        }
        #endregion

        #region Printing
        public override string ToString()   //get string format: +-(description)
        {
            return _grade + (_text == "" ? "" : '(' + _text + ')');
        }
        public String ToStringInfo()    //longer format show of object Note
        {
            return $"Grade Average:{gradeAverage()}\nText:{_text}";
        }
        #endregion
    }
}
