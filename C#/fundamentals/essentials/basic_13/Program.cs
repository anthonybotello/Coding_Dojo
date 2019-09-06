using System;

namespace basic_13
{
    class Program
    {
        //1
        public static void PrintNumbers(){
            for (int i = 1; i <= 255; i++){
                Console.WriteLine(i);
            }
        }

        //2
        public static void PrintOdds(){
            for (int i = 1; i <= 255; i++){
                if (i % 2 != 0){
                    Console.WriteLine(i);
                }
            }
        }

        //3
        public static void PrintSum(){
            int sum = 0;
            for (int i = 1; i <= 255; i++){
                sum += i;
                Console.WriteLine($"New number: {i}, Sum: {sum}");
            }
        }

        //4
        public static void LoopArray(int[] numbers){
            foreach (int number in numbers){
                Console.WriteLine(number);
            }
        }

        //5
        public static void FindMax(int[] numbers){
            int max = numbers[0];
            foreach (int number in numbers){
                if (number > max){
                    max = number;
                }
            }
            Console.WriteLine(max);
        }

        //6
        public static void GetAverage(int[] numbers){
            float avg = 0;
            foreach (int number in numbers){
                avg += ((float)number / (float)numbers.Length);
            }
            Console.WriteLine(avg);
        }

        //7
        public static int[] OddArray(){
            int[] odd_array = new int[128];
            for (int i = 0; i <= 127; i++){
                odd_array[i] = 2*i + 1;
            }
            return odd_array;
        }

        //8
        public static int GreaterThanY(int[] numbers, int y){
            int count = 0;
            foreach (int number in numbers){
                if (number > y){
                    count++;
                }
            }
            return count;
        }

        //9
        public static void SquareArrayValues(int[] numbers){
            for (int i = 0; i < numbers.Length; i++){
                numbers[i] *= numbers[i];
            }
        }

        //10
        public static void EliminateNegatives(int[] numbers){
            for (int i = 0; i < numbers.Length; i++){
                if (numbers[i] < 0){
                    numbers[i] = 0;
                }
            }
        }

        //11
        public static void MinMaxAverage(int[] numbers){
            int min = numbers[0];
            foreach (int number in numbers){
                if (number < min){
                    min = number;
                }
            }
            int max = numbers[0];
            foreach (int number in numbers){
                if (number > max){
                    max = number;
                }
            }
            float avg = 0;
            foreach (int number in numbers){
                avg += ((float)number / (float)numbers.Length);
            }
            Console.WriteLine($"Min: {min}, Max: {max}, Average: {avg}");
        }

        //12
        public static void ShiftValues(int[] numbers){
            for (int i = 0; i < numbers.Length - 1;i++){
                numbers[i] = numbers[i+1];
            }
            numbers[numbers.Length - 1] = 0;
        }

        //13
        public static object[] NumToString(int[] numbers){
            object[] objArr = new object[numbers.Length];
            for (int i = 0; i < numbers.Length; i++){
                if (numbers[i] < 0){
                    objArr[i] = "Dojo";
                }
                else {
                    objArr[i] = numbers[i];
                }
            }
            return objArr;
        }
        

        static void Main(string[] args)
        {
            PrintNumbers();
            PrintOdds();
            PrintSum();
            int[] array = {1,2,4,7,9,0,2,3,-1,6,-4};
            LoopArray(array);
            FindMax(array);
            FindMax(new int[] {-3,-5,-7});
            GetAverage(new int[] {2,10,3});
            foreach (int number in OddArray()){
                Console.WriteLine(number);
            }
            Console.WriteLine(GreaterThanY(new int[] {1,3,5,7}, 3));
            SquareArrayValues(new int[] {1,5,10,-10});
            EliminateNegatives(new int[] {1,5,10,-2});
            MinMaxAverage(new int[] {1,5,10,-2});
            ShiftValues(new int[] {1,5,10,7,-2});
            foreach (var val in NumToString(new int[] {-1,-3,2})){
                Console.WriteLine(val);
            }
        }
    }
}
