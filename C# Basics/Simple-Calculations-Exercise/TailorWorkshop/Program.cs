using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TailorWorkshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numTables = int.Parse(Console.ReadLine());
            double lenghtTables = double.Parse(Console.ReadLine());
            double widthTables = double.Parse(Console.ReadLine());

            double areaTablecloth = numTables * (lenghtTables + 2 * 0.30) * (widthTables + 2 * 0.30);
            double areaSquare = numTables * (lenghtTables / 2) * (lenghtTables / 2);

            double amountUSD = (areaTablecloth * 7) + (areaSquare * 9);
            double amountBGN = amountUSD * 1.85;

            Console.WriteLine($"{amountUSD:F2} USD");
            Console.WriteLine($"{amountBGN:F2} BGN");
        }
    }
}
