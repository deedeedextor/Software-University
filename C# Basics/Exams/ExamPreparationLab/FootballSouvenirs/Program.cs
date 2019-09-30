using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSouvenirs
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            string souvenirs = Console.ReadLine();
            int numOfSouvenirs = int.Parse(Console.ReadLine());
            double price = 0;

            if (team != "Argentina" && team != "Brazil" && team != "Croatia" && team != "Denmark")
            {
                Console.WriteLine("Invalid country!");
                return;
            }

            if (souvenirs != "flags" && souvenirs != "caps" && souvenirs != "posters" && souvenirs != "stickers")
            {
                Console.WriteLine("Invalid stock!");
                return;
            }

            if (team == "Argentina")
            {
                if (souvenirs == "flags")
                {
                    price = numOfSouvenirs * 3.25;
                }
                else if (souvenirs == "caps")
                {
                    price = numOfSouvenirs * 7.20;
                }
                else if (souvenirs == "posters")
                {
                    price = numOfSouvenirs * 5.10;
                }
                else if (souvenirs == "stickers")
                {
                    price = numOfSouvenirs * 1.25;
                }
            }

            else if (team == "Brazil")
            {
                if (souvenirs == "flags")
                {
                    price = numOfSouvenirs * 4.20;
                }
                else if (souvenirs == "caps")
                {
                    price = numOfSouvenirs * 8.50;
                }
                else if (souvenirs == "posters")
                {
                    price = numOfSouvenirs * 5.35;
                }
                else if (souvenirs == "stickers")
                {
                    price = numOfSouvenirs * 1.20;
                }
            }

            else if (team == "Croatia")
            {
                if (souvenirs == "flags")
                {
                    price = numOfSouvenirs * 2.75;
                }
                else if (souvenirs == "caps")
                {
                    price = numOfSouvenirs * 6.90;
                }
                else if (souvenirs == "posters")
                {
                    price = numOfSouvenirs * 4.95;
                }
                else if (souvenirs == "stickers")
                {
                    price = numOfSouvenirs * 1.10;
                }
            }

            else if (team == "Denmark")
            {
                if (souvenirs == "flags")
                {
                    price = numOfSouvenirs * 3.10;
                }
                else if (souvenirs == "caps")
                {
                    price = numOfSouvenirs * 6.50;
                }
                else if (souvenirs == "posters")
                {
                    price = numOfSouvenirs * 4.80;
                }
                else if (souvenirs == "stickers")
                {
                    price = numOfSouvenirs * 0.90;
                }
            }
            Console.WriteLine($"Pepi bought {numOfSouvenirs} {souvenirs} of {team} for {price:F2} lv.");
        }
    }
}
