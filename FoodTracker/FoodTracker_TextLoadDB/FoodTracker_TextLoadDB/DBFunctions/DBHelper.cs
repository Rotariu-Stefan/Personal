using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace FoodTracker_TextLoadDB
{
    public static class DBHelper
    {
        public static String getCnnString(String cnnName)
        {
            return ConfigurationManager.ConnectionStrings[cnnName].ConnectionString;
        }
        public static String SelectAllFoodItems()
        {
            SqlConnection conn = new SqlConnection(DBHelper.getCnnString("FoodTracker"));
            conn.Open();

            SqlCommand com = new SqlCommand(@"SELECT * FROM FoodItems WHERE Brand='sv';", conn);
            SqlDataReader reader = com.ExecuteReader();
            String row = "";
            String rows = "";

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                    row += reader.GetValue(i) + " - ";
                rows += row + "\n";
                row = "";
            }

            reader.Close();
            com.Dispose();
            conn.Close();

            return rows;
        }
    }
}
