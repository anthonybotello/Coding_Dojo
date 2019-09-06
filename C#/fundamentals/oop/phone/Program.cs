using System;

namespace phone
{
    class Program
    {
        static void Main(string[] args)
        {
            Galaxy s8 = new Galaxy("s8",100,"T-Mobile","Dooo do doo dooo");
            Nokia elevenHundred = new Nokia("1100",60,"Metro PCS","Ringgg ring ringgg");

            s8.DisplayInfo();
            Console.WriteLine(s8.Ring());
            Console.WriteLine(s8.Unlock());
            Console.WriteLine("");

            elevenHundred.DisplayInfo();
            Console.WriteLine(elevenHundred.Ring());
            Console.WriteLine(elevenHundred.Unlock());
            Console.WriteLine("");
        }
    }

    public abstract class Phone
    {
        private string _versionNumber;
        private int _batteryPercentage;
        private string _carrier;
        private string _ringTone;
        public Phone(string versionNumber,int batteryPercentage,string carrier,string ringTone)
        {
            _versionNumber = versionNumber;
            _batteryPercentage = batteryPercentage;
            _carrier = carrier;
            _ringTone = ringTone;
        }
        public abstract void DisplayInfo();

        public string VersionNumber
        {
            get {return _versionNumber;}
        }
        public int BatteryPercentage
        {
            get {return _batteryPercentage;}
        }
        public string Carrier
        {
            get {return _carrier;}
        } 
        public string RingTone
        {
            get {return _ringTone;}
        }
    }

    public interface IRingable
    {
        string Ring();
        string Unlock();
    }

    public class Nokia : Phone, IRingable
    {
        public Nokia(string versionNumber, int batteryPercentage, string carrier, string ringTone) 
        : base(versionNumber, batteryPercentage, carrier, ringTone) {}
        public string Ring()
        {
            return $"... {RingTone} ...";
        }
        public string Unlock()
        {
            return $"Nokia {VersionNumber} unlocked with passcode.";
        }
        public override void DisplayInfo()
        {
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine($"Nokia {VersionNumber}");
            Console.WriteLine($"Battery Percentage: {BatteryPercentage}");
            Console.WriteLine($"Carrier: {Carrier}");
            Console.WriteLine($"Ring Tone: {RingTone}");
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("");
        }
    }
    public class Galaxy : Phone, IRingable 
    {
        public Galaxy(string versionNumber, int batteryPercentage, string carrier, string ringTone) 
            : base(versionNumber, batteryPercentage, carrier, ringTone) {}
        public string Ring() 
        {
            return $"... {RingTone} ...";
        }
                    
        public string Unlock() 
        {
            return $"Galaxy {VersionNumber} unlocked with fingerprint scanner.";
        }
        public override void DisplayInfo() 
        {
            Console.WriteLine("#########################");
            Console.WriteLine($"Galaxy {VersionNumber}");
            Console.WriteLine($"Battery Percentage: {BatteryPercentage}");
            Console.WriteLine($"Carrier: {Carrier}");
            Console.WriteLine($"Ring Tone: {RingTone}");
            Console.WriteLine("#########################");
            Console.WriteLine("");
        }
    }
}
