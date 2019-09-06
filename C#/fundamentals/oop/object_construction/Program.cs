using System;

namespace object_construction
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle myVehicle = new Vehicle();
            myVehicle.MakeNoise();
            myVehicle.ColorProp = "red";
            Console.WriteLine(myVehicle.ColorProp);
            myVehicle.what = "WHAT?!";
            Console.WriteLine(myVehicle.what);
        }
    }

    public class Vehicle{
        public int MaxNumPassengers;
        public string Color;
        public double MaxSpeed;

        public void MakeNoise(string noise = "BEEP!"){
            Console.WriteLine(noise);
        }

        public string ColorProp{
            get{
                return $"This thing is {Color}.";
            }
            set{
                Color = value;
            }
        }
        public string what{get;set;}
    }
}
