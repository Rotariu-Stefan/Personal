using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class SimpleEvRunner : EventRunner
    {
        private Event _ev;
        public Event Ev
        {
            get
            {
                return _ev;
            }
            set
            {
                if (value == null) throw new Exception("Null Events cannot be Checked !");
                _ev = value;
            }
        }

        private int _checkParam = 1;
        public int CheckParam
        {
            get
            {
                return _checkParam;
            }
            set
            {
                if (value < 0) throw new Exception("No Negative Probabilities !");
                _checkParam = value;
            }
        }

        public SimpleEvRunner(Event ev)
        {
            Ev = ev;
        }
        public SimpleEvRunner(Event ev, int checkParam)
        {
            Ev = ev;
            CheckParam = checkParam;
        }
        public SimpleEvRunner(Event ev, int checkParam, int repeat) : this(ev, checkParam)
        {
            Repeat = repeat;
        }

        public override void runEvents()
        {
            _ev.happen();
        }
        public bool checkSIMPLE(int isSuccess)
        {
            if (isSuccess < 0) throw new Exception("No Negative Probabilities !");
            if (isSuccess > 0) return _ev.ResultState;
            else return !_ev.ResultState;
        }

        public override bool checkSetMethods()
        {
            return checkSIMPLE(_checkParam);
        }

        public override float getChance(int triesNr)
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

        public override string getName()
        {
            if (_name == Event.keywords[0])
                if (_checkParam == 0)
                    return _ev.Name + "*NOT";
                else
                    return _ev.Name;
            else
                return _name;
        }
        public override string getMessage(int triesNr)
        {
            return "The Chance of Succes for " + getName() + " is: " + getChance(triesNr) + "% !";
        }
    }
}
