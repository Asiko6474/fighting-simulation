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
        //The names of the monsters will be stored here
        Monster Wompus;
        Monster Mike;
        Monster Kiki;
        Monster Cory;


        bool gameOver = false;
        Monster currentMonster1;
        Monster currentMonster2;
        int currentMonsterIndex = 0;
        int currentScene = 0;

        public void Run()
        {
            PrintNumbers();
            Start();

            while (!gameOver)
            {
                Update();
            }

            End();
        }

        void PrintNumbers()
        {
            int[] numbers = new int[5] { 0, 1, 2, 3, 4 };
            Console.WriteLine(String.Join(",", numbers));
        }
        void Start()
        {
            //monster 1

            Wompus.name = "Wompus";
            Wompus.attack = 15.0f;
            Wompus.defense = 5.0f;
            Wompus.health = 20.0f;

            //monster 2

            Mike.name = "Mike";
            Mike.health = 20.0f;
            Mike.attack = 10.0f;
            Mike.defense = 10.0f;

            //monster 3

            Kiki.name = "Kiki";
            Kiki.health = 30.0f;
            Kiki.attack = 10.0f;
            Kiki.defense = 10.0f;

            //monster 4

            Cory.name = "Cory";
            Cory.health = 50.0f;
            Cory.attack = 25.0f;
            Cory.defense = 1.0f;

            ResetCurrentMonsters();
            
        }


        void ResetCurrentMonsters()
        {
            currentMonsterIndex = 0;
            //starting fighters set
            currentMonster1 = GetMonster(currentMonsterIndex);
            currentMonsterIndex++;
            currentMonster2 = GetMonster(currentMonsterIndex);
        }


        void UpdateCurrentScene()
        {
            if (currentScene == 0)
            {
                DisplayStartMenu();
            }
            else if (currentScene == 1)
            {
                Battle();
                UpdateCurrentMonster();
                Console.ReadKey(true);
            }
            else if (currentScene == 2)
            {
                DisplayRestartMenu();
            }
        }


        /// <summary>
        /// Gets an input from the player based on some decision
        /// </summary>
        /// <param name="description">Context for decision</param>
        /// <param name="option1">The first choice</param>
        /// <param name="option2">The second choice</param>
        /// <param name="pauseInvalid">If true, the player must press a key to continue after putting in the incorrect choice</param>
        /// <returns>A number representing which of the two options was chosen. Returns 0 if an invalid input was received.</returns>
        int GetInput(string description, string option1, string option2, bool pauseInvalid = false)
        {
            //Print the context and options
            Console.WriteLine(description);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);

            //Get player input
            string input = Console.ReadLine();
            int choice = 0;

            //If the player typed 1
            if (input == "1")
            {
                choice = 1;
            }
            //if the player typed 2
            else if (input == "2")
            {
                choice = 2;
            }
            //If the player did not type 1 or 2
            else
            {
                //...show them they typed the wrong key
                Console.WriteLine("Invalid Input");

                //If we want to pause when an invalid input is recieved...
                if (pauseInvalid)
                {
                    //...make the player press a key to continue
                    Console.ReadKey(true);
                }
            }

            //Return the player choice
            return choice;

        }
        /// <summary>
        /// Displays the starting menu, giving the player the option to start the simulation or not
        /// </summary>
        void DisplayStartMenu()
        {
            //the opening message with the player choices
            int choice = GetInput("Welcome to the simulation!", "Start Simulation", "Quit Application");
            
            //choice to start the simulation
            if (choice == 1)
            {
                currentScene = 1;
            }
            //choice to not start the simulation and exit
            else if (choice == 2)
            {
                gameOver = true;
            }
        }


        /// <summary>
        /// Displays the restart menu. Gives the player the option to restart or exit the program
        /// </summary>
        void DisplayRestartMenu()
        {
            //Get the player choice
            int choice = GetInput("Simulation over. Would you like to start again?", "Yes", "No");

            //If the player chose to restart...
            if (choice == 1)
            {
                //...set the current scene to be the starting scene
                ResetCurrentMonsters();
                currentScene = 0;
            }
            //if the player wants to exit
            else if (choice == 2)
            {
                //...set the game to end
                gameOver = true;
            }
        }

        /// <summary>
        /// Called every game loop
        /// </summary>
        void Update()
        {
            UpdateCurrentScene();
            Console.Clear();
        }

        void End()
        {
            Console.WriteLine("This is the end. Goodbye.");
        }

        /// <summary>
        /// Shows the monster order
        /// </summary>
        /// <param name="monsterIndex"></param>
        /// <returns></returns>
        Monster GetMonster(int monsterIndex)
        {
            Monster monster;
            monster.name = "None";
            monster.attack = 1;
            monster.defense = 1;
            monster.health = 1;

            if (monsterIndex == 0)
            {
                monster = Cory;
            }
            else if (monsterIndex == 1)
            {
                monster = Kiki;
            }
            else if (monsterIndex == 2)
            {
                monster = Wompus;
            }
            else if (monsterIndex == 3)
            {
                monster = Mike;
            }
            return monster;
        }


        /// <summary>
        /// Simulates one turn in the fight
        /// </summary>
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

        /// <summary>
        /// Changes the fighters when health goes to 0
        /// or ends the simulation
        /// </summary>
        void UpdateCurrentMonster()
        {

            //Monster 1 dying
            if (currentMonster1.health <= 0)
            {
                //Monster swapping
                currentMonsterIndex++;
                currentMonster1 = GetMonster(currentMonsterIndex);
            }
            //Monster 2 dying
            if (currentMonster2.health <= 0)
            {
                //Monster swapping but for monster 2 specifically
                currentMonsterIndex++;
                currentMonster2 = GetMonster(currentMonsterIndex);
            }
            //When there is no more monsters to fight
            if (currentMonster2.name == "None" || currentMonster2.name == "None" && currentMonsterIndex >= 4)
            {
                // Shows restart menu
                
                currentScene = 2;
            }
        }

        /// <summary>
        /// Starts the battle!!!!
        /// </summary>
        /// <param name="Cory"></param>
        /// <param name="Kiki"></param>
        /// <returns></returns>
        string StartBattle(ref Monster Cory, ref Monster Kiki)
        {
            string matchResult = "No Contest";

            while (Cory.health > 0 && Kiki.health > 0)
            {
                //Print monster1 stats
                PrintStats(Cory);
                //Print monster2 stats
                PrintStats(Kiki);

                //Monster 1 attacks monster 2
                float damageTaken = Fight(Cory, ref Kiki);
                Console.WriteLine(Kiki.name + " has taken " + damageTaken);

                //Monster 2 attacks monster 1

                damageTaken = Fight(Kiki, ref Cory);
                Console.WriteLine(Cory.name + " has taken " + damageTaken);

                Console.ReadKey(true);
                Console.Clear();
            }

            if (Cory.health <= 0 && Kiki.health <= 0)
            {
                matchResult = "Draw";
            }
            else if (Cory.health > 0)
            {
                matchResult = Cory.name;
            }
            else if (Kiki.health > 0)
            {
                matchResult = Kiki.name;
            }

            return matchResult;
        }

        float Fight(Monster attacker, ref Monster defender)
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