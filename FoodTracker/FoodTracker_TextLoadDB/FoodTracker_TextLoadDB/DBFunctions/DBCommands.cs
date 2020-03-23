using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace FoodTracker_TextLoadDB
{
    class DBCommands    //TODO:Figure out how to NOT write open/close connection All the Time...
                        //TODO:Function for SqlSelect Data+Insert etc. to modularise code?
    {                   //TODO:Stop getting 1line at a time in multi row queries
        public static int InsertFoodItems(FoodItem food)
        {
            SqlConnection conn = new SqlConnection(DBHelper.getCnnString("FoodTracker"));
            conn.Open();

            String comText = "SELECT * FROM FoodItems WHERE FoodName=@FoodName AND Brand=@Brand;";
            SqlCommand sql = new SqlCommand(comText, conn);
            sql.Parameters.AddWithValue("@FoodName", food._name);
            sql.Parameters.AddWithValue("@Brand", food._brand);
            SqlDataReader reader = sql.ExecuteReader();
            bool exists = reader.Read();
            reader.Close();
            sql.Dispose();

            if (exists)  //If FoodItem Already Exists Stop/do Nothing!
            {
                conn.Close();
                return 0;
            }

            comText = "SELECT COLUMN_DEFAULT FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'FoodItems' AND COLUMN_NAME = 'Price';";
            sql = new SqlCommand(comText, conn);
            reader = sql.ExecuteReader();
            reader.Read();
            String priceDefault = (String)reader[0];
            priceDefault = priceDefault.Replace("((", "").Replace("))", "");
            reader.Close();
            sql.Dispose();

            comText = "INSERT INTO FoodItems VALUES (@FoodName, @Brand, @Fat, @Carbs, @Protein, @SizeInfo, @UserID, @Pic, @Price, @IsDish, @NoteID);";
            sql = new SqlCommand(comText, conn);
            sql.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@FoodName",food._name),
                new SqlParameter("@Brand", food._brand),
                new SqlParameter("@Fat", food._fat),
                new SqlParameter("@Carbs", food._carbs),
                new SqlParameter("@Protein", food._protein),
                new SqlParameter("@SizeInfo", food._measure == Measure.Pieces ? 0 : (object)DBNull.Value),
                new SqlParameter("@UserID", 1),
                new SqlParameter("@Pic", DBNull.Value),
                new SqlParameter("@Price", priceDefault),
                new SqlParameter("@IsDish", false),
                new SqlParameter("@NoteID", DBNull.Value)
            });

            int affected = sql.ExecuteNonQuery();

            sql.Dispose();
            conn.Close();

            return affected;
        }
        public static int InsertFoodItems(List<FoodItem> foods)
        {
            int affected = 0;
            foreach (FoodItem food in foods)
                affected += InsertFoodItems(food);
            return affected;
        }
        private static int InsertMeal(MealEntry meal, DateTime date)
        {
            int affected = 0;
            SqlConnection conn = new SqlConnection(DBHelper.getCnnString("FoodTracker"));
            conn.Open();

            String comText = "SELECT * FROM Meals WHERE MealName=@MealName AND TimeEaten=@TimeEaten;";
            SqlCommand sql = new SqlCommand(comText, conn);
            sql.Parameters.AddWithValue("@MealName", meal._name);
            sql.Parameters.AddWithValue("@TimeEaten", date);
            SqlDataReader reader = sql.ExecuteReader();
            bool exists = reader.Read();
            reader.Close();
            sql.Dispose();

            if (exists)  //If Meal Already Exists Stop/do Nothing!
            {
                conn.Close();
                return 0;
            }

            int noteID = 0;
            if (meal._note.ToString() != "")
            {
                comText = "INSERT INTO Notes VALUES(@UserID, @Title, @Score, @NoteText, @OfDay);";
                sql = new SqlCommand(comText, conn);
                sql.Parameters.AddWithValue("@UserID", 1);
                sql.Parameters.AddWithValue("@Title", "N");
                sql.Parameters.AddWithValue("@Score", meal._note.gradeAverage());
                sql.Parameters.AddWithValue("@NoteText", meal._note._text);
                sql.Parameters.AddWithValue("@OfDay", DBNull.Value);
                affected += sql.ExecuteNonQuery();
                sql.Dispose();

                comText = "SELECT IDENT_CURRENT ('Notes');";
                sql = new SqlCommand(comText, conn);
                reader = sql.ExecuteReader();
                reader.Read();
                noteID = Convert.ToInt32(reader[0]);
                reader.Close();
                sql.Dispose();
            }

            comText = "INSERT INTO Meals VALUES (@MealName, @TimeEaten, @Portion, @UserID, @NoteID);";
            sql = new SqlCommand(comText, conn);
            sql.Parameters.AddWithValue("@MealName", meal._name);
            sql.Parameters.AddWithValue("@TimeEaten", date.ToString("yyyy/MM/dd"));
            sql.Parameters.AddWithValue("@Portion", meal._portion);
            sql.Parameters.AddWithValue("@UserID", 1);
            sql.Parameters.AddWithValue("@NoteID", (noteID == 0 ? (object)DBNull.Value : noteID));
            affected += sql.ExecuteNonQuery();
            sql.Dispose();


            if (meal._foodEntries.Count > 0)
            {
                comText = "SELECT MealID FROM Meals WHERE MealName=@MealName AND TimeEaten=@TimeEaten;";
                sql = new SqlCommand(comText, conn);
                sql.Parameters.AddWithValue("@MealName", meal._name);
                sql.Parameters.AddWithValue("@TimeEaten", date);
                reader = sql.ExecuteReader();
                reader.Read();
                int mealID = (int)reader[0];
                reader.Close();
                sql.Dispose();

                int foodID;
                SqlCommand sqlGetFood = new SqlCommand("SELECT FoodID FROM FoodItems WHERE FoodName=@FoodName AND Brand=@Brand;", conn);
                sqlGetFood.Parameters.AddWithValue("@FoodName", meal._foodEntries[0]._food._name);
                sqlGetFood.Parameters.AddWithValue("@Brand", meal._foodEntries[0]._food._brand);
                reader = sqlGetFood.ExecuteReader();
                reader.Read();
                foodID = (int)reader[0];
                reader.Close();
                sqlGetFood.Dispose();

                sql = new SqlCommand();
                comText = "INSERT INTO MealData VALUES (@MealID0, @FoodID0, @Amount0, @Measure0)";
                sql.Parameters.AddWithValue("@MealID0", mealID);
                sql.Parameters.AddWithValue("@FoodID0", foodID);
                sql.Parameters.AddWithValue("@Amount0", meal._foodEntries[0]._amount);
                sql.Parameters.AddWithValue("@Measure0", meal._foodEntries[0]._food._measure.ToString());

                for (int i = 1; i < meal._foodEntries.Count; i++)
                {
                    sqlGetFood = new SqlCommand("SELECT FoodID FROM FoodItems WHERE FoodName=@FoodName AND Brand=@Brand;", conn);
                    sqlGetFood.Parameters.AddWithValue("@FoodName", meal._foodEntries[i]._food._name);
                    sqlGetFood.Parameters.AddWithValue("@Brand", meal._foodEntries[i]._food._brand);
                    reader = sqlGetFood.ExecuteReader();
                    reader.Read();
                    foodID = (int)reader[0];
                    reader.Close();
                    sqlGetFood.Dispose();

                    comText += $", (@MealID{i}, @FoodID{i}, @Amount{i}, @Measure{i})";
                    sql.Parameters.AddWithValue($"@MealID{i}", mealID);
                    sql.Parameters.AddWithValue($"@FoodID{i}", foodID);
                    sql.Parameters.AddWithValue($"@Amount{i}", meal._foodEntries[i]._amount);
                    sql.Parameters.AddWithValue($"@Measure{i}", meal._foodEntries[i]._food._measure.ToString());
                }
                comText += ";";

                sql.CommandText = comText;
                sql.Connection = conn;
                affected += sql.ExecuteNonQuery();
                sql.Dispose();
            }
            conn.Close();

            return affected;
        }
        public static int InsertDays(DayEntry day)
        {
            int affected = 0;

            if (day._note.ToString() != "")
            {
                using (SqlConnection conn = new SqlConnection(DBHelper.getCnnString("FoodTracker")))
                {
                    conn.Open();

                    using (SqlCommand sqlsel = new SqlCommand("SELECT * FROM Notes WHERE UserID=@UserID AND OfDay=@OfDay;", conn))
                    {
                        sqlsel.Parameters.AddWithValue("@UserID", 1);
                        sqlsel.Parameters.AddWithValue("@OfDay", day._date.ToString("yyyy/MM/dd"));
                        using (SqlDataReader reader = sqlsel.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                reader.Close();
                                using (SqlCommand sql = new SqlCommand("INSERT INTO Notes VALUES(@UserID, @Title, @Score, @NoteText, @OfDay);", conn))
                                {
                                    sql.Parameters.AddWithValue("@UserID", 1);
                                    sql.Parameters.AddWithValue("@Title", "N");
                                    sql.Parameters.AddWithValue("@Score", day._note.gradeAverage());
                                    sql.Parameters.AddWithValue("@NoteText", day._note._text);
                                    sql.Parameters.AddWithValue("@OfDay", day._date.ToString("yyyy/MM/dd"));
                                    affected += sql.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
            }

            foreach (MealEntry meal in day._mealEntries)
                affected += InsertMeal(meal, day._date);

            return affected;
        }
        public static int InsertDays(List<DayEntry> days)
        {
            int affected = 0;
            foreach (DayEntry day in days)
                affected += InsertDays(day);
            return affected;
        }

        public static FoodItem SelectFoodItem(int FoodID, out int affected)
        {
            FoodItem food = null;
            affected = 0;
            SqlConnection conn = new SqlConnection(DBHelper.getCnnString("FoodTracker"));
            conn.Open();

            SqlCommand sql = new SqlCommand("SELECT * FROM FoodItems WHERE FoodID=@FoodID;", conn);
            sql.Parameters.AddWithValue("@FoodID", FoodID);
            SqlDataReader reader = sql.ExecuteReader();
            if (reader.Read())
            {
                food = new FoodItem(reader["FoodName"].ToString(), reader["Brand"].ToString(),
                    Convert.ToInt32(reader["Fat"]), Convert.ToInt32(reader["Carbs"]), Convert.ToInt32(reader["Protein"]),
                    reader["SizeInfo"] == DBNull.Value ? Measure.Grams : Measure.Pieces);
                affected++;
            }

            reader.Close();
            sql.Dispose();
            conn.Close();
            return food;
        }
        private static MealEntry SelectMealEntry(int MealID, out int affected)
        {
            affected = 0;
            SqlConnection conn = new SqlConnection(DBHelper.getCnnString("FoodTracker"));
            conn.Open();
            String comText = "SELECT m.MealName, m.Portion, n.Score, n.NoteText " +
                "FROM Meals m LEFT JOIN Notes n ON m.NoteID=n.NoteID " +
                "WHERE m.MealID=@MealID";
            SqlCommand sql = new SqlCommand(comText, conn);
            sql.Parameters.AddWithValue("@MealID", MealID);
            SqlDataReader reader = sql.ExecuteReader();
            if (!reader.Read())     //If No meal is found Stop/do Nothing
            {
                conn.Close();
                return null;
            }

            MealEntry meal = new MealEntry();
            meal._name = reader["MealName"].ToString();
            meal._portion = (double)reader["Portion"];
            meal._note = new Note(reader["Score"] == DBNull.Value ? "" : reader["Score"].ToString(),
                reader["NoteText"] == DBNull.Value ? "" : reader["NoteText"].ToString());
            affected++;
            reader.Close();
            sql.Dispose();


            comText = "SELECT f.FoodName, f.Brand, f.Fat, f.Carbs, f.Protein, f.SizeInfo, md.Amount " +
                "FROM FoodItems f JOIN MealData md ON f.FoodID=md.FoodID " +
                "WHERE md.MealID=@MealID;";
            sql = new SqlCommand(comText, conn);
            sql.Parameters.AddWithValue("@MealID", MealID);
            reader = sql.ExecuteReader();
            while (reader.Read())
            {
                meal.addFoodEntry(new FoodEntry(new FoodItem(reader["FoodName"].ToString(), reader["Brand"].ToString(),
                    (double)reader["Fat"], (double)reader["Carbs"], (double)reader["Protein"],
                    reader["SizeInfo"] == DBNull.Value ? Measure.Grams : Measure.Pieces), (double)reader["Amount"]));
                affected++;
            }
            reader.Close();
            sql.Dispose();
            conn.Close();

            meal.checkAndCorrect();
            return meal;
        }
        public static DayEntry SelectDayEntry(DateTime date, out int affected)
        {
            affected = 0;
            SqlConnection conn = new SqlConnection(DBHelper.getCnnString("FoodTracker"));
            conn.Open();

            String comText = "SELECT m.MealID FROM Meals m WHERE m.TimeEaten=@DayDate;";
            SqlCommand sql = new SqlCommand(comText, conn);
            sql.Parameters.AddWithValue("@DayDate", date.ToString("yyyy/MM/dd"));
            SqlDataReader reader = sql.ExecuteReader();
            if (!reader.HasRows)    //If No day(meal entries for the Date) is found Stop/do Nothing
            {
                conn.Close();
                return null;
            }

            DayEntry day = new DayEntry();
            int affmeal;
            day._date = date;
            while (reader.Read())
            {
                day.addMealEntry(SelectMealEntry(((int)reader["MealID"]), out affmeal));
                affected += affmeal;
            }
            reader.Close();
            sql.Dispose();

            comText = "SELECT n.Score, n.NoteTExt FROM Notes n WHERE n.OfDay=@DayDate;";
            sql = new SqlCommand(comText, conn);
            sql.Parameters.AddWithValue("@DayDate", date.ToString("yyyy/MM/dd"));
            reader = sql.ExecuteReader();
            if (reader.Read())
            {
                day._note = new Note(reader["Score"] == DBNull.Value ? "" : reader["Score"].ToString(),
                    reader["NoteText"] == DBNull.Value ? "" : reader["NoteText"].ToString());
                affected++;
            }
            reader.Close();
            sql.Dispose();
            conn.Close();

            day.checkAndCorrect();
            return day;
        }
        public static List<DayEntry> SelectDayEntries(DateTime start, DateTime end, out int affected)
        {
            affected = 0;
            List<DayEntry> dayList = new List<DayEntry>();
            DayEntry day = null;
            DateTime current = start;
            while (current < end)
            {
                day = SelectDayEntry(current, out int affDay);
                if (day != null)
                    dayList.Add(day);
                affected += affDay;
                current = current.AddDays(1);
            }
            return dayList;
        }
        public static int SelectIntoDaysAll()
        {
            MainForm.Days = SelectDayEntries(new DateTime(2019, 1, 1), DateTime.Now, out int affected);
            return affected;
        }
    }
}
