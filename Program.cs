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
        string dokemonName { get => playerName.PokeCollection.First().Creature; }

        static void Main(string[] args)
        {
            Program game = new Program();
            game.Game();
        }

        public void Header()
        {
            Console.WriteLine(@"                                     ,'\");
            Console.WriteLine(@"    _.----.           ____         ,'  _\   ___    ___     ____");
            Console.WriteLine(@"_,-'       `.        |    |  /`.   \,-'    |   \  /   |   |    \  |`.");
            Console.WriteLine(@"\      __    \       '-.  | /   `.  ___    |    \/    |   '-.   \ |  |");
            Console.WriteLine(@" \.    \ \    \     _  |  |/    ,','_  `.  |          | __  |    \|  |");
            Console.WriteLine(@"   \    \ \    \ ,' _`.|      ,' / / / /   |          ,' _`.|     |  |");
            Console.WriteLine(@"    \    \ \    \  /   \    ,'   | \/ / ,`.|         /  /   \  |     |");
            Console.WriteLine(@"     \    \ \   /  \_/  |   `-.  \    `'  /|  |    ||   \_/  | |\    |");
            Console.WriteLine(@"      \    \/  /\      /       `-.`.___,-' |  |\  /| \      /  | |   |");
            Console.WriteLine(@"       \      /  `.__,'|  |`-._    `|      |__| \/ |  `.__,'|  | |   |");
            Console.WriteLine(@"        \_.-'          |__|    `-._ |              '-.|     '-.| |   |");
            Console.WriteLine(@"                                     `'                          '-._|");
            Console.WriteLine("\n");
        }

        public void Game()
        {

            while (continueToRun)
            {
                Header();
                CreatePlayer();

                StartingPoke(playerName);

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
            Console.WriteLine("Welcome to Sparkle City! Your hometown in this amazing adventure to become a Dokemon Master Trainer!\n");
            Thread.Sleep(2500);
            Console.WriteLine("As you begin and journey through your quest, there will be many dangerous obstacles!\n");
            Thread.Sleep(2500);
            Console.WriteLine("You only have one life to live, so be weary of dark and mysterious places!\n");
            Thread.Sleep(2500);
            Console.WriteLine("You will earn the title of Dokemon Master Trainer eventually....seriously....we promise.  Each dokemon you battle will earn you points towards this goal....maybe!\n");
            Thread.Sleep(2500);
            Console.WriteLine("You can't be a Dokemon Master Trainer without a name! What is your name?");
            Console.WriteLine();
            string name = Console.ReadLine();
            playerName = new Trainer(name, 50);
            Console.Clear();
            StartingPoke(playerName);
        }
        public void StartingPoke(Trainer playerName)
        {
            Header();
            Console.WriteLine($"{playerName.Name}, as a new Dokemon Trainer, you get to pick your first Dokemon to join you on your quest to become a Master Trainer: \n" +
                       "1. Tarmander\n" +
                       "2. Tuirtle\n" +
                       "3. Tulbasaur\n"
                       );

            string pokeSelect = Console.ReadLine();

            if (!"1,2,3".Contains(pokeSelect))
            {
                Console.WriteLine("That's not a dokemon!");
                Console.ReadKey();
                StartingPoke(playerName);
                return;
            }

            Pokemon startingPoke = SelectDokemon(pokeSelect);

            playerName.PokeCollection.Add(startingPoke);

            Console.Write($"Congratulations on picking your first Dokemon! {startingPoke.Creature} is an excellent choice!\n");
            Console.WriteLine();
            Console.WriteLine("Press [Enter] to continue...");
            Console.ReadKey();
            Console.Clear();
            ChooseCity();
        }
        public Pokemon SelectDokemon(string pokeSelect)
        {
            if (pokeSelect == "1")
            {
                return new Tarmander();
            }
            else if (pokeSelect == "2")
            {
                return new Tuirtle();
            }
            else
            {
                return new Tulbasaur();
            }

        }
        public void ChooseCity()
        {
            Header();
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
                    Console.Clear();
                    GoToCity();
                    break;
                case "2":
                    continueToRun = false;
                    Console.WriteLine("Welcome to Beigeville!...\n");
                    Thread.Sleep(2500);
                    Console.WriteLine("You have fallen off a cliff.....\n\nYou didn't survive the fall... Game Over!\n");
                    Console.WriteLine("Press [Enter] to continue...");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                case "3":
                    city = "Vermillian City";
                    Console.Clear();
                    GoToCity();
                    break;
                case "4":
                    Console.WriteLine("Welcome to Brownstown!.....\n");
                    Thread.Sleep(2500);
                    Console.WriteLine("You were bitten by an Arbok, a powerful and venomous snake Pokemon.\n\nYou died! Game Over!\n");
                    continueToRun = false;
                    Console.WriteLine("Press [Enter] to continue...");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                case "5":
                    //exit
                    continueToRun = false;//set it to false to stop the while loop
                    Console.WriteLine("Why did you even play?!?! Goodbye.");
                    Console.WriteLine("Press [Enter] to continue...");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("That's not on our map!\n");
                    Thread.Sleep(2500);
                    Console.Clear();
                    ChooseCity();
                    break;
            }
        }
        public void GoToCity()
        {
            Header();
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Write($"{ playerName.Name} is travelling to {city}\n");
                Thread.Sleep(1500);
                Console.Write($"....{ playerName.Name} is still travelling to {city}\n");
                Thread.Sleep(1500);
                Console.WriteLine("You finally got there...jeez.\n\nPress [Enter] to continue....\n\n");
                Console.ReadKey();
                Console.Write($"Professor: \"Welcome {playerName.Name} to {city}, a magical town in need of a new Dokemon Master! ");
                Thread.Sleep(1000);
                Console.Write($"Your {dokemonName} will do well here.\"\n");
                Thread.Sleep(1000);
                Console.WriteLine($"Professor: \"Since you are new to {city}, I recommend you explore the city. \nYou should stop by the local gym or the hospital.\"\n\n");
                Console.WriteLine("Press [Enter] to continue...");
                Console.ReadKey();
                Console.Clear();
                CityOptions();
            }
        }
        public void CityOptions()
        {
            Header();
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
                    Console.Clear();
                    PokemonGym();
                    break;
                case "2":
                    Console.Clear();
                    PokemonHospital();
                    break;
                case "3":
                    Console.WriteLine($"Welcome to the {city} Dungeons!\n");
                    Thread.Sleep(2500);
                    Console.WriteLine("You were attacked by an Onyx, a powerful rock-type Pokemon.\n\nYou died! Game Over!\n");
                    continueToRun = false;
                    Console.WriteLine("Press [Enter] to continue...");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                case "4":
                    Console.WriteLine($"Welcome to the {city} Public Restrooms!\n");
                    Thread.Sleep(2500);
                    Console.WriteLine("You were lured in by a cute Starmie, a water-type Pokemon.\n Starmie didn't like you in her bathroom, she used an ice-beam on you!\n\nYou died! Game Over!\n");
                    continueToRun = false;
                    Console.WriteLine("Press [Enter] to continue...");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                case "5":
                    Console.WriteLine("You head out to the forest\n");
                    Thread.Sleep(2500);
                    Console.Clear();
                    GoToForest();
                    break;
                default:
                    Console.WriteLine("Huh? That's not the path to becoming a Master Trainer!\n");
                    Thread.Sleep(2500);
                    Console.Clear();
                    CityOptions();
                    break;
            }
        }

        public void PokemonGym()
        {
            Header();
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Write($"{playerName.Name} has entered the {city} Pokemon Gym.\n");
                Thread.Sleep(2500);
                Console.WriteLine($"Uh oh, the {city} Gym Leader has challenged you to a Pokemon battle.\n");
                Thread.Sleep(2500);
                Console.Write($"{playerName.Name}, what are you going to do????\n" +
                        $"1. Battle the {city} Gym Leader and their evil Pokemon!\n" +
                        $"2. Cry and curl up in a ball on the floor!\n" +
                        $"3. Run Outside\n"
                        );

                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        Console.Clear();
                        PokeFight(GenerateRandomPokemon());
                        CityOptions();
                        break;
                    case "3":
                        Console.Clear();
                        CityOptions();
                        break;
                    case "2":
                    default:
                        Console.WriteLine($"You curl up in the fetal position and start to cry.\n");
                        Thread.Sleep(2500);
                        Console.Write($"Your {dokemonName} is humiliated and runs away leaving you defenseless.\n");
                        Thread.Sleep(2500);
                        Console.WriteLine("You die of embarrasment! Game Over!");
                        continueToRun = false;
                        Console.WriteLine("Press [Enter] to continue...");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                }
            }
        }
        public void PokemonHospital()
        {
            Header();
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine($"Welcome to the {city} Hospital.  Nurse Joy is walking towards you...\n");
                Thread.Sleep(2500);
                Console.Write($"Nurse Joy: \"Hey, {playerName.Name} looks like your {dokemonName} isn't hurt right now, be sure to come back when you need us!\"\n");
                Thread.Sleep(2500);
                CityOptions();
            }
        }
        public void GoToForest()
        {
            Header();
            Console.WriteLine($"A sign in front of you reads: {city} Forest. Proceed with caution!\n\n");
            Console.WriteLine("Press [Enter] to continue...");
            Console.ReadKey();
            Console.Clear();
            Action();
        }

        public void Action()
        {
            Header();
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
                    Thread.Sleep(2500);
                    Console.Clear();
                    RandomResponse();
                    break;
                case "2":
                    Console.WriteLine("You turn left.\n");
                    Thread.Sleep(2500);
                    Console.Clear();
                    RandomResponse();
                    break;
                case "3":
                    Console.WriteLine("You turn right.\n");
                    Thread.Sleep(2500);
                    Console.Clear();
                    RandomResponse();
                    break;
                case "4":
                    Console.WriteLine("You turn around and head back into town.\n");
                    Thread.Sleep(2500);
                    Console.WriteLine("Press [Enter] to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    GoToCity();
                    break;
                default:
                    Console.WriteLine("That is not an option\n");
                    Thread.Sleep(2500);
                    Action();
                    break;
            }
        }
        public void PokeFight(Pokemon pokemon)
        {
            Console.WriteLine("\n\n\n*Music starts to magically play* Woah thats weird!\n");
            Thread.Sleep(2500);
            Console.Write($"A {pokemon.Creature}, sweet!  We love a challenge!\n");
            Thread.Sleep(2500);
            Console.Write($"{playerName.Name}: \"I choose you, {dokemonName}!\"\n");
            Thread.Sleep(2500);
            Console.Write($"{dokemonName} and {pokemon.Creature} start wrestling and pulling hair, it's not a graceful fight.\n");
            Thread.Sleep(2500);
            Console.Write("Then suddenly they break apart...\n");
            Thread.Sleep(2500);
            Console.Write($"{dokemonName} unleashes the ROUNDHOUSE-KICK and annihilates {pokemon.Creature}.\n");
            Thread.Sleep(1500);
            Console.Write($"Congratulations {playerName.Name}, you won this battle.  You gained {pokemon.Score} points.\n");

            playerName.PokeScore += pokemon.Score;

            Console.Write($"You now have a total of {playerName.PokeScore} points!\n\nHORRAY!\n\n");
            Console.WriteLine("Press [Enter] to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        public void RandomResponse()
        {
            Header();
            Random Rand = new Random();
            int option = Rand.Next(1, 5);

            switch (option)
            {
                case 1:
                    Console.WriteLine("You run into a tree. OUCH!\n");
                    Thread.Sleep(2500);
                    Console.Clear();
                    Action();
                    break;
                case 2:
                    Console.WriteLine("You fell into a prickly bush.\n");
                    Thread.Sleep(2500);
                    Console.Clear();
                    Action();
                    break;
                case 3:
                    Console.Clear();
                    WildPokemonAppears(GenerateRandomPokemon());
                    break;
                case 4:
                    Console.WriteLine("You stubbed your toe on a rock.\n");
                    Thread.Sleep(2500);
                    Console.Clear();
                    Action();
                    break;
                default:
                    Console.WriteLine("Your path is clear\n");
                    Thread.Sleep(2500);
                    Console.Clear();
                    Action();
                    break;
            }

        }
        public void WildPokemonAppears(Pokemon encounter)
        {
            Header();
            Console.Write("");
            Console.Write($"A wild {encounter.Creature} appears! Do you want to fight it?\n");
            Console.Write("" +
               "1. Fight\n" +
               "2. Flee\n");

            string select = Console.ReadLine();

            switch (select)
            {
                case "1":
                default:
                    Console.Write($"Prepare to battle the wild {encounter.Creature}!\n\n");
                    Console.WriteLine("Press [Enter] to continue...");
                    Console.ReadKey();
                    PokeFight(encounter);
                    Action();
                    break;
                case "2":
                    Console.Write($"You flee from the wild {encounter.Creature} unscathed.\n");
                    Console.WriteLine("Press [Enter] to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    Action();
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

    }
}
