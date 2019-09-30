using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureArea
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();


            if (figure == "square")
            {
                double a = double.Parse(Console.ReadLine());
                double area = a * a;
                Console.WriteLine(area);
            }
            else if (figure == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                double area = a * b;
                Console.WriteLine(area);
            }
            else if (figure == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                double area = Math.PI * r * r;
                Console.WriteLine($"{area:F3}");
            }
            else if (figure == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());
                double area = (a * h) / 2;
                Console.WriteLine(area);
            }
        }
    }
}
