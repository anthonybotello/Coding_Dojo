using System;
using System.Collections.Generic;

namespace hungry_ninja
{
    class Program
    {
        static void Main(string[] args)
        {
            Buffet buffet = new Buffet();
            SweetTooth sweetninja = new SweetTooth();
            SpiceHound spicyninja = new SpiceHound();

            while (!sweetninja.IsFull){
                sweetninja.Consume(buffet.Serve());
            }
            Console.WriteLine(sweetninja.IsFull);

            while (!spicyninja.IsFull){
                spicyninja.Consume(buffet.Serve());
            }
            Console.WriteLine(spicyninja.IsFull);
            int sweet = sweetninja.ConsumptionHistory.Count;
            int spicy = spicyninja.ConsumptionHistory.Count;
            if (sweet > spicy)
            {
                Console.WriteLine($"sweetninja consumed the most at {sweet} items.");
            }
            else if (sweet < spicy)
            {
                Console.WriteLine($"spicyninja consumed the most at {spicy} items.");
            }
            else
            {
                Console.WriteLine("Both ninjas consumed the same number of items.");
            }
        }
    }

    class Food : IConsumable
    {
        public string Name {get;set;}
        public int Calories {get;set;}
        public bool IsSpicy {get;set;}
        public bool IsSweet {get;set;}
        public string GetInfo()
        {
            return $"{Name} (Food). Calories: {Calories}. Spicy?: {IsSpicy}, Sweet?: {IsSweet}";
        }
        public Food(string name,int cal,bool spicy, bool sweet)
        {
            Name = name;
            Calories = cal;
            IsSpicy = spicy;
            IsSweet = sweet;
        }
    }

    class Drink : IConsumable
    {
        public string Name {get;set;}
        public int Calories {get;set;}
        public bool IsSpicy {get;set;}
        public bool IsSweet {get;set;}
        public string GetInfo()
        {
            return $"{Name} (Drink). Calories: {Calories}. Spicy?: {IsSpicy}, Sweet?: {IsSweet}";
        }

        public Drink(string name,int cal,bool spicy)
        {
            Name = name;
            Calories = cal;
            IsSpicy = spicy;
            IsSweet = true;
        }
    }
        
    class Buffet
    {
        public List<IConsumable> Menu;

        public Buffet()
        {
            Menu = new List<IConsumable>()
            {
                new Food("Enchiladas",1000,true,false),
                new Food("Ice Cream",250,false,true),
                new Food("Hamburger",800,false,false),
                new Food("Gyro",600,true,false),
                new Food("Orange",50,false,true),
                new Food("Ramen",400,true,false),
                new Food("Cupcake", 300,false,true),
                new Drink("Sweet Tea",200,false),
                new Drink("Horchata",150,false),
                new Drink("Water",0,false),
                new Drink("Gatorade",100,false)
            };
        }

        public IConsumable Serve()
        {
            Random rand = new Random();
            int item = rand.Next(0,Menu.Count);
            return Menu[item];
        }
    }

    abstract class Ninja
    {
        protected int calorieIntake;
        public List<IConsumable> ConsumptionHistory;

        public Ninja()
        {
            calorieIntake = 0;
            ConsumptionHistory = new List<IConsumable>();
        }

        public abstract bool IsFull{get;}
        public abstract void Consume(IConsumable item);
    }

    class SweetTooth : Ninja
    {
        public override bool IsFull
        {
            get
            {
                if (calorieIntake > 1500)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public override void Consume(IConsumable item)
        {
            if (IsFull)
            {
                Console.WriteLine("Sweet ninja is full and can't eat anymore!");
            }
            else
            {
                calorieIntake += item.Calories;
                if (item.IsSweet)
                {
                    calorieIntake += 10;
                }
                ConsumptionHistory.Add(item);
                item.GetInfo();
            }
        }
    }

    class SpiceHound : Ninja
    {
        public override bool IsFull
        {
            get
            {
                if (calorieIntake > 1200)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public override void Consume(IConsumable item)
        {
            if (IsFull)
            {
                Console.WriteLine("Spicy ninja can't eat anymore!");
            }
            else
            {
                calorieIntake += item.Calories;
                if (item.IsSpicy)
                {
                    calorieIntake -= 5;
                }
                ConsumptionHistory.Add(item);
                item.GetInfo();
            }
        }
    }

    interface IConsumable
    {
        string Name {get;set;}
        int Calories {get;set;}
        bool IsSpicy {get;set;}
        bool IsSweet {get;set;}
        string GetInfo();
    }
}
