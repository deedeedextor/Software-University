using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            double L = double.Parse(Console.ReadLine());
            double W = double.Parse(Console.ReadLine());
            double A = double.Parse(Console.ReadLine());

            double areaHouse = (L * 100) * (W * 100);
            double areaWardrobe = (A * 100) * (A * 100);
            double areaBench = areaHouse / 10;
            double freeSpace = areaHouse - areaWardrobe - areaBench;
            double dancers = freeSpace / (40 + 7000);
           
            Console.WriteLine(Math.Floor(dancers));
        }
    }
}
