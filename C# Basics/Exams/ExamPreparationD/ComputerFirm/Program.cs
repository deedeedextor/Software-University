using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerFirm
{
    class Program
    {
        static void Main(string[] args)
        {
            int computers = int.Parse(Console.ReadLine());
            double totalSales = 0;
            double totalRating = 0;

            for (int i = 0; i < computers; i++)
            {
                int number = int.Parse(Console.ReadLine());

                int rating = number % 10;
                int sales = number / 10;
                totalRating += rating;

                if (rating == 3)
                {
                    totalSales += sales * 0.50;
                }
                else if (rating == 4)
                {
                    totalSales += sales * 0.70;
                }
                else if (rating == 5)
                {
                    totalSales += sales * 0.85;
                }
                else if (rating == 6)
                {
                    totalSales += sales;
                }
            }
            Console.WriteLine($"{(totalSales):f2}");
            Console.WriteLine($"{(totalRating / computers):f2}");
        }
    }
}
