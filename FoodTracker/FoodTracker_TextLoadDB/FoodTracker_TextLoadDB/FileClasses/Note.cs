using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker_TextLoadDB
{
    public class Note
    {
        #region Fields
        public String _grade
        { get; }
        public String _text
        { get; }
        #endregion

        #region Constructors
        public Note()
        {
            _grade = "";
            _text = "";
        }
        public Note(String grade, String text)
        {
            _grade = gradeProcess(grade);
            _text = text;
        }
        public Note(String noteStr)
        {
            if (noteStr == "")
            {
                _grade = "";
                _text = "";
            }
            else
            {
                int textPos = noteStr.IndexOf('(');
                if (textPos == -1)
                {
                    _grade = noteStr;
                    _text = "";
                }
                else
                {
                    _grade = noteStr.Substring(0, textPos);
                    _text = noteStr.Substring(noteStr.IndexOf('(') + 1, noteStr.Length - noteStr.IndexOf('(') - 2);
                }
            }
        }
        #endregion

        #region Math
        public double gradeAverage()
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
        private String gradeProcess(String grade)
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
        public override string ToString()
        {
            return _grade + (_text == "" ? "" : '(' + _text + ')');
        }
        public String ToStringInfo()
        {
            return $"Grade Average:{gradeAverage()}\nText:{_text}";
        }
        #endregion
    }
}
