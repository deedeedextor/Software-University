using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int cake = width * length;

            string input = string.Empty;

            while (true)
            {
                input = Console.ReadLine();
                if (input != "STOP")
                {
                    cake -= int.Parse(input);
                }
                else
                {
                    Console.WriteLine($"{cake} pieces are left.");
                    break;
                }
                if (cake < 0)
                {
                    Console.WriteLine($"No more cake left! You need {Math.Abs(cake)} pieces more.");
                    break;
                }
            }
        }
    }
}
