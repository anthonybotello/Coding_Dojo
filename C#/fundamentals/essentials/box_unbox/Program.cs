using System;
using System.Collections.Generic;

namespace box_unbox
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Object> list = new List<Object>();
            list.Add(7);
            list.Add(28);
            list.Add(-1);
            list.Add(true);
            list.Add("chair");
            foreach (var val in list){
                Console.WriteLine(val);
            }
            int sum = 0;
            foreach (var val in list){
                if (val is int){
                    sum += (int)val;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
