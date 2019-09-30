using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_15Mins
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            int mins = m + 15;
            int hours = h + mins / 60;
            int minsAfterHours = mins % 60;


            if (hours == 24)
            {
                Console.WriteLine("0:{0:00}", minsAfterHours);
            }
            else
            {
                Console.WriteLine("{0:0}:{1:00}", hours, minsAfterHours);
            }
        }
    }
}
