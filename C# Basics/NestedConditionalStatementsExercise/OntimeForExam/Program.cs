using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntimeForExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hourExam = int.Parse(Console.ReadLine());
            int minExam = int.Parse(Console.ReadLine());
            int hourArrival = int.Parse(Console.ReadLine());
            int minArrival = int.Parse(Console.ReadLine());

            int examTimeInMins = hourExam * 60 + minExam;
            int arrivalTimaInMins = hourArrival * 60 + minArrival;
            int minsDifference = arrivalTimaInMins - examTimeInMins;

            if (minsDifference < -30)
            {
                Console.WriteLine("Early");
            }
            else if(minsDifference <= 0)
            {
                Console.WriteLine("On time");
            }
            else
            {
                Console.WriteLine("Late");
            }

            int hours = Math.Abs(minsDifference / 60);
            int minutes = Math.Abs(minsDifference % 60);

            if (hours > 0)
            {
                if (minutes < 10)
                {
                    Console.Write(hours + ":0" + minutes + " hours");
                }
                else
                {
                    Console.Write(hours + ":" + minutes + " hours");
                }
            }
            else
            {
                Console.Write(minutes + " minutes");
            }

            if (minsDifference < 0)
            {
                Console.WriteLine(" before the start");
            }
            else
            {
                Console.WriteLine(" after the start");
            }
        }
    }
}
