using System;

namespace _3.GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentBalance = double.Parse(Console.ReadLine());
            string game = Console.ReadLine();
            double priceGame = 0;
            double gamesSum = 0;

            while (game != "Game Time")
            {
                if (game == "Game Time")
                {
                    break;
                }

                switch (game)
                {
                    case "OutFall 4": priceGame = 39.99; break;
                    case "CS: OG": priceGame = 15.99; break;
                    case "Zplinter Zell": priceGame = 19.99; break;
                    case "Honored 2": priceGame = 59.99; break;
                    case "RoverWatch": priceGame = 29.99; break;
                    case "RoverWatch Origins Edition": priceGame = 39.99; break;
                    default:
                        Console.WriteLine("Not Found");
                        break;
                }
                
                if (priceGame > currentBalance)
                {
                    Console.WriteLine("Too Expensive");
                }

                else if (currentBalance >= priceGame && priceGame > 0)
                {
                    Console.WriteLine($"Bought {game}");
                    gamesSum += priceGame;
                    currentBalance -= priceGame;
                }

                if (currentBalance == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }

                game = Console.ReadLine();
            }

            Console.WriteLine($"Total spent: ${gamesSum:f2}. Remaining: ${currentBalance:f2}");
        }
    }
}
