using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int seconds = a + b + c;
            int minutes = 0;

            if ( seconds <= 59)
            {
                minutes = 0;
                seconds = a + b + c;
            }

            if ( seconds > 59 && seconds < 120)
            {
                minutes ++;
                seconds = seconds - 60;
            }

            if (seconds > 120 && seconds < 179)
            {
                minutes += 2;
                seconds = seconds - 120;
            }


            if (seconds < 10)
            {
                Console.WriteLine(minutes + ":" + "0" + seconds);
            }
            else
            {
                Console.WriteLine(minutes + ":" + seconds);
            }
        }
    }
}
