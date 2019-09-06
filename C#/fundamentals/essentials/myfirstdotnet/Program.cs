using System;

namespace myfirstdotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            string place = "Coding Dojo";
            Console.WriteLine($"Hello {place}");
            foreach (string arg in args){
                Console.WriteLine(arg);
            }
        }
    }
}
