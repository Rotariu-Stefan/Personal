using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gclass
{
    public class Report
    {
        private DateTime dt;
        public DateTime date
        {
            get
            {
                return dt;
            }
        }

        private int dmg;
        public int damage
        {
            get
            {
                return dmg;
            }
        }

        private Zone zd;
        public Zone zdef
        {
            get
            {
                return zd;
            }
        }
        private Ulist dbef;
        public Ulist dbefore
        {
            get
            {
                return dbef;
            }
        }
        private Ulist daf;
        public Ulist dafter
        {
            get
            {
                return daf;
            }
        }

        private Zone za;
        public Zone zatk
        {
            get
            {
                return za;
            }
        }
        private Ulist abef;
        public Ulist abefore
        {
            get
            {
                return abef;
            }
        }
        private Ulist aaf;
        public Ulist aafter
        {
            get
            {
                return aaf;
            }
        }

        private Report() { }
        public Report(DateTime pdt, int pdmg, Zone pzd, Ulist pdbef, Ulist pdaf, Zone pza, Ulist pabef, Ulist paaf)
        {
            if (pdt > DateTime.Now)
                throw new Exception("Invalid record date !");

            dt = pdt;
            dmg = pdmg;
            zd = pzd;
            daf = pdaf;
            dbef = pdbef;
            za = pza;
            abef = pabef;
            aaf = paaf;
        }
    }
}
