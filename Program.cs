using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices.ComTypes;

namespace PokemonGame
{
    public class Program
    {

        Trainer playerName; //think about renaming
        string city;
        bool continueToRun = true;
        string pokemonName { get => playerName.PokeCollection.First().Creature; }

        static void Main(string[] args)
        {
            Program game = new Program();
            game.Game();
        }


        public void Game()
        {

            while (continueToRun)
            {
                Console.WriteLine(@"                                 ,'\");
                Console.WriteLine(@"    _.----.        ____         ,'  _\   ___    ___     ____");
                Console.WriteLine(@"_,-'       `.     |    |  /`.   \,-'    |   \  /   |   |    \  |`.");
                Console.WriteLine(@"\      __    \    '-.  | /   `.  ___    |    \/    |   '-.   \ |  |");
                Console.WriteLine(@" \.    \ \   |  __  |  |/    ,','_  `.  |          | __  |    \|  |");
                Console.WriteLine(@"   \    \/   /,' _`.|      ,' / / / /   |          ,' _`.|     |  |");
                Console.WriteLine(@"    \     ,-'/  /   \    ,'   | \/ / ,`.|         /  /   \  |     |");
                Console.WriteLine(@"     \    \ |   \_/  |   `-.  \    `'  /|  |    ||   \_/  | |\    |");
                Console.WriteLine(@"      \    \ \      /       `-.`.___,-' |  |\  /| \      /  | |   |");
                Console.WriteLine(@"       \    \ `.__,'|  |`-._    `|      |__| \/ |  `.__,'|  | |   |");
                Console.WriteLine(@"        \_.-'       |__|    `-._ |              '-.|     '-.| |   |");
                Console.WriteLine(@"                                `'                            '-._|");
                Console.WriteLine("\n");
                CreatePlayer();

                StartingPoke();

                Console.Write("For your first adventure ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{playerName.Name}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(", lets pick a city to travel to:\n");

                ChooseCity();
            }
        }
        public void CreatePlayer()
        {
            Console.WriteLine("Welcome to Sparkle City! Your hometown in this amazing adventure to become a Pokemon Master Trainer!\n");
            Console.ReadKey();
            Console.WriteLine("As you begin and journey through your quest, there will be many dangerous obstacles!\n");
            Console.ReadKey();
            Console.WriteLine("You only have one life to live, so be weary of dark and mysterious places!\n");
            Console.ReadKey();
            Console.WriteLine("You will earn the title of Pokemon Master Trainer eventually....seriously....we promise.  Each pokemon you battle will earn you points towards this goal....maybe!\n");
            Console.ReadKey();
            Console.WriteLine("You can't be a Pokemon Master Trainer without a name! What is your name?");
            string name = Console.ReadLine();
            playerName = new Trainer(name, 50);
        }
        public void StartingPoke()
        {
            Console.WriteLine("As a new Pokemon Trainer, you get to pick your first Pokemon to join you on your quest to become a Master Trainer: \n" +
                       "1. Charmander\n" +
                       "2. Squirtle\n" +
                       "3. Bulbasaur\n"
                       );

            string pokeSelect = Console.ReadLine();

            if (!"1,2,3".Contains(pokeSelect))
            {
                Console.WriteLine("That's not a pokemon!");
                Console.ReadKey();
                StartingPoke();
                return;
            }

            Pokemon startingPoke = SelectPokemon(pokeSelect);

            playerName.PokeCollection.Add(startingPoke);

            Console.Write("Congratulations on picking your first Pokemon! ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($" {startingPoke.Creature} ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("is an excellent choice!\n");
            Console.ReadKey();
        }
        public Pokemon SelectPokemon(string pokeSelect)
        {
            if (pokeSelect == "1")
            {
                return new Charmander();
            }
            else if (pokeSelect == "2")
            {
                return new Squirtle();
            }
            else
            {
                return new Bulbasaur();
            }

        }
        public void ChooseCity()
        {
            Console.WriteLine("Choose a city: \n" +
                     "1. Veridian City\n" +
                     "2. Beigeville\n" +
                     "3. Vermillian City\n" +
                     "4. Brownstown\n" +
                     "5. I don't want to go anywhere\n"
                     );
            string selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    city = "Veridian City";
                    Console.ReadKey();//pauses the screen line readline, but without taking in data
                    GoToCity();
                    break;
                case "2":
                    continueToRun = false;
                    Console.WriteLine("Welcome to Beigeville!\n");
                    Console.ReadKey();
                    Console.WriteLine("You have fallen off a cliff.....\n\nYou didn't survive the fall... Game Over!\n");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                case "3":
                    city = "Vermillian City";
                    Console.ReadKey();
                    GoToCity();
                    break;
                case "4":
                    Console.WriteLine("Welcome to Brownstown!\n");
                    Console.ReadKey();
                    Console.WriteLine("You were bitten by an Arbok, a powerful and venomous snake Pokemon.\n\n You died! Game Over!\n");
                    continueToRun = false;
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                case "5":
                    //exit
                    continueToRun = false;//set it to false to stop the while loop
                    Console.WriteLine("Why did you even play?!?! Goodbye.");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("That's not on our map!\n");
                    Console.ReadKey();//pauses the screen line readline, but wiout taking in data
                    ChooseCity();
                    break;
            }
        }
        public void GoToCity()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Write(" Player: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{ playerName.Name}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($" is travelling to {city}\n");

                Thread.Sleep(500);

                Console.Write(" Player: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{ playerName.Name}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($" is still travelling to {city}\n");

                Thread.Sleep(500);

                Console.ReadKey();

                Console.Write("Professor: \"Welcome ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{playerName.Name} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"to {city}, a magical town in need of a new Pokemon Master! ");


                Console.Write("Your ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{pokemonName} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("will do well here.\"\n");

                Console.ReadKey();

                Console.WriteLine($"Professor: \"Since you are new to {city}, I recommend you explore the city. \nYou should stop by the local gym or the hospital.\"\n\n");
                Console.ReadKey();
                CityOptions();
            }
        }
        public void CityOptions()
        {
            Console.WriteLine("Where would you like to go: \n" +
                 $"1. Visit the {city} Pokemon Gym\n" +
                 $"2. Visit the {city} Hospital\n" +
                 $"3. Visit the {city} Dungeons\n" +
                 $"4. Visit the {city} Public Restrooms\n" +
                 $"5. Visit the forest outside of {city}\n"
                 );
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    PokemonGym();
                    Console.ReadKey();//pauses the screen line readline, but without taking in data
                    break;
                case "2":
                    PokemonHospital();
                    Console.ReadKey();
                    //Thread.Sleep(2000);
                    break;
                case "3":
                    Console.WriteLine($"Welcome to the {city} Dungeons!\n");
                    Console.ReadKey();
                    Console.WriteLine("You were attacked by an Onyx, a powerful rock-type Pokemon.\n\n You died! Game Over!\n");
                    continueToRun = false;
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                case "4":
                    Console.WriteLine($"Welcome to the {city} Public Restrooms!\n");
                    Console.ReadKey();
                    Console.WriteLine("You were lured in by a cute Starmie, a water-type Pokemon.\n Starmie didn't like you in her bathroom, she used an ice-beam on you!\n\n You died! Game Over!\n");
                    continueToRun = false;
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                case "5":
                    Console.WriteLine("You head out to the forest\n");
                    Console.ReadKey();//pauses the screen line readline, but without taking in data
                    GoToForest();
                    break;
                default:
                    Console.WriteLine("Huh? That's not the path to becoming a Master Trainer!\n");
                    Console.ReadKey();//pauses the screen line readline, but wiout taking in data
                    CityOptions();
                    break;
            }
        }

        public void PokemonGym()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Write("Player: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{playerName.Name} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"has entered the {city} Pokemon Gym.\n");

                Console.ReadKey();

                Console.WriteLine($"Uh oh, the {city} Gym Leader has challenged you to a Pokemon battle.\n");

                Console.ReadKey();

                Console.Write("Player: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{playerName.Name}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(", what are you going to do????\n" +
                        $"1. Battle the {city} Gym Leader and their evil Pokemon!\n" +
                        $"2. Cry and curl up in a ball on the floor!\n" +
                        $"3. Run to the {city} Hospital!\n" +
                        $"4. Run to the forest outside {city}! \n"
                        );

                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        PokeBattle(GenerateRandomPokemon());
                        Console.ReadKey();//pauses the screen line readline, but without taking in data
                        break;
                    case "2":
                        Console.WriteLine($"You curl up in the fetal position and start to cry.\n");
                        Console.ReadKey();
                        Console.Write("Your ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{pokemonName} ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("is humiliated and runs away leaving you defenseless.\n");
                        Console.ReadKey();
                        Console.WriteLine("You die of embarrasment! Game Over!");
                        continueToRun = false;
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    case "3":
                        PokemonHospital();
                        Console.ReadKey();
                        break;
                    case "4":
                        GoToForest();
                        Console.ReadKey();//pauses the screen line readline, but without taking in data
                        break;
                    default:
                        Console.WriteLine($"You curl up in the fetal position and start to cry.\n");
                        Console.ReadKey();
                        Console.Write("Your ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{pokemonName} ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("is humiliated and runs away leaving you defenseless.\n");
                        Console.ReadKey();
                        Console.WriteLine("You die of embarrasment! Game Over!");
                        continueToRun = false;
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                }
            }
        }
        public void PokemonHospital()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine($"Welcome to the {city} Hospital.  Nurse Joy is walking towards you...\n");
                Console.ReadKey();

                Console.Write("Nurse Joy: \"Hey, ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{playerName.Name}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" looks like your ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{ pokemonName} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("isn't hurt right now, be sure to come back when you need us!\"\n");

                Console.ReadKey();

                Console.Write("Where to next ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{playerName.Name}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("? \n" +
                            $"1. Visit the {city} Pokemon Gym\n" +
                            $"2. Visit the {city} Dungeons\n" +
                            $"3. Visit the {city} Public Restrooms\n" +
                            $"4. Visit the forest outside of {city}\n"
                            );

                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        PokemonGym();
                        Console.ReadKey();//pauses the screen line readline, but without taking in data
                        break;
                    case "2":
                        Console.WriteLine($"Welcome to the {city} Dungeons!\n");
                        Console.ReadKey();
                        Console.WriteLine("You were attacked by an Onyx, a powerful rock-type Pokemon.\n\n You died! Game Over!");
                        continueToRun = false;
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    case "3":
                        Console.WriteLine($"Welcome to the {city} Public Restrooms!\n");
                        Console.ReadKey();
                        Console.WriteLine("You were lured in by a cute Starmie, a water-type Pokemon.\n Starmie didn't like you in her bathroom, she used an ice-beam on you!\n\n You died! Game Over!");
                        continueToRun = false;
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    case "4":
                        GoToForest();
                        Console.ReadKey();//pauses the screen line readline, but without taking in data
                        break;
                    default:
                        Console.WriteLine("Huh? That's not the path to becoming a Master Trainer!\n");
                        Console.ReadKey();//pauses the screen line readline, but wiout taking in data
                        CityOptions();
                        break;
                }
            }
        }
        public void PokeBattle(Pokemon encounter)
        {

            while (continueToRun)
            {
                Console.WriteLine("\n\n\n *Music starts to magically play* Woah thats weird!\n");

                Console.ReadKey();

                Console.Write($"EEK! Your opponent selects a ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{encounter.Creature} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("to battle you!\n");
                Console.ReadKey();

                Console.Write("Player ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{playerName.Name}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(": \"I choose you, ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($" {pokemonName}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("!\"\n");


                Console.ReadKey();
                //changes the color of specific words such as pokeName and Creature
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($" {pokemonName}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" and ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{encounter.Creature}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" start wrestling and pulling hair, it's not a graceful fight.\n");

                Console.ReadKey();


                Console.Write("Then suddenly they break apart...");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($" {pokemonName}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" unleashes the ROUNDHOUSE-KICK and annihilates ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{encounter.Creature}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(".\n");

                Console.ReadKey();

                Console.Write("Congratulations ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{playerName.Name}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" , you won this battle.  You gained ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write($"{encounter.Score} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"points and the {city} Badge.\n");

                Console.ReadKey();

                playerName.PokeScore += encounter.Score;

                Console.Write("You now have a total of");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write($" {playerName.PokeScore} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("points!\n");
                Console.ReadKey();

                Console.WriteLine("Now where do you want to go???\n" +
                            $"1. Visit the {city} Hospital\n" +
                            $"2. Visit the {city} Dungeons\n" +
                            $"3. Visit the {city} Public Restrooms\n" +
                            $"4. Visit the forest outside of {city}\n"
                            );
                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        PokemonHospital();
                        Console.ReadKey();
                        //Thread.Sleep(2000);
                        break;
                    case "2":
                        Console.WriteLine($"Welcome to the {city} Dungeons!\n");
                        Console.ReadKey();
                        Console.WriteLine("You were attacked by an Onyx, a powerful rock-type Pokemon.\n\n You died! Game Over!");
                        continueToRun = false;
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    case "3":
                        Console.WriteLine($"Welcome to the {city} Public Restrooms!\n");
                        Console.ReadKey();
                        Console.WriteLine("You were lured in by a cute Starmie, a water-type Pokemon.\n Starmie didn't like you in her bathroom, she used an ice-beam on you!\n\n You died! Game Over!");
                        continueToRun = false;
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    case "4":
                        GoToForest();
                        Console.ReadKey();//pauses the screen line readline, but without taking in data
                        break;
                    default:
                        Console.WriteLine("Huh? That's not the path to becoming a Master Trainer!\n");
                        Console.ReadKey();//pauses the screen line readline, but wiout taking in data
                        CityOptions();
                        break;
                }
            }
        }

        public void GoToForest()
        {
            Console.WriteLine($"A sign in front of you reads: {city} Forest. Proceed with caution!\n");
            Console.ReadKey();
            Action();
        }

        public void Action()
        {
            Console.WriteLine("What would you like to do?\n" +
                "1. Continue Straight\n" +
                "2. Turn Left\n" +
                "3. Turn Right\n" +
                "4. Go back to town\n");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("You continue walking straight.\n");
                    Console.ReadKey();
                    RandomResponse();
                    break;
                case "2":
                    Console.WriteLine("You turn left.\n");
                    Console.ReadKey();
                    RandomResponse();
                    break;
                case "3":
                    Console.WriteLine("You turn right.\n");
                    Console.ReadKey();
                    RandomResponse();
                    break;
                case "4":
                    Console.WriteLine("You turn around and head back into town.\n");
                    Console.ReadKey();
                    GoToCity();
                    break;
                default:
                    Console.WriteLine("That is not an option\n");
                    Console.ReadKey();
                    Action();
                    break;
            }
        }

        public void WildPokemonAppears(Pokemon encounter)
        {

            Console.Write("A wild ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{encounter.Creature} ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("appears! Do you want to fight it?\n" +
               "1. Fight\n" +
               "2. Flee\n");

            string select = Console.ReadLine();

            switch (select)
            {
                case "1":
                    Console.Write("Prepare to battle the wild ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{encounter.Creature}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("!\n");

                    Console.ReadKey();
                    PokeFight(encounter);
                    break;
                case "2":
                    Console.Write("You flee from the wild ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{encounter.Creature}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" unscathed.\n");

                    Console.ReadKey();
                    Action();
                    break;
                default:
                    Console.Write("You can't do that, ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{playerName.Name}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(".\n");

                    Console.ReadKey();
                    WildPokemonAppears(encounter);
                    break;
            }

        }
        public Pokemon GenerateRandomPokemon()
        {
            var maxValue = PokeRepo.PokeDex.Count;

            Random Rand = new Random();
            int option = Rand.Next(0, maxValue - 1);

            return PokeRepo.PokeDex[option];
        }
        public void PokeFight(Pokemon pokemon)
        {
            Console.WriteLine("\n\n\n *Music starts to magically play* Woah thats weird!\n");
            Console.ReadKey();

            Console.Write("You are engaging battle with a wild ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{pokemon.Creature}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(".");

            Console.ReadKey();

            Console.Write("Player ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{playerName.Name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(": \"I choose you, ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{ pokemonName}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("!\"\n");

            Console.ReadKey();

            Console.Write("You and your ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{ pokemonName}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" have beaten the wild ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{pokemon.Creature}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("!");

            Console.ReadKey();

            Console.Write("This ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{pokemon.Creature}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" was worth ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"{ pokemon.Score}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" points!\n");

            Console.ReadKey();

            playerName.PokeScore += pokemon.Score;

            Console.Write("You now have a total of ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"{ playerName.PokeScore} ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("points!\n");

            Console.ReadKey();

            Action();
        }
        public void RandomResponse()
        {
            Random Rand = new Random();
            int option = Rand.Next(1, 5);

            switch (option)
            {
                case 1:
                    Console.WriteLine("You run into a tree. OUCH!\n");
                    Console.ReadKey();
                    Action();
                    break;
                case 2:
                    Console.WriteLine("You fell into a prickly bush.\n");
                    Console.ReadKey();
                    Action();
                    break;
                case 3:
                    WildPokemonAppears(GenerateRandomPokemon());
                    break;
                case 4:
                    Console.WriteLine("You stubbed your toe on a rock.\n");
                    Console.ReadKey();
                    Action();
                    break;
                default:
                    Console.WriteLine("Your path is clear\n");
                    Console.ReadKey();
                    Action();
                    break;
            }

        }

    }
}
