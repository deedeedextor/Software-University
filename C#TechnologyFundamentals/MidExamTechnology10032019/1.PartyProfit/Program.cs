using System;
using System.Linq;

namespace _1.PartyProfitMid
{
    class Program
    {
        static void Main(string[] args)
        {
            int partySize = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int budget = 0;

            for (int i = 1; i <= days; i++)
            {
                if (i % 10 == 0)
                {
                    partySize = partySize - 2;
                }
                if (i % 15 == 0)
                {
                    partySize = partySize + 5;
                }

                budget = budget + 50;
                budget = budget - (partySize * 2);

                if (i % 3 == 0)
                {
                    budget = budget - (3 * partySize);
                }
                if (i % 5 == 0)
                {
                    budget = budget + (partySize * 20);

                    if (i % 3 == 0)
                    {
                        budget = budget - (2 * partySize);
                    }
                }

            }
            int moneyForCompanion = budget / partySize;

            Console.WriteLine($"{partySize} companions received {moneyForCompanion} coins each.");
        }
    }
}
