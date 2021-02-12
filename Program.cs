using System;
using System.Collections.Generic;

namespace HungryNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            //name of class
            var firstNinja = new Ninja();
            var firstBuffet = new Buffet();
            // var firstFoodHistory = new Ninja();

            while(!firstNinja.isFull)
            {
                var food = firstBuffet.Serve();
                firstNinja.Eat(food);
            }
            //the ninja is full
            firstNinja.Eat(firstBuffet.Serve()); 
            
        }
    }

    public class Food
    {
        public string Name;
        public int Calories;
        // Foods can be Spicy and/or Sweet
        public bool IsSpicy;
        public bool IsSweet;


        
        // add a constructor that takes in all four parameters: Name, Calories, IsSpicy, IsSweet
        // runs when we create a new instance
        public Food(string name, int calparam, bool spicyparam, bool sweetparam)
        {
            Name = name;
            Calories = calparam;
            IsSpicy = spicyparam;
            IsSweet = sweetparam;
        }
    }

    public class Buffet
    //class
    {
        public List<Food> Menu;


        public Buffet()
        //constructor
        {
            Menu = new List<Food>()
            {
                new Food("--SamguepSal", 1001, false, false),
                new Food("--Kalbi", 1002, false, true),
                new Food("--GeJang", 500, true, false),
                new Food("--Soon Doo Bu", 600, true, false),
                new Food("--JamBong", 750, true, false),
                new Food("--DokBokki", 200, true, true),
                new Food("--Pizza", 2000, false, true)
            };
        }

        public Food Serve()
        {
            Random rand = new Random();
                int randIdx = rand.Next(0, Menu.Count);

            // Console.WriteLine(Menu[randIdx]);
            
            return Menu[randIdx];

        }
    }

    public class Ninja
    {

        //these are fields
        private int calorieIntake;

        public int calIntake
        {
            get
            {
                return calorieIntake;
            }
        }
        public List<Food> FoodHistory;
                // add a constructor
        public Ninja(int cal = 0)
        {
            calorieIntake = cal;
            FoodHistory = new List<Food>();
        }

        // add a public "getter" property called "IsFull"
        public bool isFull
        {
            get{
                if(calorieIntake > 1200)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        // build out the Eat method
        public void Eat(Food item)
        {
            if(isFull)
            {
                Console.WriteLine("ninja is bloated");
            }
            else
            // adds calorie value to ninja's total calorieIntake
                calorieIntake += item.Calories;
            // adds the randomly selected Food object to ninja's FoodHistory list
                FoodHistory.Add(item);
            // writes the Food's Name - and if it is spicy/sweet to the console
            Console.WriteLine($"your food is {item.Name}; Spicy: {item.IsSpicy}; Sweet: {item.IsSweet};");
        }
    }
}
