using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenghtHall = double.Parse(Console.ReadLine());
            double widthHall = double.Parse(Console.ReadLine());
            double sideBar = double.Parse(Console.ReadLine());

            double hall = lenghtHall * widthHall;
            double bar = sideBar * sideBar;
            double dancing = hall * 0.19;
            double freeSpace = hall - bar - dancing;
            double guests = Math.Ceiling(freeSpace / 3.2);

            Console.WriteLine($"{guests}");

        }
    }
}
