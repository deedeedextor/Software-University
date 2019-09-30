using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingPresents
{
    class Program
    {
        static void Main(string[] args)
        {
            double guest = int.Parse(Console.ReadLine());
            double presents = int.Parse(Console.ReadLine());          

            double countA = 0;
            double countB = 0;
            double countV = 0;
            double countG = 0;
            double percentA = 0;
            double percentB = 0;
            double percentV = 0;
            double percentG = 0;


            for (int i = 0; i < presents; i++)
            {
                string letter = Console.ReadLine();

                if (letter == "A")
                {
                    countA++;
                    percentA = countA / presents * 100;
                }
                else if (letter == "B")
                {
                    countB++;
                    percentB = countB / presents * 100;
                }
                else if (letter == "V")
                {
                    countV++;
                    percentV = countV / presents * 100;
                }
                else if (letter == "G")
                {
                    countG++;
                    percentG = countG / presents * 100;
                }
            }
          
            double percentGuests = presents / guest * 100;

            Console.WriteLine($"{percentA:F2}%");
            Console.WriteLine($"{percentB:F2}%");
            Console.WriteLine($"{percentV:F2}%");
            Console.WriteLine($"{percentG:F2}%");
            Console.WriteLine($"{percentGuests:F2}%");
        }
    }
}
