using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace gclass
{
    public enum Terrain
    {
        grass = 1,
        rock = 2,
        desert = 3,
    }

    public static class CT
    {
        public const int mapX = 20;
        public const int mapY = 20;
        public static SqlConnection serConn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["serConn"].ConnectionString);
    }

    public static class map
    {
        public static Zone[,] zones = new Zone[CT.mapX, CT.mapY];
        public static List<Player> players = new List<Player>();
        public static List<Movement> movements = new List<Movement>();
        public static List<Report> reports = new List<Report>();
        public static List<Training> training = new List<Training>();
        
    }
}
