using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gclass
{
    public class Player
    {
        private string nm;
        public string name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length > 20 || value.Length < 6)
                    throw new Exception("Name must be between 6 and 20 chars long !");
                else
                    nm = value;
            }
        }

        private int e;
        public int exp
        {
            get
            {
                return e;
            }
        }

        /*private List<Zone> zns;
        public List<Zone> zones
        {
            get
            {
                return zns;
            }
        }

        private List<Movement> mvs;
        public List<Movement> moves
        {
            get
            {
                return mvs;
            }
        }*/

        private Player() { }
        public Player(string pnm)
        {
            if (pnm.Length < 1 || pnm.Length > 30)
                throw new Exception("Player name must be between 1 and 30 chars long !");

            nm = pnm;
            e = 0;
        }

        public void addExp(int pe)
        {
            e += pe;
        }

        public void sendAtack(Zone zs,Zone zd, Ulist ul)
        {
            if (zs.owner != this)
                throw new Exception("Cannot send troops from this zone(not owned by this player) !");
            if (ul == null)
                throw new Exception("No army detected(null) !");

            zs.sendAtack(zd, ul);
        }
        public void sendSupport(Zone zs, Zone zd, Ulist ul)
        {
            if (zs.owner != this)
                throw new Exception("Cannot send troops from this zone(not owned by this player) !");
            if (ul == null)
                throw new Exception("No army detected(null) !");

            zs.sendSupport(zd, ul);
        }

        public void trainUnit(Zone z, Unit u)
        {
            if (u == null)
                throw new Exception("Cannot train that unit(null) !");

            z.startTraining(u);
        }
    }
}
