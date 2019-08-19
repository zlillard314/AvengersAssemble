using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace DungeonProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var mediaPlayer = new System.Media.SoundPlayer();
            mediaPlayer.SoundLocation = @"C:\Users\Student\Desktop\Silent Hollow\Silent_Hollow-LiesInFiction.wav";
            mediaPlayer.PlayLooping();

            #region Special Attacks

            //SpecialAttacks
            SpecialAttack sheild = new SpecialAttack("Sheild Throw", 4, 7, false, 10);
            SpecialAttack mjolnir = new SpecialAttack("Mjolnir Blast", 5, 8, false, 11);
            SpecialAttack hulkSmash = new SpecialAttack("Hulk Smash", 6, 9, true, 12);
            SpecialAttack arrow = new SpecialAttack("Explosive Arrow", 3, 6, true, 10);
            SpecialAttack widowKick = new SpecialAttack("Widow Kick", 3, 6, false, 10);
            SpecialAttack chaosBlast = new SpecialAttack("Chaos Blast", 6, 10, true, 12);
            SpecialAttack webKick = new SpecialAttack("Web Kick", 3, 6, false, 10);
            SpecialAttack repulsorBeam = new SpecialAttack("Repulsor Beam Blast", 4, 8, true, 11);
            #endregion

            #region Avengers

            Player captainAmerica = new Player("Captain America", Avenger.Captain_America, 20, 25, 35, 40,
                sheild);
            Player thor = new Player("Thor", Avenger.Thor, 20, 30, 30, 35, mjolnir);
            Player hulk = new Player("Hulk", Avenger.Hulk, 20, 30, 25, 30, hulkSmash);
            Player hawkEye = new Player("HawkEye", Avenger.Hawkeye, 20, 20, 45, 15, arrow);
            Player blackWidow = new Player("Black Widow", Avenger.Black_Widow, 20, 20, 45, 15, widowKick);
            Player scarletWitch = new Player("Scarlet Witch", Avenger.Scarlet_Witch, 20, 20, 35, 25, chaosBlast);
            Player spiderMan = new Player("Spider-Man", Avenger.Spider_Man, 20, 20, 45, 15, webKick);
            Player ironMan = new Player("Iron Man", Avenger.Iron_Man, 20, 20, 35, 40, repulsorBeam);
            #endregion

            Player avenger = new Player();

            bool select = true;
            do
            {

            Console.Title = ("***Avengers Assemble***");

            Console.WriteLine(@"
        ──────────────▐█████───────
        ──────▄▄████████████▄──────
        ────▄██▀▀────▐███▐████▄────
        ──▄██▀───────███▌▐██─▀██▄──
        ─▐██────────▐███─▐██───██▌─
        ─██▌────────███▌─▐██───▐██─
        ▐██────────▐███──▐██────██▌
        ██▌────────███▌──▐██────▐██
        ██▌───────▐███───▐██────▐██
        ██▌───────███▌──▄─▀█────▐██
        ██▌──────▐████████▄─────▐██
        ██▌──────█████████▀─────▐██
        ▐██─────▐██▌────▀─▄█────██▌
        ─██▌────███─────▄███───▐██─
        ─▐██▄──▐██▌───────────▄██▌─
        ──▀███─███─────────▄▄███▀──
        ──────▐██▌─▀█████████▀▀────
        ──────███──────────────────"
                );



               select = true;

                Console.WriteLine("\nChoose Your Avenger(by number) and hit enter: \n1)Captain America" +
                        "\n2)Thor\n3)Hulk\n4)Hawkeye\n5)Black Widow\n6)Scarlet Witch\n" +
                        "7)Spider-Man\n8)Iron Man");


                string userPlayer = Console.ReadLine().ToLower().Substring(0, 1);
                Console.Clear();


                switch (userPlayer)
                {
                    case "1":
                        Console.WriteLine($"Alright Cap, let's take these evil doers" +
                            " down!!!");
                        avenger = captainAmerica;
                        break;
                    case "2":
                        Console.WriteLine($"Thor, the god of Thunder!!!");
                        avenger = thor;
                        break;
                    case "3":
                        Console.WriteLine($"Looks like it's time for a Hulk Smash!!!");
                        avenger = hulk;
                        break;
                    case "4":
                        Console.WriteLine($"It's the ultimate archer, Hawkeye!!!");
                        avenger = hawkEye;
                        break;
                    case "5":
                        Console.WriteLine($"Black Widow the ultimate weapon!!!");
                        avenger = blackWidow;
                        break;
                    case "6":
                        Console.WriteLine($"No one is a match for the mystical Scarlet Witch!!!");
                        avenger = scarletWitch;
                        break;
                    case "7":
                        Console.WriteLine($"The original web slinger himself, Spider-Man!!!");
                        avenger = spiderMan;
                        break;
                    case "8":
                        Console.WriteLine($"You are Iron Man!!!");
                        avenger = ironMan;
                        break;
                    default:
                        Console.WriteLine("Didn't quite get that. Make sure you select the number " +
                            "of your Avenger.");
                        select = false;
                        break;
                }
            } while (!select);


            //Main Loop
            bool exitMain = false;
            do
            {

                //Room selection
                Console.WriteLine(GetRoom());

                //Monster selection
                BadGuy badGuy = GetBadGuy();
                Console.WriteLine(badGuy.Name + " must be stopped!");

                bool reload = false;
                do
                {
                    //Menu
                    Console.Write("\nSelect an action:\n" +
                        "A) Attack\n" +
                        "R) Retreat\n" +
                        "P) Player Info\n" +
                        "M) Bad Guy Info\n" +
                        "X) Exit Game: ");
                    string userChoice = Console.ReadLine().ToLower().Substring(0, 1);
                    Console.Clear();

                    switch (userChoice)
                    {
                        case "a":
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(avenger.EquippedSpecialAttack.Name);
                            Console.ResetColor();
                            Combat.DoBattle(avenger, badGuy);
                            if (badGuy.Life <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("You defeated " +
                                    badGuy.Name + "!!!");
                                Console.ResetColor();
                                reload = true;
                            }
                            
                            break;
                        case "r":
                            Console.WriteLine("RETREAT!!!\n");
                            reload = true;
                            break;
                        case "p":
                            Console.WriteLine("Player Info:\n");
                            Console.WriteLine(avenger);                            
                            break;
                        case "m":
                            Console.WriteLine("Bad Guy Info:\n");
                            Console.WriteLine(badGuy);                           
                            break;
                        case "x":
                        case "e":
                            Console.WriteLine("Qutting? What is the world gonna save itself?...");
                            exitMain = true;
                            break;
                        default:
                            Console.WriteLine("Input not understood, please try again.");
                            break;
                    }//end switch

                    if (avenger.Life <= 0)
                    {
                        //send the player a going away present
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Clear(); //making the whole background red
                        Console.WriteLine("The world has lost a true hero!");
                        //be able to exit the game
                        exitMain = true;
                    }

                    } while (!reload && !exitMain);//end Menu Loop

            } while (!exitMain);//Main Loop

        }//end Main()

        private static string GetRoom()
        {
            string[] rooms =
            {
                "The City of New York has been attacked. Buildings crumble to the street as citizens run screaming for help.",
                "Sokovia is under attack. The city will soon be destroyed.",
                "Tonsberg, Norway needs your help. Save the town before it's too late."
            };//rooms[]

            Random randy = new Random();
            byte index = (byte)randy.Next(rooms.Length);
            string room = rooms[index];
            return room;
        }//end GetRoom()

        //GetBadGuy()
        public static BadGuy GetBadGuy()
        {
            BadGuy b1 = new BadGuy("Loki", 20, 20, 25, 20, 2, 8, 
                "Asgardian God of Mischief");
            BadGuy b2 = new BadGuy("Ultron", 20, 20, 40, 15, 3, 9, 
                "Artificial Intelligence set to erase humanity");
            BadGuy b3 = new BadGuy("Chitauri", 5, 5, 20, 5, 1, 2,
                "A race of shapeshifters who want to conquer Earth");
            Random randy = new Random();
            List<BadGuy> BadGuys = new List<BadGuy>()
            { b1, b2, b3, b3, b3, b3 };

            return BadGuys[randy.Next(0, BadGuys.Count)];
        }//End GetBadGuy()

    }//end program
}//endDungeon
