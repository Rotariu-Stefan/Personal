using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gclass
{
    public class Movement
    {
        private Zone zs;
        public Zone zoneS
        {
            get
            {
                return zs;
            }
        }

        private Zone zd;
        public Zone zoneD
        {
            get
            {
                return zd;
            }
        }

        private TimeSpan tm;
        public TimeSpan time
        {
            get
            {
                return tm;
            }
        }

        private Ulist u;
        public Ulist units
        {
            get
            {
                return u;
            }
        }

        private bool iatk;
        public bool isAtack
        {
            get
            {
                return iatk;
            }
        }

        private Movement() { }
        public Movement(Zone pzs, Zone pzd, Ulist pu, bool piatk)
        {
            if (pzs == null)
                throw new Exception("Starting zone inconsistent(null) !");
            if (pzd == null)
                throw new Exception("Destination zone inconsistent(null) !");
            if(pzd==pzs)
                throw new Exception("Cannot travel there(=) !");
            if (pu == null)
                throw new Exception("No units found in the atack(null) !");
            if (pu.calcNrtotal()==0)
                throw new Exception("No units found in the atack !");

            zs = pzs;
            zd = pzd;
            u = pu;
            int t = Math.Abs(zs.X - zd.X) + Math.Abs(zs.Y - zd.Y);
            tm = new TimeSpan(0, 0, t * 5);
            iatk = piatk;
        }
    }
}
