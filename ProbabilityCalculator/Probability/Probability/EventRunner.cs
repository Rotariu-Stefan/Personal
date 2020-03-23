using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public abstract class EventRunner
    {
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

        public abstract string getName();

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

        public abstract float getChance(int triesNr);
        public float getChance()
        {
            return getChance(defaultTries);
        }

        public abstract string getMessage(int triesNr);
        public string getMessage()
        {
            return getMessage(defaultTries);
        }
    }
}
