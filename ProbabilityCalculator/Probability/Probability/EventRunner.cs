using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probability
{
    public abstract class EventRunner
    {
        #region Fields
        public const int defaultTries = 100000;
        protected const int defaultAvg = 1;

        private List<bool> _results = new List<bool>();
        public List<bool> Results { get => _results; }

        private int _repeat = 1;
        public int Repeat
        {
            set
            {
                if (value < 0) throw new Exception("Cannot have Negative repetitions !");
                else _repeat = value;
            }
            get
            {
                return _repeat;
            }
        }

        protected string _name = Event.keywords[0];
        public string Name
        {
            set
            {
                if (value == "") _name = Event.keywords[0];
                else if (Event.keywords.Contains(value)) throw new Exception(value + "is a reserved keyword !");
                else _name = value;
            }
            get
            {
                return getName();
            }
        }
        #endregion

        #region Run methods -forInherit
        public abstract void runEvents();
        public abstract bool checkSetMethods();
        public void setRepeatResults()
        {
            _results.Clear();
            for (int i = 0; i < _repeat; i++)
            {
                runEvents();

                if (checkSetMethods()) _results.Add(Event.SUCCESS);
                else _results.Add(Event.FAIL);
            }
        }
        #endregion

        #region Info gets -forInherit
        public float getChance(int triesNr)
        {
            float sCount, fCount, chance = 0;

            for (int i_av = 0; i_av < defaultAvg; i_av++)
            {
                sCount = 0; fCount = 0;
                for (int i_tr = 0; i_tr < triesNr; i_tr++)
                {
                    runEvents();

                    if (checkSetMethods()) sCount++;
                    else fCount++;
                }
                if (fCount == 0) chance += 100;
                else chance += (sCount / (fCount + sCount)) * 100;
            }
            return chance / defaultAvg;
        }
        public float getChance()
        {
            return getChance(defaultTries);
        }

        public string getMessage(int triesNr)
        {
            return "The Chance of Succes for " + getName() + " is: " + getChance(triesNr) + "% !";
        }
        public string getMessage()
        {
            return getMessage(defaultTries);
        }

        public abstract string getName();
        #endregion
    }
}
