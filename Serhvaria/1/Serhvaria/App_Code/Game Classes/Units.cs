using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace gclass
{
    public class Ulist
    {
        private int peasantNr;
        public int pnr
        {
            get
            {
                return peasantNr;
            }
        }

        private int warriorNr;
        public int wnr
        {
            get
            {
                return warriorNr;
            }
        }

        private int defenderNr;
        public int dnr
        {
            get
            {
                return defenderNr;
            }
        }

        private int berserkerNr;
        public int bnr
        {
            get
            {
                return berserkerNr;
            }
        }

        private int cavalryNr;
        public int cnr
        {
            get
            {
                return cavalryNr;
            }
        }

        private int savageNr;
        public int snr
        {
            get
            {
                return savageNr;
            }
        }

        public Ulist() { }
        public Ulist(int ppnr, int pwnr, int pdnr, int pbnr, int pcnr, int psnr)
        {
            if (ppnr < 0 || pwnr < 0 || pdnr < 0 || pbnr < 0 || pcnr < 0 || psnr < 0)
                throw new Exception("Cannot have less than 0 units !");

            peasantNr = ppnr;
            warriorNr = pwnr;
            defenderNr = pdnr;
            berserkerNr = pbnr;
            cavalryNr = pcnr;
            savageNr = psnr;
        }

        public int calcDef()
        {
            return pnr * Peasant.def + wnr * Warrior.def + dnr * Defender.def + bnr * Berserker.def + cnr * Cavalry.def + snr * Savage.def;
        }
        public int calcAtk()
        {
            return pnr * Peasant.atk + wnr * Warrior.atk + dnr * Defender.atk + bnr * Berserker.atk + cnr * Cavalry.atk + snr * Savage.atk;
        }
        public int calcNrtotal()
        {
            return pnr + wnr + dnr + bnr + cnr + snr;
        }

        public void calcDeaths(float p)
        {
            peasantNr = (int)Math.Round(((float)peasantNr * p),0,MidpointRounding.AwayFromZero);
            warriorNr = (int)Math.Round(((float)warriorNr * p), 0, MidpointRounding.AwayFromZero);
            defenderNr = (int)Math.Round(((float)defenderNr * p), 0, MidpointRounding.AwayFromZero);
            berserkerNr = (int)Math.Round(((float)berserkerNr * p), 0, MidpointRounding.AwayFromZero);
            cavalryNr = (int)Math.Round(((float)cavalryNr * p), 0, MidpointRounding.AwayFromZero);
            savageNr = (int)Math.Round(((float)savageNr * p), 0, MidpointRounding.AwayFromZero);
        }

        public void inc(Unit pu)
        {
            string s = pu.GetType().Name.ToLower() + "Nr";
            FieldInfo f=this.GetType().GetField(s, BindingFlags.NonPublic | BindingFlags.Instance);

            if (f == null)
                throw new Exception("Unit type not found in list !");

            f.SetValue(this, (int)f.GetValue(this)+1);
        }
    }

    public abstract class Unit
    {
        protected string nm = "Default";
        protected string desc = "Default description.";
        protected int atk = 0;
        protected int def = 0;
        protected int time = 0;
    }

    public class Peasant : Unit
    {
        public new const string nm = "Peasant";
        public new const string desc = "Peasant: basic lowly peasant. Very weak, but trains very fast.";
        public new const int atk = 1;
        public new const int def = 1;
        public new const int time = 1;

        public static string toString()
        {
            return nm + ": " + desc + "\nAtack:" + atk + "\tDefence:" + def + "\tTraining time:" + time + "\n";
        }
    }

    public class Savage : Unit
    {
        public new const string nm = "Savage";
        public new const string desc = "Savage: neutral unit. Competant fighter. Protects resources and atacks nearby towns.";
        public new const int atk = 2;
        public new const int def = 3;
        public new const int time = 0;

        public static string toString()
        {
            return nm + ": " + desc + "\nAtack:" + atk + "\tDefence:" + def + "\tTraining time:" + time + "\n";
        }
    }

    public class Warrior : Unit
    {
        public new const string nm = "Warrior";
        public new const string desc = "Warrior: general-purpose infantry. Balanced stats, average training time.";
        public new const int atk = 3;
        public new const int def = 3;
        public new const int time = 5;

        public static string toString()
        {
            return nm + ": " + desc + "\nAtack:" + atk + "\tDefence:" + def + "\tTraining time:" + time + "\n";
        }
    }

    public class Defender : Unit
    {
        public new const string nm = "Defender";
        public new const string desc = "Defender: strong protector. High defence, low defence, slower training time.";
        public new const int atk = 2;
        public new const int def = 5;
        public new const int time = 10;

        public static string toString()
        {
            return nm + ": " + desc + "\nAtack:" + atk + "\tDefence:" + def + "\tTraining time:" + time + "\n";
        }
    }

    public class Berserker : Unit
    {
        public new const string nm = "Berserker";
        public new const string desc = "Berserker: atack infantry. High atack, very low defence, average training time";
        public new const int atk = 5;
        public new const int def = 1;
        public new const int time = 5;

        public static string toString()
        {
            return nm + ": " + desc + "\nAtack:" + atk + "\tDefence:" + def + "\tTraining time:" + time + "\n";
        }
    }

    public class Cavalry : Unit
    {
        public new const string nm = "Cavalry";
        public new const string desc = "Cavalry: elite fighter. High atack, very high defence, very slow training time";
        public new const int atk = 5;
        public new const int def = 7;
        public new const int time = 20;

        public static string toString()
        {
            return nm + ": " + desc + "\nAtack:" + atk + "\tDefence:" + def + "\tTraining time:" + time + "\n";
        }
    }

}
