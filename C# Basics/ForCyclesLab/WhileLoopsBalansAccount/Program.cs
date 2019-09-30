using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhileLoopsBalansAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int payments = 0;
            double balans = 0.00;

            while (payments < number)
            {
                double amount = double.Parse(Console.ReadLine());
                
                if (amount < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                balans += amount;
                Console.WriteLine($"Increase: {amount:F2}");
                payments++;             
            }
            
            Console.WriteLine($"Total: {balans:F2}");
        }
    }
}
