using System;

namespace FirstCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Using Console.WriteLine, you can output any string to the terminal/console");

            string place = "Coding Dojo";

            string message = $"Hello {place}";

            Console.WriteLine(message);
            Console.WriteLine("The value of pi is " + 3.14159);
            Console.WriteLine($"My name is {0}, I am " + 28 + " years old", "Tim");

            // int numRings = 5;
            // int numAllStars = 17;
           // string name = "Kobe";
           bool crazy = true;

            // if (numRings >= 5 || numAllStars > 3) {
            //     Console.WriteLine($"Welcome, you are truly a legend, I guess...");
            // }
            // else if (numRings > 2) {
            //     Console.WriteLine($"Decent... but {numRings} rings aren't enough");
            // }
            // else {
            //     Console.WriteLine("Go win some more rings");
            // }
            if (!crazy){
                Console.WriteLine("Let's study the bible!");
            }
        }
    }
}
