using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int guests = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            int couvert = 20 * guests;

            if (couvert <= budget)
            {
                int moneyLeft = budget - couvert;
                double moneyFireworks = Math.Ceiling(moneyLeft * 0.40);
                double moneyDonation = Math.Ceiling(moneyLeft - moneyFireworks);

                Console.WriteLine($"Yes! {moneyFireworks} lv are for fireworks and {moneyDonation} lv are for donation.");
            }

            else
            {
                Console.WriteLine($"They won't have enough money to pay the covert. They will need {couvert-budget} lv more.");
            }
        }
    }
}
