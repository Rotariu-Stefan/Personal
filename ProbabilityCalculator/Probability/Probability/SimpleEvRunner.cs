using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probability
{
    public class SimpleEvRunner : EventRunner
    {
        #region Fields
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
        #endregion

        #region Constructors
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
        #endregion

        #region Run methods implementation
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
        public override void runEvents()
        {
            _ev.happen();
        }
        #endregion

        #region Info Gets implementation
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
        #endregion
    }
}
