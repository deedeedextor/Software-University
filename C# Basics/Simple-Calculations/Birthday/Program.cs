using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthday
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            int volumeInCubicSantimeters = lenght * width * height;
            double volumeInLiters = volumeInCubicSantimeters * 0.001;

            double noNeededPercents = percent * 0.01;
            double finalResult = volumeInLiters * (1 - noNeededPercents);

            Console.WriteLine($"{finalResult:F3}");
        }
    }
}
