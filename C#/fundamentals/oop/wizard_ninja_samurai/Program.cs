using System;

namespace wizard_ninja_samurai
{
    class Human{
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        protected int health;

        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
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

        public virtual int Attack(Human target)
        {
            int dmg = 5 * Strength;
            target.health -= dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.health;
        }

        public void Stats()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"HP: {health}");
            Console.WriteLine($"Str: {Strength}");
            Console.WriteLine($"Int: {Intelligence}");
            Console.WriteLine($"Dex: {Dexterity}");
        }
    }

    class Wizard : Human
    {
        public Wizard(string name) : base(name)
        {
            Intelligence = 25;
            health = 50;
        }

        public override int Attack(Human target)
        {
            int dmg = 5* Intelligence;
            target.Health -= dmg;
            health += dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage and recovered {dmg} HP!");
            return target.Health;
        }

        public void Heal(Human target)
        {
            int heal = 10 * Intelligence;
            target.Health += heal;
            Console.WriteLine($"{Name} healed {target.Name} and restored {heal} HP!");
        }
    }

    class Ninja : Human
    {
        public Ninja(string name) : base(name)
        {
            Dexterity = 175;
        }

        public override int Attack(Human target)
        {
            int dmg = 5 * Dexterity;
            Random rand = new Random();
            int crit = rand.Next(0,5);
            if (crit == 3)
            {
                dmg += 10;
            }
            target.Health -= dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.Health;
        }

        public void Steal(Human target)
        {
            target.Health -= 5;
            health += 5;
            Console.WriteLine($"{Name} stole 5 HP from {target.Name}!");
        }
    }

    class Samurai : Human
    {
        public Samurai(string name) : base(name)
        {
            health = 200;
        }

        public override int Attack(Human target)
        {
            if (target.Health < 50)
            {
                target.Health = 0;
                Console.WriteLine($"{Name} attacked {target.Name} and reduced their HP to 0!");
                return target.Health;
            }
            else
            {
                return base.Attack(target);
            }
        }

        public void Mediate()
        {
            health = 200;
            Console.WriteLine($"{Name} restored themselves to full health!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Wizard gandalf = new Wizard("Gandalf");
            gandalf.Stats();

            Ninja murosaki = new Ninja("Murosaki");
            murosaki.Stats();

            Samurai jack = new Samurai("Jack");
            jack.Stats();

            // gandalf.Attack(jack);
            // gandalf.Stats();
            // jack.Stats();

            // murosaki.Attack(gandalf);
            // gandalf.Stats();

            // while (murosaki.Health > 50)
            // {
            //     jack.Attack(murosaki);
            // }
            // jack.Attack(murosaki);
            // murosaki.Stats();

            // gandalf.Heal(murosaki);
            // murosaki.Stats();

            // gandalf.Attack(jack);
            // jack.Stats();
            // jack.Mediate();
            // jack.Stats();

            // Console.WriteLine(murosaki.Health);
            // Console.WriteLine(gandalf.Health);
            // murosaki.Steal(gandalf);
            // Console.WriteLine(murosaki.Health);
            // Console.WriteLine(gandalf.Health);
        }
    }
}