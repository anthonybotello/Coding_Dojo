using System;
using System.Collections.Generic;

namespace puzzles
{
    class Program
    {
        //Random Array
        public static int[] RandomArray(){
            int[] randArr = new int[10];
            Random rand = new Random();
            for (int i = 0; i < 10; i++){
                randArr[i] = rand.Next(5,26);
            }
            int min = randArr[0];
            foreach (int number in randArr){
                if (number < min){
                    min = number;
                }
            }
            int max = randArr[0];
            foreach (int number in randArr){
                if (number > max){
                    max = number;
                }
            }
            int sum = 0;
            foreach (int number in randArr){
                sum += number;
            }
            Console.WriteLine($"Min: {min}, Max: {max}, Sum: {sum}, Average: {(float)sum/10}");
            return randArr;
        }

        //Coin Flip
        public static string TossCoin(){
            Console.WriteLine("Tossing a coin...");
            Random coin = new Random();
            int state = coin.Next(0,2);
            if (state == 0){
                Console.WriteLine("Heads");
                return "Heads";
            }
            else {
                Console.WriteLine("Tails");
                return "Tails";
            }
        }

        public static double TossMultipleCoins(int num){
            int heads = 0;
            for (int i = 1; i <= num; i++){
                string result = TossCoin();
                if (result == "Heads"){
                    heads++;
                }
            }
            return (double)heads/num;
        }

        //Names
        public static List<string> Names(){
            List<string> names = new List<string>();
            names.Add("Todd");
            names.Add("Tiffany");
            names.Add("Charlie");
            names.Add("Geneva");
            names.Add("Sydney");
            List<int> randomIdx = new List<int>();
            Random rand = new Random();
            while (randomIdx.Count < 5){
                int randomInt = rand.Next(0,5);
                bool inList = false;
                foreach (int number in randomIdx){
                    if (number == randomInt){
                        inList = true;
                    }
                }
                if (inList == false){
                    randomIdx.Add(randomInt);
                }
            }
            List<string> shuffled = new List<string>();
            foreach (int number in randomIdx){
                shuffled.Add(names[number]);
                Console.WriteLine(names[number]);
            }
            foreach (string name in shuffled){
                if (name.Length <= 5){
                    names.Remove(name);
                }
            }
            return names;
        }
        static void Main(string[] args)
        {
            RandomArray();
            TossCoin();
            Console.WriteLine(TossMultipleCoins(13));
            Names();
        }
    }
}
