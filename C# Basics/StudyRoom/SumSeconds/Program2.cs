using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumSeconds
{
    class Program2
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int seconds = a + b + c;
            int minutes = 0;

            minutes = seconds / 60;
            seconds -= minutes * 60;


            Console.WriteLine(minutes + ":" + seconds.ToString().PadLeft(2, '0'));


        }
    }
}
