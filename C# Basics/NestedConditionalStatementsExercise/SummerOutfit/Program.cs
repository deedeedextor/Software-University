using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerOutfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int degree = int.Parse(Console.ReadLine());
            string timeOfTheDay = Console.ReadLine();

            string Outfit = "";
            string Shoes = "";


            if (timeOfTheDay == "Morning")
            {
                if (10 <= degree && degree <= 18)
                {
                    Outfit = "Sweatshirt";
                    Shoes = "Sneakers";
                }
                else if (18 < degree && degree <= 24)
                {
                    Outfit = "Shirt";
                    Shoes = "Moccasins";
                }
                else if (degree >= 25)
                {
                    Outfit = "T-Shirt";
                    Shoes = "Sandals";
                }
            }

            else if (timeOfTheDay == "Afternoon")
            {
                if (10 <= degree && degree <= 18)
                {
                    Outfit = "Shirt";
                    Shoes = "Moccasins";
                }
                else if (18 < degree && degree <= 24)
                {
                    Outfit = "T-Shirt";
                    Shoes = "Sandals";
                }
                else if (degree >= 25)
                {
                    Outfit = "Swim Suit";
                    Shoes = "Barefoot";
                }
            }

            else if (timeOfTheDay == "Evening")
            {
                if (10 <= degree && degree <= 18)
                {
                    Outfit = "Shirt";
                    Shoes = "Moccasins";
                }
                else if (18 < degree && degree <= 24)
                {
                    Outfit = "Shirt";
                    Shoes = "Moccasins";
                }
                else if (degree >= 25)
                {
                    Outfit = "Shirt";
                    Shoes = "Moccasins";
                }
            }

            Console.WriteLine($"It's {degree} degrees, get your {Outfit} and {Shoes}.");
        }
    }
}
