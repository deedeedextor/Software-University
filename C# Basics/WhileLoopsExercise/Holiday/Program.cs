using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holiday
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyForExcursion = double.Parse(Console.ReadLine());
            double availableMoney = double.Parse(Console.ReadLine());

            int counterForSpending = 0;
            int countDays = 0;           

            while (true)
            {
                countDays++;
                string command = Console.ReadLine();
                double moneyForUsing = double.Parse(Console.ReadLine());               

               if (command == "spend")
               {
                    counterForSpending++;

                    if (counterForSpending == 5)
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine($"{countDays}");
                        return;
                    }

                    availableMoney -= moneyForUsing;

                    if (availableMoney < 0)
                    {
                        availableMoney = 0;
                    }
               }
               else if (command == "save")
               {
                    counterForSpending = 0;
                    availableMoney += moneyForUsing;
               }               

                if (availableMoney >= moneyForExcursion)
                {
                    Console.WriteLine($"You saved the money for {countDays} days.");
                    return;
                }
            }           
        }
    }
}
