using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleIntCurrencyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double amount = double.Parse(Console.ReadLine());
            string firstCurrency = Console.ReadLine();
            string secondCurrency = Console.ReadLine();

            double firstRate = 1; 

            if (firstCurrency == "USD")
            {
                firstRate = 1.79549;
            }
            else if (firstCurrency == "EUR")
            {
                firstRate = 1.95583;
            }
            else if (firstCurrency == "GBP")
            {
                firstRate = 2.53405;
            }

            double secondRate = 1;

            if (secondCurrency == "USD")
            {
                secondRate = 1.79549;
            }
            else if (secondCurrency == "EUR")
            {
                secondRate = 1.95583;
            }
            else if (secondCurrency == "GBP")
            {
                secondRate = 2.53405;
            }

            double result = amount * (firstRate / secondRate);
            Console.WriteLine($"{result:F2}"+ " "  + secondCurrency);
        }
    }
}
