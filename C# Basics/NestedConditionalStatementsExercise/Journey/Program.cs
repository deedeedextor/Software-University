using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string region = string.Empty;
            string place = string.Empty;

            if (budget <= 100)
            {
                region = "Bulgaria";

                switch (season)
                {
                    case "summer":
                        budget *= 0.30;
                        place = "Camp";
                        break;
                    case "winter":
                        budget *= 0.70;
                        place = "Hotel";
                        break;
                }
            }

            else if (budget <= 1000)
            {
                region = "Balkans";

                switch (season)
                {
                    case "summer":
                        budget *= 0.40;
                        place = "Camp";
                        break;
                    case "winter":
                        budget *= 0.80;
                        place = "Hotel";
                        break;
                }
            }

            else if (budget > 1000)
            {
                region = "Europe";

                switch (season)
                {
                    case "summer":
                        budget *= 0.90;
                        place = "Hotel";
                        break;
                    case "winter":
                        budget *= 0.90;
                        place = "Hotel";
                        break;
                }
            }

            Console.WriteLine("Somewhere in " + region);
            Console.WriteLine($"{place} - {budget:F2}");
        }
    }
}
