using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace FoodTracker_TextLoadDB
{
    public static class DBCommands  //has static methods to insert and select data to/from FoodTracker Database
    {
        private static String priceDefault; //constains default DB value for the Price of Food Items
        public static void loadDefaults()   //select Sql Default Price value from database schema
        {
            DBHelper.conn.Open();

            DataRowCollection rows = DBHelper.selectStatement("SELECT COLUMN_DEFAULT FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'FoodItems' AND COLUMN_NAME = 'Price';", null);
            priceDefault = (String)rows[0][0];
            priceDefault = priceDefault.Replace("((", "").Replace("))", "");    //cleans up the format to get actual value

            DBHelper.conn.Close();
        }

        #region Inserts
        private static int InsertFoodItem(FoodItem food)    //inserts one Food Item
        {
            SqlParameter[] sparams = new SqlParameter[] {
                new SqlParameter("@FoodName", food._name),
                new SqlParameter("@Brand", food._brand)};
            DataRowCollection rows = DBHelper.selectStatement("SELECT * FROM FoodItems WHERE FoodName=@FoodName AND Brand=@Brand;", sparams);   //attempts to select This Food(the one tasked to be inserted) from FoodItems table
            if (rows.Count != 0)  //If FoodItem Already Exists Stop/do Nothing!
                return 0;

            //insert this Food Item into FoodItems table with parameters
            sparams = new SqlParameter[] {
                new SqlParameter("@FoodName",food._name),
                new SqlParameter("@Brand", food._brand),
                new SqlParameter("@Fat", food._fat),
                new SqlParameter("@Carbs", food._carbs),
                new SqlParameter("@Protein", food._protein),
                new SqlParameter("@SizeInfo", food._measure == Measure.Pieces ? 0 : (object)DBNull.Value),
                new SqlParameter("@UserID", 1),
                new SqlParameter("@Pic", DBNull.Value),
                new SqlParameter("@Price", priceDefault),
                new SqlParameter("@IsDish", food is Dish?true:false),
                new SqlParameter("@NoteID", DBNull.Value)};
            return DBHelper.insertStatement(
                "INSERT INTO FoodItems VALUES (@FoodName, @Brand, @Fat, @Carbs, @Protein, @SizeInfo, @UserID, @Pic, @Price, @IsDish, @NoteID);", sparams);
        }
        private static int InsertDishData(Dish dish)    //inserts into DishData table the Food Entries(junctures) for this Dish
        {   
            int affected = 0;

            if (dish.ingredients.Count != 0)
            {
                SqlParameter[] sparams = new SqlParameter[]{
                    new SqlParameter("@FoodName", dish._name),
                    new SqlParameter("@Brand", dish._brand)};
                DataRowCollection rows = DBHelper.selectStatement("SELECT FoodID FROM FoodItems WHERE FoodName=@FoodName AND Brand=@Brand;", sparams);  //selects DishID from FoodItems based on Name&Brand
                int dishID = Convert.ToInt32(rows[0][0]);

                int foodID;
                String comText = "INSERT INTO DishData VALUES";     //multirow Insert into DishData for Food Entries of this Dish
                List<SqlParameter> sparamsMultiline = new List<SqlParameter>();     //multirow Parameter list for Food Entries of this Dish
                sparamsMultiline.Add(new SqlParameter("@DishID", dishID));
                for (int i = 0; i < dish.ingredients.Count; i++)
                {
                    sparams = new SqlParameter[]{
                        new SqlParameter("@FoodName", dish.ingredients[i]._food._name),
                        new SqlParameter("@Brand", dish.ingredients[i]._food._brand)};
                    rows = DBHelper.selectStatement("SELECT FoodID FROM FoodItems WHERE FoodName=@FoodName AND Brand=@Brand;", sparams);    //select from FoodItems FoodID for currect FoodEntry that need to be inserted
                    foodID = Convert.ToInt32(rows[0][0]);

                    comText += $" (@DishID, @FoodID{i}, @Amount{i}, @Measure{i}),";      //addidng current Food Entry values/parameters to insert statement
                    sparamsMultiline.AddRange(new SqlParameter[] {
                    new SqlParameter($"@FoodID{i}", foodID),
                    new SqlParameter($"@Amount{i}", dish.ingredients[i]._amount),
                    new SqlParameter($"@Measure{i}", dish.ingredients[i]._food._measure.ToString())});
                }
                comText = comText.Remove(comText.Length - 1) + ";";     //replacing last comma with a ; for ending statement

                affected += DBHelper.insertStatement(comText, sparamsMultiline.ToArray());      //executing the insert into DishData for all Food Entries of this Dish
            }
            return affected;
        }
        public static int InsertFoodItems(List<FoodItem> foods) //Inserts multiple Food Items
        {   
            DBHelper.conn.Open();

            int affected = 0;
            int afftest = 0;    //used to see if food was actually inserted(already existed or not in DB)
            List<Dish> pendingDishes = new List<Dish>();    //saves Dish in list to introduce DishData After all basic FoodItem data has been entered(so i can be referenced in FK after)
            foreach (FoodItem food in foods)
            {
                afftest = InsertFoodItem(food);         //inserts FoodItem data
                if (afftest!=0 && food is Dish)         //if food didn't already exist and is a dish save it in a list to later introduce DishData ingredients  
                    pendingDishes.Add(food as Dish);
                affected += afftest;
            }
            foreach (Dish dish in pendingDishes)
                affected += InsertDishData(dish);           //inserts ingredient data in DishData juncture table for dishes

            DBHelper.conn.Close();
            return affected;
        }
        private static int InsertMeal(MealEntry meal, DateTime date)    //insert one MealEntry into DB
        {   
            int affected = 0;

            SqlParameter[] sparams = new SqlParameter[]{
            new SqlParameter("@MealName", meal._name),
            new SqlParameter("@TimeEaten", date)};
            DataRowCollection rows = DBHelper.selectStatement("SELECT * FROM Meals WHERE MealName=@MealName AND TimeEaten=@TimeEaten;", sparams);   //attempts to select This Meal(the one tasked to be inserted) from Meals table
            if (rows.Count != 0)  //If Meal Already Exists Stop/do Nothing!
                return 0;

            int noteID = 0;
            if (meal._note.ToString() != "")    //if the Meal has a Note
            {   
                sparams = new SqlParameter[]{
                new SqlParameter("@UserID", 1),
                new SqlParameter("@Title", "N"),
                new SqlParameter("@Score", meal._note.gradeAverage()),
                new SqlParameter("@NoteText", meal._note._text),
                new SqlParameter("@OfDay", DBNull.Value)};
                affected += DBHelper.insertStatement("INSERT INTO Notes VALUES(@UserID, @Title, @Score, @NoteText, @OfDay);", sparams);     //inserts Note for this Meal

                rows = DBHelper.selectStatement("SELECT IDENT_CURRENT ('Notes');", null);   //select last identity(PK) added for table Notes
                noteID = Convert.ToInt32(rows[0][0]);
            }

            sparams = new SqlParameter[]{
            new SqlParameter("@MealName", meal._name),
            new SqlParameter("@TimeEaten", date.ToString("yyyy/MM/dd")),
            new SqlParameter("@Portion", meal._portion),
            new SqlParameter("@UserID", 1),
            new SqlParameter("@NoteID", (noteID == 0 ? (object)DBNull.Value : noteID))};
            affected += DBHelper.insertStatement("INSERT INTO Meals VALUES (@MealName, @TimeEaten, @Portion, @UserID, @NoteID);", sparams);     //inserts entry for table Meals

            if (meal._foodEntries.Count != 0)
            {
                rows = DBHelper.selectStatement("SELECT IDENT_CURRENT ('Meals');", null);   //select last identity(PK) added for table Meals
                int mealID = Convert.ToInt32(rows[0][0]);

                int foodID;
                String comText = "INSERT INTO MealData VALUES";     //multirow Insert into MealData for Food Entries of this Meal
                List<SqlParameter> sparamsMultiline = new List<SqlParameter>();     //multirow Parameter list for Food Entries of this Meal
                sparamsMultiline.Add(new SqlParameter("@MealID", mealID));
                for (int i = 0; i < meal._foodEntries.Count; i++)
                {
                    sparams = new SqlParameter[]{
                    new SqlParameter("@FoodName", meal._foodEntries[i]._food._name),
                    new SqlParameter("@Brand", meal._foodEntries[i]._food._brand),
                    };
                    rows = DBHelper.selectStatement("SELECT FoodID FROM FoodItems WHERE FoodName=@FoodName AND Brand=@Brand;", sparams);    //select from FoodItems FoodID for currect FoodEntry that need to be inserted
                    foodID = Convert.ToInt32(rows[0][0]);

                    comText += $" (@MealID, @FoodID{i}, @Amount{i}, @Measure{i}),";      //addidng current Food Entry values/parameters to insert statement
                    sparamsMultiline.AddRange(new SqlParameter[] {
                    new SqlParameter($"@FoodID{i}", foodID),
                    new SqlParameter($"@Amount{i}", meal._foodEntries[i]._amount),
                    new SqlParameter($"@Measure{i}", meal._foodEntries[i]._food._measure.ToString())});
                }
                comText = comText.Remove(comText.Length - 1) + ";";     //replacing last comma with a ; for ending statement

                affected += DBHelper.insertStatement(comText, sparamsMultiline.ToArray());      //executing the insert into MealData for all Food Entries of this Meal
            }
            return affected;
        }
        private static int InsertDay(DayEntry day)  //insert one Day Entry data into DB
        {    
            int affected = 0;

            if (day._note.ToString() != "")     //attempts to select This Days Note the one tasked to be inserted) from Notes table
            {   
                SqlParameter[] sparams = new SqlParameter[] {
                new SqlParameter("@UserID", 1),
                new SqlParameter("@OfDay", day._date.ToString("yyyy/MM/dd"))};
                DataRowCollection rows = DBHelper.selectStatement("SELECT * FROM Notes WHERE UserID=@UserID AND OfDay=@OfDay;", sparams); //if day already exists do nothing
                if (rows.Count == 0)    //if note not found inside table..
                {   
                    sparams = new SqlParameter[] {
                    new SqlParameter("@UserID", 1),
                    new SqlParameter("@Title", "N"),
                    new SqlParameter("@Score", day._note.gradeAverage()),
                    new SqlParameter("@NoteText", day._note._text),
                    new SqlParameter("@OfDay", day._date.ToString("yyyy/MM/dd"))};
                    affected += DBHelper.insertStatement("INSERT INTO Notes VALUES(@UserID, @Title, @Score, @NoteText, @OfDay);", sparams); //insert Note for this Day into Notes with This Days Date
                }
            }

            foreach (MealEntry meal in day._mealEntries)        //insert Meals for this Day
                affected += InsertMeal(meal, day._date);

            return affected;
        }
        public static int InsertDays(List<DayEntry> days)   //insert multiple Day Entry data into DB
        {    
            DBHelper.conn.Open();

            int affected = 0;
            foreach (DayEntry day in days)
                affected += InsertDay(day);

            DBHelper.conn.Close();
            return affected;
        }
        #endregion

        #region Selects
        public static FoodItem SelectFoodItem(int FoodID, out int affected)     //selects one Food Item based on ID(PK)
        {   
            DBHelper.conn.Open();

            SqlParameter[] sparams = new SqlParameter[] { new SqlParameter("@FoodID", FoodID) };
            DataRowCollection rows = DBHelper.selectStatement("SELECT * FROM FoodItems WHERE FoodID=@FoodID;", sparams);
            if (rows.Count == 1)    //if food with respective ID was found
            {   
                affected = 1;

                if ((bool)rows[0]["IsDish"])    //if the food found is a Dish create a Dish
                {   
                    System.Windows.Forms.MessageBox.Show("CALL!!");
                    Dish foodDish= new Dish(rows[0]["FoodName"].ToString(), rows[0]["Brand"].ToString(),
                        (double)rows[0]["Fat"], (double)rows[0]["Carbs"], (double)rows[0]["Protein"],
                        rows[0]["SizeInfo"] == DBNull.Value ? Measure.Grams : Measure.Pieces);

                    rows = DBHelper.selectStatement("SELECT f.FoodName, f.Brand, f.Fat, f.Carbs, f.Protein, f.SizeInfo, dd.Amount " +
                        "FROM FoodItems f JOIN DishData dd ON f.FoodID=dd.IngredientID WHERE dd.DishID=@FoodID;", sparams);   //select FoodItems associated with this MealID(DishID in DishData) from DishData
                    foreach (DataRow row in rows)   //add the rows information as FoodEntry object to this newly made Dish
                    {                        
                        (foodDish as Dish).addFoodEntry(new FoodEntry(new FoodItem(row["FoodName"].ToString(), row["Brand"].ToString(),
                            (double)row["Fat"], (double)row["Carbs"], (double)row["Protein"],
                            row["SizeInfo"] == DBNull.Value ? Measure.Grams : Measure.Pieces), (double)row["Amount"]));
                        affected++;
                    }
                    return foodDish;
                }
                else
                {   //if the food found is not a Dish create a basic FoodItem
                    return new FoodItem(rows[0]["FoodName"].ToString(), rows[0]["Brand"].ToString(),
                        Convert.ToInt32(rows[0]["Fat"]), Convert.ToInt32(rows[0]["Carbs"]), Convert.ToInt32(rows[0]["Protein"]),
                        rows[0]["SizeInfo"] == DBNull.Value ? Measure.Grams : Measure.Pieces);
                }
            }
            else
            {   //if no food was found
                affected = 0;
                return null;
            }

            DBHelper.conn.Close();
        }
        private static MealEntry SelectMealEntry(int MealID, out int affected)  //select MealEntry from DB based on MealID given
        {   
            affected = 0;

            SqlParameter[] sparams = new SqlParameter[] { new SqlParameter("@MealID", MealID) };
            DataRowCollection rows = DBHelper.selectStatement("SELECT m.MealName, m.Portion, n.Score, n.NoteText " +
                "FROM Meals m LEFT JOIN Notes n ON m.NoteID=n.NoteID WHERE m.MealID=@MealID", sparams); //select Meal data for this Meal(based on ID) and its associated Note data
            if (rows.Count == 0)     //If No meal is found Stop/do Nothing
                return null;

            //create MealEntry object and populate some of its data
            MealEntry meal = new MealEntry();
            meal._name = rows[0]["MealName"].ToString();
            meal._portion = (double)rows[0]["Portion"];
            meal._note = new Note(rows[0]["Score"] == DBNull.Value ? "" : rows[0]["Score"].ToString(),
                rows[0]["NoteText"] == DBNull.Value ? "" : rows[0]["NoteText"].ToString());
            affected++;

            rows = DBHelper.selectStatement("SELECT f.FoodID, f.IsDish, f.FoodName, f.Brand, f.Fat, f.Carbs, f.Protein, f.SizeInfo, md.Amount " +
                "FROM FoodItems f JOIN MealData md ON f.FoodID=md.FoodID WHERE md.MealID=@MealID;", sparams);   //select FoodItems associated with this MealID from MealData
            foreach (DataRow row in rows)   //add the rows information as FoodEntry object to this newly made MealEntry
            {   
                if ((bool)row["IsDish"])    //if the food found is a Dish create a Dish and populate its data
                {   
                    Dish foodDish = new Dish(row["FoodName"].ToString(), row["Brand"].ToString(),
                        (double)row["Fat"], (double)row["Carbs"], (double)row["Protein"],
                        row["SizeInfo"] == DBNull.Value ? Measure.Grams : Measure.Pieces);

                    SqlParameter[] sparamsD = new SqlParameter[] { new SqlParameter("@DishID", row["FoodID"]) };
                    DataRowCollection rowsD = DBHelper.selectStatement("SELECT f.FoodName, f.Brand, f.Fat, f.Carbs, f.Protein, f.SizeInfo, dd.Amount " +
                        "FROM FoodItems f JOIN DishData dd ON f.FoodID=dd.IngredientID WHERE dd.DishID=@DishID;", sparamsD);   //select FoodItems associated with this FoodIF(DishID in DishData) from DishData
                    foreach (DataRow rowD in rowsD)     //add the rows information as FoodEntry object to this newly made Dish
                    {                        
                        foodDish.addFoodEntry(new FoodEntry(new FoodItem(rowD["FoodName"].ToString(), rowD["Brand"].ToString(),
                            (double)rowD["Fat"], (double)rowD["Carbs"], (double)rowD["Protein"],
                            rowD["SizeInfo"] == DBNull.Value ? Measure.Grams : Measure.Pieces), (double)rowD["Amount"]));
                        affected++;
                    }
                    meal.addFoodEntry(new FoodEntry(foodDish, (double)row["Amount"]));
                }
                else
                {   //if the food found is not a Dish create a basic FoodItem
                    FoodItem food= new FoodItem(row["FoodName"].ToString(), row["Brand"].ToString(),
                        (double)row["Fat"], (double)row["Carbs"], (double)row["Protein"],
                        row["SizeInfo"] == DBNull.Value ? Measure.Grams : Measure.Pieces);
                    meal.addFoodEntry(new FoodEntry(food, (double)row["Amount"]));
                }
                affected++;
            }

            meal.setCalculatedValues(); //calculate the final food values
            return meal;
        }
        private static DayEntry SelectDayEntry(DateTime date, out int affected) //selects one DayEntry from DB based on Date given
        {   
            affected = 0;

            SqlParameter[] sparams = new SqlParameter[] { new SqlParameter("@DayDate", date.ToString("yyyy/MM/dd")) };
            DataRowCollection rows = DBHelper.selectStatement("SELECT m.MealID FROM Meals m WHERE m.TimeEaten=@DayDate;", sparams); //selects Meals based on DayEaten
            if (rows.Count==0)    //If No day(meal entries for the Date) is found Stop/do Nothing
                return null;

            DayEntry day = new DayEntry();
            day._date = date;
            int affmeal;
            foreach(DataRow row in rows)    //adds Meals data into MealEntries for this newly made DayEntry
            {
                day.addMealEntry(SelectMealEntry(((int)row["MealID"]), out affmeal));
                affected += affmeal;
            }

            rows = DBHelper.selectStatement("SELECT n.Score, n.NoteTExt FROM Notes n WHERE n.OfDay=@DayDate;", sparams);    //selects Note data for this day from Notes
            if (rows.Count==1)      //creates Note for this DayEntry is data was found
            {   
                day._note = new Note(rows[0]["Score"] == DBNull.Value ? "" : rows[0]["Score"].ToString(),
                    rows[0]["NoteText"] == DBNull.Value ? "" : rows[0]["NoteText"].ToString());
                affected++;
            }

            day.setCalculatedValues();  //calculate the final food values
            return day;
        }
        public static List<DayEntry> SelectDayEntries(DateTime start, DateTime end, out int affected)   //selects multiple DayEntries from DB between 2 given dates
        {   
            DBHelper.conn.Open();

            affected = 0;
            List<DayEntry> dayList = new List<DayEntry>();  //list with DayEntries loaded
            DayEntry day = null;
            DateTime current = start;       //current date to check as going through the range
            while (current < end)
            {
                day = SelectDayEntry(current, out int affDay);
                if (day != null)            //if no entries were found with the current date
                    dayList.Add(day);
                affected += affDay;
                current = current.AddDays(1);
            }

            DBHelper.conn.Close();
            return dayList;
        }
        public static int SelectDayEntriesAll()     //selects ALL found data for Days from DB and populates/replaces the entire Days list with DayEntry objects
        {   
            MainForm.Days = SelectDayEntries(new DateTime(2019, 1, 1), DateTime.Now, out int affected);     //uses the previous method with range: 01/01/2019-Present
            return affected;
        }
        #endregion
    }
}
