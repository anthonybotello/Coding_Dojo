using System;

namespace human
{
    class Human{
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        private int health;

        public int Health
        {
            get{
                return health;
            }
        }

        public Human(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
        }

        public Human(string name, int str, int intel, int dext, int hp)
        {
            Name = name;
            Strength = str;
            Intelligence = intel;
            Dexterity = dext;
            health = hp;
        }

        public int Attack(Human target)
        {
            target.health -= (5 * Strength);
            return target.health;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Human me = new Human("Anthony");
            Human opm = new Human("Saitama",10000000,1,1,1005);
            while (opm.Health > 0)
            {
                Console.WriteLine(me.Attack(opm));
            }
        }
    }
}
