using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FoodTracker_TextLoadDB
{
    public class Dish : FoodItem        //Dish is a complex FoodItem that contains several other FoodItems(as ingredients) with respective amounts
    {   //TODO: Handle Grams/ML somehow!!
        public List<FoodEntry> ingredients     //ingredients for the dish
        { get; }

        #region Constructors    //various ways to initialize a dish - similar to basic FoodItem
        public Dish() : base() => ingredients = new List<FoodEntry>();
        public Dish(Match match) : base(match) => ingredients = new List<FoodEntry>();
        public Dish(string foodItemStr) : base(foodItemStr) => ingredients = new List<FoodEntry>();
        public Dish(string name, string brand, double fat, double carbs, double protein, Measure measure) :
            base(name, brand, fat, carbs, protein, measure) => ingredients = new List<FoodEntry>();
        public Dish(List<FoodEntry> foods, Match match) : base(match)   //init dish with regex match for food item values plus list of food entries ingredients
        {
            ingredients = new List<FoodEntry>();
            addFoodEntries(foods);
        }
        #endregion

        #region Adds    //various ways to add an ingredient to list        
        public void addFoodEntry(FoodEntry foodEntry)
        {
            ingredients.Add(foodEntry);
        }
        public void addFoodEntry(Match match)
        {
            ingredients.Add(new FoodEntry(match));
        }
        public void addFoodEntry(String foodEntryStr)
        {
            ingredients.Add(new FoodEntry(foodEntryStr));
        }
        public void addFoodEntries(List<FoodEntry> foods)
        {
            ingredients.AddRange(foods.ToArray());
        }
        #endregion

        #region Math
        public double calcFat()     //adds up the ingredients fat values to get dish sum
        {
            double fat = 0;
            foreach (FoodEntry fe in ingredients)
                fat += fe._fatEntry;
            return Math.Round(fat, 1);
        }
        public double calcCarbs()   //adds up the ingredients carbs values to get dish sum
        {
            double carbs = 0;
            foreach (FoodEntry fe in ingredients)
                carbs += fe._carbsEntry;
            return Math.Round(carbs, 1);
        }
        public double calcProtein() //adds up the ingredients protein values to get dish sum
        {
            double protein = 0;
            foreach (FoodEntry fe in ingredients)
                protein += fe._proteinEntry;
            return Math.Round(protein, 1);
        }
        public bool checkMacroEntries()     //checks to see if current macro entries are aprox. the same as calculated ones from ingredients
        {
            double calc = calcFat();
            if (Math.Abs(_fat - calc) > calc * 1 / 20 && calc > 1)
                return false;
            calc = calcCarbs();
            if (Math.Abs(_carbs - calc) > calc * 1 / 20 && calc > 1)
                return false;
            calc = calcProtein();
            if (Math.Abs(_protein - calc) > calc * 1 / 20 && calc > 1)
                return false;
            return true;
        }
        #endregion

        #region printing
        public String ToStringFull()    //get all Dish data in string format
        {
            String res = "";
            foreach (FoodEntry foodEntry in ingredients)
                res += foodEntry + "\n";
            res += $">===1 {_name} @{_brand} {_fat}/{_carbs}/{_protein}";
            return res;
        }
        public String ToStringListed()  //get Dish data in nicer string format
        {
            String res = ToStringNice() + "\n";
            foreach (FoodEntry foodEntry in ingredients)
                res += "\t" + foodEntry.ToStringLite() + "\n";
            return res;
        }
        #endregion
    }
}
