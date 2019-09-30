using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSyntaxDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            double first = 22.00;
            int second = 7;
            double pi = first / second;
            Console.WriteLine($"{pi:F2}");
        }
    }
}
