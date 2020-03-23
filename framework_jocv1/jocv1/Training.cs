using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jocv1
{
    public class Training
    {
        private Unit u;
        public Unit unit
        {
            get
            {
                return u;
            }
        }

        private Zone z;
        public Zone zone
        {
            get
            {
                return z;
            }
        }

        private TimeSpan t;
        public TimeSpan time
        {
            get
            {
                return t;
            }
        }

        private Training() { }
        public Training(Unit pu, Zone pz)
        {
            u = pu;
            z = pz;
            int s = (int)u.GetType().GetField("time").GetRawConstantValue();
            t = new TimeSpan(0, 0, s);
        }
    }
}
