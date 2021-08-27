using System;
using System.Collections.Generic;
using System.Text;

namespace fighting_simulation
{
    public struct Monster
    {
       public string name;
       public float health;
       public float attack;
        public float defense;
    }
    class Game
    {

        public void Run()
        {
            //monster 1, the orc
            Monster monster1;
            monster1.name = "Wompus";
            monster1.attack = 10;
            monster1.defense = 5;
            monster1.health = 20;

            //monster 2, the goblin
            Monster monster2;
            monster2.name = "Mike";
            monster2.health = 10;
            monster2.attack = 10;
            monster2.defense = 10;

            //mosnter 3
            Monster monster3;
            monster3.name = "Kiki";
            monster3.health = 10;
            monster3.attack = 10;
            monster3.defense = 10;

            void PrintStats(Monster monster)
            {
                Console.WriteLine("name:" + monster.name);
                Console.WriteLine("health " + monster.health);
                Console.WriteLine("defense " + monster.defense);
                Console.WriteLine("attack " + monster.attack);
            }



            //monster 1 stats
            PrintStats(monster1);
            //monster 2 stats
            PrintStats(monster2);
            //monster 1 attacks monster 2
            float damageTaken = Fight(monster1, monster2);
            monster2.health = monster2.health -= damageTaken;
            Console.WriteLine(monster2.name + " has taken " + damageTaken + "damage");
            Console.ReadLine();
            Console.Clear();

            //monster 2 attacks monster 2

            damageTaken = Fight(monster2, monster1);
            monster1.health = monster1.health -= damageTaken;
            Console.WriteLine(monster1.name + " has taken " + damageTaken + " damage");
            Console.ReadLine();
            Console.Clear();

            float CalculateDamage(float attack, float defense)
            {
                float damage = attack - defense;
                if (damage <=0)
                {
                    damage = 0;
                }
                return damage;
            }

            float Calculatedamage(Monster attacker, Monster defender)
            {
                return attacker.attack - defender.defense;
            }
            void Fight(Monster attacker, Monster defender)
            { 
                float damageTaken = CalculateDamage(Monster attacker, Monster defender);
                defender.health = defender.health -= attacker.attack;
                Console.WriteLine(defender.name + " has taken " + damageTaken + "damage");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
