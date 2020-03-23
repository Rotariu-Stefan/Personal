using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jocv1
{
    public class Zone
    {
        private string nm;
        public string name
        {
            get
            {
                return nm;
            }
        }

        private int hp=0;
        public int health
        {
            get
            {
                return hp;
            }
        }

        private int x;
        public int X
        {
            get
            {
                return x;
            }
        }

        private int y;
        public int Y
        {
            get
            {
                return y;
            }
        }

        private Terrain t;
        public Terrain T
        {
            get
            {
                return t;
            }
        }

        private Player o;
        public Player owner
        {
            get
            {
                return o;
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

        public Zone() { }
        public Zone(int px, int py, Terrain pt)
        {
            if (x > CT.mapX || x < 1)
                throw new Exception("Map size exceeded(x) !");
            if (y > CT.mapY || y < 1)
                throw new Exception("Map size exceeded(y) !");

            x = px;
            y = py;
            t = pt;
        }
        public Zone(int px, int py, Terrain pt, Player po, Ulist pu, string pnm)
            : this(px, py, pt)
        {
            if (po == null)
                throw new Exception("Owner not found(null) !");
            if (pnm.Length < 1 || pnm.Length > 30)
                throw new Exception("Player name must be between 1 and 30 chars long !");

            o = po;
            u = pu;
            hp = 100;
            nm = pnm;
        }

        public void sendAtack(Zone pd, Ulist pu)
        {
            if (pu.bnr < 0 || pu.cnr < 0 || pu.wnr < 0 || pu.pnr < 0 || pu.dnr < 0 || pu.snr < 0)
                throw new Exception("Cannot send less than 0 units !");
            if(pu.calcNrtotal()==0)
                throw new Exception("Must send at least 1 unit !");
            if (pu.bnr > u.bnr || pu.cnr > u.cnr || pu.wnr > u.wnr || pu.dnr > u.dnr || pu.pnr > u.pnr || pu.snr > u.snr)
                throw new Exception("Cannot send more units than you have !");

            u = new Ulist(u.pnr - pu.pnr, u.wnr - pu.wnr, u.dnr - pu.dnr, u.bnr - pu.bnr, u.cnr - pu.cnr, u.pnr - pu.pnr);
            map.movements.Add(new Movement(this, pd, pu, true));
        }
        public void receiveAtack(Movement pm)
        {
            if (pm.zoneD != this)
                throw new Exception("Wrong destination !");

            if (hp > 0)
            {
                int ud = units.calcDef(), ua = pm.zoneS.units.calcAtk();
                if (ud == 0)
                {
                    int htemp = hp;
                    damage(ua, 48);
                    map.reports.Add(new Report(DateTime.Now, htemp - hp, this, u, u, pm.zoneS, pm.units, pm.units));
                }
                else
                {
                    float rap = (float)(ua / ud);
                    if (rap < 0.1)
                        doBattle(pm, 100, 0, 0);
                    else if (rap < 0.25)
                        doBattle(pm, 90, 0, 0);
                    else if (rap < 0.5)
                        doBattle(pm, 75, 33, 0);
                    else if (rap < 0.75)
                        doBattle(pm, 67, 51, 5);
                    else if (rap < 1)
                        doBattle(pm, 60, 60, 10);
                    else if (rap < 1.1)
                        doBattle(pm, 51, 60, 11);
                    else if (rap < 1.25)
                        doBattle(pm, 45, 65, 12);
                    else if (rap < 1.5)
                        doBattle(pm, 35, 70, 15);
                    else if (rap < 1.75)
                        doBattle(pm, 25, 75, 20);
                    else if (rap < 2)
                        doBattle(pm, 15, 90, 25);
                    else if (rap < 2.5)
                        doBattle(pm, 10, 95, 30);
                    else if (rap > 2.5)
                        doBattle(pm, 0, 100, 33);
                }
            }
        }
        private void doBattle(Movement pm, int dProc, int aProc, int pdmax)
        {
            Ulist dtemp = u;
            Ulist atemp = pm.units;
            int htemp = hp;

            u.calcDeaths(dProc / 100);
            pm.units.calcDeaths(aProc / 100);
            damage(pm.units.calcAtk(), pdmax);

            sendReturn(pm.zoneS, pm.units);
            map.movements.Remove(pm);
            map.reports.Add(new Report(DateTime.Now, hp - htemp, this, dtemp, u, pm.zoneS, atemp, pm.units));
        }
        private void damage(int d, int max)
        {
            if (d > max)
                hp -= max;
            else
                hp -= d;
            if (hp < 0)
                hp = 0;
        }

        private void sendReturn(Zone pd, Ulist pu)
        {
            if (pu.calcNrtotal() == 0)
                return;
            map.movements.Add(new Movement(this, pd, pu, false));
        }
        public void receiveReturn(Movement pm)
        {
            if (pm.zoneD != this)
                throw new Exception("Wrong destination !");

            u = new Ulist(u.pnr + pm.units.pnr, u.wnr + pm.units.wnr, u.dnr + pm.units.dnr, u.bnr + pm.units.bnr, u.cnr + pm.units.cnr, u.pnr + pm.units.pnr);
            map.movements.Remove(pm);
        }

        public void sendSupport(Zone pd, Ulist pu)
        {
            if (pu.bnr < 0 || pu.cnr < 0 || pu.wnr < 0 || pu.pnr < 0 || pu.dnr < 0 || pu.snr < 0)
                throw new Exception("Cannot send less than 0 units !");
            if (pu.calcNrtotal() == 0)
                throw new Exception("Must send at least 1 unit !");
            if (pu.bnr > u.bnr || pu.cnr > u.cnr || pu.wnr > u.wnr || pu.dnr > u.dnr || pu.pnr > u.pnr || pu.snr > u.snr)
                throw new Exception("Cannot send more units than you have !");

            u = new Ulist(u.pnr - pu.pnr, u.wnr - pu.wnr, u.dnr - pu.dnr, u.bnr - pu.bnr, u.cnr - pu.cnr, u.pnr - pu.pnr);
            map.movements.Add(new Movement(this, pd, pu, false));
        }
        public void receiveSupport(Movement pm)
        {
            if (pm.zoneD != this)
                throw new Exception("Wrong destination !");

            u = new Ulist(u.pnr + pm.units.pnr, u.wnr + pm.units.wnr, u.dnr + pm.units.dnr, u.bnr + pm.units.bnr, u.cnr + pm.units.cnr, u.pnr + pm.units.pnr);
            map.movements.Remove(pm);
        }

        public void startTraining(Unit pu)
        {
            map.training.Add(new Training(new Warrior(), this));
        }
        public void recruit(Unit pu)
        {
            u.inc(pu);
        }
    }
}
