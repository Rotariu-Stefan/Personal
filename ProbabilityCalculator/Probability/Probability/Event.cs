using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Event //38px padding for ComplexEvent panel
    {
        public static readonly Random rng = new Random();
        public static readonly string[] keywords = { "Undefined", "Success", "Fail", "Half" };
        public const bool SUCCESS = true;
        public const bool FAIL = false;

        private string _name = keywords[0];
        public string Name
        {
            set
            {
                if (value == "") _name = keywords[0];
                else if (keywords.Contains(value)) throw new Exception(value + "is a reserved keyword !");
                else _name = value;
            }
            get
            {
                return _name == keywords[0] ? _favorNr.ToString() + "/" + _possibleNr.ToString() : _name;
            }
        }

        private int _favorNr;
        public int FavorNr
        {
            set
            {
                if (value < 0) throw new Exception("No Negative Probabilities !");
                else if (value > _possibleNr) throw new Exception("Favorable outcomes(" + value + ") Cannot exceed Possible outcomes(" + _possibleNr + ") !");
                else _favorNr = value;
            }
            get
            {
                return _favorNr;
            }
        }

        private int _possibleNr;
        public int PossibleNr
        {
            set
            {
                if (value < 0) throw new Exception("No Negative Probabilities !");
                else if (_favorNr > value) throw new Exception("Favorable outcomes(" + _favorNr + ") Cannot exceed Possible outcomes(" + value + ") !");
                else _possibleNr = value;
            }
            get
            {
                return _possibleNr;
            }
        }

        private bool _resultState;
        public bool ResultState
        {
            get
            {
                return _resultState;
            }
        }

        public Event()
        {
            _name = keywords[3];
            PossibleNr = 2;
            FavorNr = 1;
        }//Everything is really 50/50. Either it happens or it doesn't!
        public Event(string name)
        {
            Name = name;
            PossibleNr = 2;
            FavorNr = 1;
        }//Everything is really 50/50. Either it happens or it doesn't!
        public Event(bool isSuccess)
        {
            if (isSuccess)
            {
                _name = keywords[1];
                PossibleNr = 1;
                FavorNr = 1;
            }
            else
            {
                _name = keywords[2];
                PossibleNr = 1;
                FavorNr = 0;
            }
        }
        public Event(int favorNr, int possibleNr)
        {
            setValues(favorNr, possibleNr);
        }
        public Event(string name, int favorNr, int possibleNr) : this(favorNr, possibleNr)
        {
            Name = name;
        }
        public Event(double chanceNr)
        {
            setChance(chanceNr);
        }
        public Event(string name, double chanceNr) : this(chanceNr)
        {
            Name = name;
        }

        public void setValues(int fav, int pos)
        {
            if (fav > pos) throw new Exception("Favorable outcomes(" + fav + ") Cannot exceed Possible outcomes(" + pos + ") !");
            _possibleNr = pos;
            _favorNr = fav;
        }
        public void setChance(double ch)
        {
            if (ch > 1) throw new Exception("Chance(" + ch + ") Cannot exceed 100% (1) !");

            double temp = ch * 100;
            if (temp != (int)temp)
            {
                temp *= 10;
                if (temp != (int)temp)
                {
                    temp *= 10;
                    PossibleNr = 10000;
                }
                else PossibleNr = 1000;
            }
            else _possibleNr = 100;
            _favorNr = (int)(temp);
        }

        public void happen()
        {
            if (_favorNr == 0) _resultState = FAIL;
            else if (_possibleNr == _favorNr) _resultState = SUCCESS;
            else
            {
                if (rng.Next(_possibleNr) < _favorNr) _resultState = SUCCESS;
                else _resultState = FAIL;
            }
        }
    }
}
