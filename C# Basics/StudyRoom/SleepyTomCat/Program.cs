using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyTomCat
{
    class Program
    {
        static void Main(string[] args)
        {
            int restDays = int.Parse(Console.ReadLine());

            int tomsPlay = 30000;
            int workDays = 365 - restDays;
            int playTime = restDays * 127 + workDays * 63;
            double realPlayTime = Math.Abs(tomsPlay - playTime);
            double hours = Math.Truncate(realPlayTime / 60);
            double mins = Math.Abs(realPlayTime - (hours * 60));
            //double mins = realPlayTime % 60;

            if (playTime > tomsPlay)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{hours} hours and {mins} minutes more for play");
            }
            else if (playTime <= tomsPlay)
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{hours} hours and {mins} minutes less for play");
            }
        }
    }
}
