using System;
using System.Collections.Generic;

namespace collections_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            //Three Basic Arrays
            int[] intArray = {0,1,2,3,4,5,6,7,8,9};
            string[] strArray = {"Tim","Martin","Nikki","Sara"};
            bool[] boolArray = {true,false,true,false,true,false,true,false,true,false};

            //List of Flavors
            List<string> flavors = new List<string>();
            flavors.Add("vanilla");
            flavors.Add("chocolate");
            flavors.Add("strawberry");
            flavors.Add("coffee");
            flavors.Add("cookies and cream");
            Console.WriteLine(flavors.Count);
            Console.WriteLine(flavors[2]);
            flavors.RemoveAt(2);
            Console.WriteLine(flavors.Count);

            //User Info Dictionary
            Dictionary<string,string> dict = new Dictionary<string,string>();
            Random rand = new Random();
            foreach (string name in strArray){
                dict.Add(name,flavors[rand.Next(0,4)]);
            }
            foreach (KeyValuePair<string,string> entry in dict){
                Console.WriteLine($"{entry.Key}'s favorite ice cream flavor is {entry.Value}.");
            }
        }
    }
}
