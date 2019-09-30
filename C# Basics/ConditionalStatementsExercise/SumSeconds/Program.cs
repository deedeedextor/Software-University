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
            int secs1 = int.Parse(Console.ReadLine());
            int secs2 = int.Parse(Console.ReadLine());
            int secs3 = int.Parse(Console.ReadLine());
            int sumSeconds = secs1 + secs2 + secs3;
            int mins = 0;

            if (sumSeconds <= 59)
            {
               mins = 0;
               sumSeconds = secs1 + secs2 + secs3;
            }
            else if (sumSeconds > 59 && sumSeconds < 120)
            {
                mins ++;
                sumSeconds -= 60;
            }
            else if (sumSeconds > 120 && sumSeconds <= 179)
            {
                mins += 2;
                sumSeconds -= 120;
            }

            if (sumSeconds < 10)
            {
                Console.WriteLine(mins + ":" + "0" + sumSeconds);
            }
            else
            {
                Console.WriteLine(mins + ":" + sumSeconds);
            }
        }
    }
}
