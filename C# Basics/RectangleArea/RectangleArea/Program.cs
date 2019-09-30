using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter A:");
            var a = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter B:");
            var b = double.Parse(Console.ReadLine());

            Console.WriteLine("The area is:");
            Console.WriteLine(a * b);
        }
    }
}
