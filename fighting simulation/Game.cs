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
        bool gameOver = false;
        Monster currentMonster1;
        Monster currentMonster2;
        int currentMonsterIndex = 1;
        public void Run()
        {
            //monster 1
            Monster Wompus;
            Wompus.name = "Wompus";
            Wompus.attack = 10.0f;
            Wompus.defense = 5.0f;
            Wompus.health = 20.0f;

            //monster 2
            Monster Mike;
            Mike.name = "Mike";
            Mike.health = 10.0f;
            Mike.attack = 10.0f;
            Mike.defense = 10.0f;

            //monster 3
            Monster Kiki;
            Kiki.name = "Kiki";
            Kiki.health = 10.0f;
            Kiki.attack = 10.0f;
            Kiki.defense = 10.0f;

            //monster 4
            Monster Cory;
            Cory.name = "Cory";
            Cory.health = 1.0f;
            Cory.attack = 1.0f;
            Cory.defense = 1.0f;

            void Update()
            {
                Battle();
            }
            Monster monster;
            monster.name = "None";
            monster.attack = 1;
            monster.defense = 1;
            monster.health = 1;
            Monster GetMonster(int monsterIndex)
            {
                if (monsterIndex == 1)
                {
                    monster = Cory;
                }
                else if (monsterIndex == 2)
                {
                    monster = Kiki;
                }
                else if (monsterIndex == 3)
                {
                    monster = Wompus;
                }
                else if (monsterIndex ==4)
                {
                    monster = Mike;
                }
                return monster;
            }

            void Battle()
            {
                //Print monster1 stats
                PrintStats(currentMonster1);
                //Print monster2 stats
                PrintStats(currentMonster2);

                //Monster 1 attacks monster 2
                float damageTaken = Fight(currentMonster1, ref currentMonster2);
                Console.WriteLine(currentMonster2.name + " has taken " + damageTaken + " damage");

                //Monster 2 attacks monster 1

                damageTaken = Fight(currentMonster2, ref currentMonster1);
                Console.WriteLine(currentMonster1.name + " has taken " + damageTaken + " damage");
            }

            void UpdateCurrentMonster()
            {
                if 
            }
        }

        float Fight( Monster attacker, Monster defender)
        {
            float damageTaken = CalculateDamage(attacker, defender);
            defender.health -= damageTaken;
            return damageTaken;
        }

        void PrintStats(Monster monster)
        {
            Console.WriteLine("Name: " + monster.name);
            Console.WriteLine("Health: " + monster.health);
            Console.WriteLine("Attack: " + monster.attack);
            Console.WriteLine("Defense: " + monster.defense);
        }

        float CalculateDamage(float attack, float defense)
        {
            float damage = attack - defense;

            if (damage <= 0)
            {
                damage = 0;
            }

            return damage;
        }

        float CalculateDamage(Monster attacker, Monster defender)
        {
            return attacker.attack - defender.defense;
        }
    }
}
