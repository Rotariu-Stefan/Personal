using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace FoodTracker_TextLoadDB
{
    public static class DBHelper        //constains various generic global static methods to help streamline database access and associated code
    {
        public static readonly SqlConnection conn = new SqlConnection(DBHelper.getCnnString("FoodTracker"));    //default localhost FoodTracker connection
        public static String getCnnString(String cnnName)   //gets connection string from App.config based on String Name given
        {
            return ConfigurationManager.ConnectionStrings[cnnName].ConnectionString;
        }
        public static void TestConn()   //tests if connection is open
        {
            if (conn.State == ConnectionState.Open)
                MessageBox.Show("OPEN!");
            else
                MessageBox.Show("CLOSED!");
        }

        public static String SelectAllFoodItems()   //returns a string with all foods(from owner) older function
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

        public static DataRowCollection selectStatement(String comtext, SqlParameter[] sparams)     //performs generic SQL select statement with parameters and returns values found
        {   
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(comtext, conn);
            if (sparams != null)
                adapter.SelectCommand.Parameters.AddRange(sparams);
            DataTable data = new DataTable();
            adapter.Fill(data);

            adapter.SelectCommand.Parameters.Clear();
            adapter.Dispose();
            return data.Rows;
        }
        public static int insertStatement(String comtext, SqlParameter[] sparams)       //performs generic SQL Insert statement with parameters and returns nr. of affected rows
        {   
            SqlCommand sql = new SqlCommand(comtext, conn);
            if(sparams!=null)
                sql.Parameters.AddRange(sparams);
            int affected = sql.ExecuteNonQuery();

            sql.Dispose();
            return affected;
        }
    }
}
