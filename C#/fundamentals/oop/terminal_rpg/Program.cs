using System;
using System.Collections.Generic;

namespace terminal_rpg
{
    class Program
    {
        static void Main(string[] args)
        {
            Wizard gandalf = new Wizard("Gandalf");
            Ninja murosaki = new Ninja("Murosaki");
            Samurai jack = new Samurai("Jack");
            List<Human> allies = new List<Human>()
            {
                gandalf,murosaki,jack
            };

            List<Enemy> enemies = new List<Enemy>()
            {
                new Zombie(),new Zombie(),new Spider()
            };
            Random rand = new Random();
            Console.WriteLine("Enemy encounter:");
            foreach (Enemy enemy in enemies)
            {
                Console.WriteLine(enemy.Name);
            }
            Console.WriteLine("");

            while (allies.Count > 0 && enemies.Count > 0)
            {
                foreach (Human ally in allies)
                {
                    Console.WriteLine($"Select a move for {ally.Name} ({ally.Health} HP):");
                    Console.WriteLine("(1) Attack");
                    Console.WriteLine("(2) Special");
                    int attack = Convert.ToInt16(Console.ReadLine());
                    if (attack == 1)
                    {
                        Console.WriteLine("Select target:");
                        int i = 1;
                        foreach (Enemy enemy in enemies)
                        {
                            Console.WriteLine($"({i.ToString()}) {enemy.Name} ({enemy.Health})");
                            i++;
                        }
                        int target = Convert.ToInt16(Console.ReadLine());
                        ally.Attack(enemies[target - 1]);
                        Console.WriteLine("");
                        if (enemies[target - 1].Health <= 0)
                        {
                            Console.WriteLine($"{enemies[target - 1].Name} has been defeated!");
                            Console.WriteLine("");
                            enemies.RemoveAt(target-1);
                        }
                    }
                    if (attack == 2)
                    {
                        if (ally.Type == "Wizard")
                        {
                            Console.WriteLine("Select a party member to heal:");
                            int k = 1;
                            foreach (Human member in allies)
                            {
                                Console.WriteLine($"({k}) {member.Name} ({member.Health} HP)");
                                k++;
                            }
                            int healed = Convert.ToInt16(Console.ReadLine());
                            gandalf.Heal(allies[healed - 1]);
                            Console.WriteLine("");
                        }
                        if (ally.Type == "Ninja")
                        {
                            Console.WriteLine("Select target:");
                            int i = 1;
                            foreach (Enemy enemy in enemies)
                            {
                                Console.WriteLine($"({i.ToString()}) {enemy.Name} ({enemy.Health})");
                                i++;
                            }
                            int target = Convert.ToInt16(Console.ReadLine());
                            murosaki.Steal(enemies[target - 1]);
                            Console.WriteLine("");
                            if (enemies[target - 1].Health <= 0)
                            {
                                Console.WriteLine($"{enemies[target - 1].Name} has been defeated!");
                                enemies.RemoveAt(target-1);
                            }
                        }
                        if (ally.Type == "Samurai")
                        {
                            jack.Mediate();
                            Console.WriteLine("");
                        }
                    }
                }
                foreach (Enemy enemy in enemies)
                {
                    int rand_idx = rand.Next(0,allies.Count);
                    enemy.Attack(allies[rand_idx]);
                    if (allies[rand_idx].Health <= 0)
                    {
                        Console.WriteLine($"{allies[rand_idx].Name} has been defeated!");
                        allies.RemoveAt(rand_idx);
                    }
                }
                Console.WriteLine("");
            }
            if (allies.Count > 0)
            {
                Console.WriteLine("You won!");
            }
            else if (enemies.Count > 0)
            {
                Console.WriteLine("Your party has been defeated!");
            }
        }
    }

    class Human{
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        protected int health;
        protected string type;

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

        public string Type
        {
            get {return type;}
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

        public virtual int Attack(Enemy target)
        {
            int dmg = 5 * Strength;
            target.Health -= dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.Health;
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
            health = 75;
            type = "Wizard";
        }

        public override int Attack(Enemy target)
        {
            int dmg = Intelligence;
            target.Health -= dmg;
            health += (dmg / 5);
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage and recovered {dmg / 5} HP!");
            return target.Health;
        }

        public void Heal(Human target)
        {
            Random rand = new Random();
            int heal = rand.Next(1,11) * 5;
            target.Health += heal;
            if (target.Name == Name)
            {
                Console.WriteLine($"{Name} healed themselves and recovered {heal} HP!");
            }
            else
            {
                Console.WriteLine($"{Name} healed {target.Name} and restored {heal} HP!");
            }
        }
    }

    class Ninja : Human
    {
        public Ninja(string name) : base(name)
        {
            Dexterity = 25;
            type = "Ninja";
        }

        public override int Attack(Enemy target)
        {
            int dmg = Dexterity;
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

        public void Steal(Enemy target)
        {
            Random rand = new Random();
            int stolen = rand.Next(1,11) * 3;
            target.Health -= stolen;
            health += stolen;
            Console.WriteLine($"{Name} stole {stolen} HP from {target.Name}!");
        }
    }

    class Samurai : Human
    {
        public Samurai(string name) : base(name)
        {
            health = 200;
            type = "Samurai";
        }

        public override int Attack(Enemy target)
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

    abstract class Enemy
    {
        protected string name;
        protected int Strength;
        protected int Intelligence;
        protected int Dexterity;
        protected int health;

        public abstract string Name {get;}
        public abstract int Health {get;set;}
        public void Attack(Human target)
        {
            Random rand = new Random();
            int dmg = rand.Next(1,6) * Strength;
            target.Health -= dmg;
            Console.WriteLine($"{Name} attacked {target.Name} and did {dmg} damage!");
        }
    }

    class Zombie : Enemy
    {
        public Zombie()
        {
            name = "Zombie";
            Strength = 7;
            Intelligence = 0;
            Dexterity = 0;
            health = 250;
        }

        public override string Name
        {
            get {return name;}
        }
        public override int Health
        {
            get {return health;}
            set {health = value;}
        }
    }

    class Spider: Enemy
    {
        public Spider()
        {
            name = "Spider";
            Strength = 5;
            Intelligence = 5;
            Dexterity = 10;
            health = 200;
        }

        public override string Name
        {
            get {return name;}
        }
        public override int Health
        {
            get {return health;}
            set {health = value;}
        }
    }
}