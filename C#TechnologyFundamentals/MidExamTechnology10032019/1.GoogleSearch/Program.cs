using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.GoogleSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int users = int.Parse(Console.ReadLine());
            double moneyPerSearch = double.Parse(Console.ReadLine());
            double totalMoney = 0;
            double money = 0;

            for (int i = 1; i <= users; i++)
            {
                int wordsInRange = int.Parse(Console.ReadLine());

                if (i % 3 == 0)
                {
                    money = moneyPerSearch * 3;

                    if (wordsInRange > 5)
                    {
                        continue;
                    }

                    else if (wordsInRange == 1)
                    {
                        money = money * 2;
                    }
                }
                else
                {
                    money = moneyPerSearch;

                    if (wordsInRange > 5)
                    {
                        continue;
                    }

                    else if (wordsInRange == 1)
                    {
                        money = money * 2;
                    }
                }

                totalMoney += money * days;
            }
            Console.WriteLine($"Total money earned for {days} days: {totalMoney:F2}");
        }
    }
}
