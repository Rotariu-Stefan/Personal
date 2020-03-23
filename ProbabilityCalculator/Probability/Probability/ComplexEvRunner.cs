using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class ComplexEvRunner : EventRunner
    {
        //public static readonly string[] _checks = { "And", "Or", "SMin", "FMin", "SMax", "FMax" };
        public delegate bool CheckMethods(int checkParam);

        private List<EventRunner> _evRunnerList;
        public List<EventRunner> EvRunnerList { get => _evRunnerList; }

        private CheckMethods _checkMethods;
        public Delegate[] CheckMethodsList { get => _checkMethods == null ? null : _checkMethods.GetInvocationList(); }

        private List<int> _checkParams;
        public List<int> CheckParamsList { get => _checkParams; }

        public ComplexEvRunner(Event ev)
        {
            _evRunnerList = new List<EventRunner> { new SimpleEvRunner(ev) };
            setChecks(new CheckMethods(this.checkAND), new List<int> { 1 });
        }
        public ComplexEvRunner(Event ev, int repeat):this(ev)
        {
            Repeat = repeat;
        }
        public ComplexEvRunner(List<Event> evList)
        {
            _evRunnerList = new List<EventRunner>();
            foreach (Event ev in evList)
                addEvents(ev);
            setChecks(new CheckMethods(this.checkAND), new List<int> { 1 });
        }
        public ComplexEvRunner(List<Event> evList, int repeat) : this(evList)
        {
            Repeat = repeat;
        }
        public ComplexEvRunner(EventRunner evR)
        {
            _evRunnerList = new List<EventRunner> { evR };
            setChecks(new CheckMethods(this.checkAND), new List<int> { 1 });
        }
        public ComplexEvRunner(EventRunner evR, int repeat) : this(evR)
        {
            Repeat = repeat;
        }
        public ComplexEvRunner(List<EventRunner> evRList)
        {
            _evRunnerList = evRList;
            setChecks(new CheckMethods(this.checkAND), new List<int> { 1 });
        }
        public ComplexEvRunner(List<EventRunner> evRList, int repeat) : this(evRList)
        {
            Repeat = repeat;
        }

        public void setChecks(CheckMethods checkMethods, List<int> checkParams)
        {
            if (checkParams.Count != checkMethods.GetInvocationList().Length)
                throw new Exception("Number of Checks must Match number of Check Parameters !");
            _checkMethods = checkMethods;
            _checkParams = checkParams;
        }
        public void addCheck(string checkMethodName, int checkParam)
        {
            _checkMethods += (CheckMethods)Delegate.CreateDelegate(typeof(CheckMethods), this, "check" + checkMethodName);
            _checkParams.Add(checkParam);
        }
        public void replaceCheck(string checkMethodName, int checkParam, int index)
        {
            CheckMethods newChM = null;
            int i = 0;
            foreach (CheckMethods checkName in _checkMethods.GetInvocationList())
            {
                if (i == index)
                    newChM += (CheckMethods)Delegate.CreateDelegate(typeof(CheckMethods), this, "check" + checkMethodName);
                else
                    newChM += checkName;
                i++;
            }
            
            _checkMethods = newChM;
            _checkParams[index] = checkParam;
        }
        public void removeCheck(int index)
        {
            _checkMethods -= (CheckMethods)_checkMethods.GetInvocationList().GetValue(index);
            _checkParams.RemoveAt(index);
        }
        public string getCheckName(int index)
        {
            return _checkMethods.GetInvocationList()[index].Method.Name.Substring(5).ToUpper();
        }

        public void addEvents(EventRunner evRun)
        {
            _evRunnerList.Add(evRun);
        }
        public void addEvents(Event ev)
        {
            _evRunnerList.Add(new SimpleEvRunner(ev));
        }
        public void addEvents(List<Event> evList)
        {
            _evRunnerList.Add(new ComplexEvRunner(evList));
        }
        public void removeEvents(EventRunner evRun)
        {
            _evRunnerList.Remove(evRun);
        }

        public override void runEvents()
        {
            for (int i = 0; i < _evRunnerList.Count(); i++)
                _evRunnerList[i].setRepeatResults();
        }

        public bool checkAND(int isSuccess)
        {
            if (isSuccess < 0) throw new Exception("No Negative Probabilities !");
            else if (isSuccess > 0)
            {
                for (int i = 0; i < _evRunnerList.Count(); i++)
                    foreach (bool result in _evRunnerList[i].Results)
                        if (result == Event.FAIL)
                            return Event.FAIL;
                return Event.SUCCESS;
            }
            else
            {
                for (int i = 0; i < _evRunnerList.Count(); i++)
                    foreach (bool result in _evRunnerList[i].Results)
                        if (result == Event.SUCCESS)
                            return Event.FAIL;
                return Event.SUCCESS;
            }
        }
        public bool checkOR(int isSuccess)
        {
            if (isSuccess < 0) throw new Exception("No Negative Probabilities !");
            else if (isSuccess > 0)
            {
                for (int i = 0; i < _evRunnerList.Count(); i++)
                    foreach (bool result in _evRunnerList[i].Results)
                        if (result == Event.SUCCESS)
                            return Event.SUCCESS;
                return Event.FAIL;
            }
            else
            {
                for (int i = 0; i < _evRunnerList.Count(); i++)
                    foreach (bool result in _evRunnerList[i].Results)
                        if (result == Event.FAIL)
                            return Event.SUCCESS;
                return Event.FAIL;
            }
        }

        public bool checkSMIN(int sMin)
        {
            if (sMin < 0) throw new Exception("No Negative Probabilities !");
            if (sMin > _evRunnerList.Count()) return Event.FAIL;
            if (sMin == 0) return Event.SUCCESS;
            if (sMin == 1) return checkOR(1);
            if (sMin == _evRunnerList.Count()) return checkAND(1);

            int sCount = 0;
            for (int i = 0; i < _evRunnerList.Count(); i++)
                foreach (bool result in _evRunnerList[i].Results)
                    if (result == Event.SUCCESS)
                        if (++sCount == sMin) return Event.SUCCESS;
            return Event.FAIL;
        }
        public bool checkFMIN(int fMin)
        {
            if (fMin < 0) throw new Exception("No Negative Probabilities !");
            if (fMin > _evRunnerList.Count()) return Event.FAIL;
            if (fMin == 0) return Event.SUCCESS;
            if (fMin == 1) return checkOR(0);
            if (fMin == _evRunnerList.Count()) return checkAND(0);

            int fCount = 0;
            for (int i = 0; i < _evRunnerList.Count(); i++)
                foreach (bool result in _evRunnerList[i].Results)
                    if (result == Event.FAIL)
                        if (++fCount == fMin) return Event.SUCCESS;
            return Event.FAIL;
        }

        public bool checkSMAX(int sMax)
        {
            return checkFMIN(_evRunnerList.Count() - sMax);
        }
        public bool checkFMAX(int fMax)
        {
            return checkSMIN(_evRunnerList.Count() - fMax);
        }

        public override bool checkSetMethods()
        {
            if (_checkMethods == null || _evRunnerList.Count==0)    // Always Fail if there are NO Checks OR NO Events present
                return false; 
            int i_cm = 0;
            foreach (CheckMethods checkMethod in _checkMethods.GetInvocationList())
                if (checkMethod(_checkParams[i_cm++]) == Event.FAIL)
                    return Event.FAIL;
            return Event.SUCCESS;
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
            {
                string msg;
                if (_evRunnerList.Count == 0) msg = "(" + Event.keywords[0] + ")";  // Is This Wise?
                else
                {
                    if (_evRunnerList[0].Repeat != 0)
                        msg = (_evRunnerList[0].Repeat == 1) ? _evRunnerList[0].getName() : _evRunnerList[0].Repeat + "x" + _evRunnerList[0].getName();
                    else
                        msg = "∅";
                    for (int i = 1; i < _evRunnerList.Count(); i++)
                        if (_evRunnerList[i].Repeat != 0)
                            msg += "+" + ((_evRunnerList[i].Repeat == 1) ? _evRunnerList[i].getName() : _evRunnerList[i].Repeat + "x" + _evRunnerList[i].getName());
                        else
                            msg += "+∅";
                    msg = "(" + msg + ")";
                }
                int i_cm = 0;
                if (_checkMethods == null) msg += "*??";
                else
                    foreach (var checkName in _checkMethods.GetInvocationList())
                        msg += "*" + checkName.Method.Name.Substring(5) + "[" + _checkParams[i_cm++] + "]";
                return msg;
            }
            else return _name;
        }
        public override string getMessage(int triesNr)
        {
            return "The Chance of Succes for " + getName() + " is: " + getChance(triesNr) + "% !";
        }
    }
}
