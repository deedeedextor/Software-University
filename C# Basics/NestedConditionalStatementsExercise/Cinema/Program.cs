using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string filmShow = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int column = int.Parse(Console.ReadLine());

            double price = 0.0;
            double seats = rows * column;

            if (filmShow == "Premiere")
            {
                price = 12.00;               
            }
            else if (filmShow == "Normal")
            {
                price = 7.50;
            }
            else if (filmShow == "Discount")
            {
                price = 5.00;
            }

            Console.WriteLine("{0:F2} leva", price * seats);
        }
    }
}
