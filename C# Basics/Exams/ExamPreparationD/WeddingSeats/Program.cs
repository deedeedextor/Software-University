using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingSeats
{
    class Program
    {
        static void Main(string[] args)
        {
            char lastSector = char.Parse(Console.ReadLine());
            int numRowsFirstSector = int.Parse(Console.ReadLine());
            int numSeatsOddRow = int.Parse(Console.ReadLine());
            int total = 0;

            for (char i = 'A'; i <= lastSector; i++)
            {
                for (int j = 1; j <= numRowsFirstSector; j++)
                {
                    if (j % 2 != 0)
                    {
                        for (int k = 1; k <= numSeatsOddRow; k++)
                        {
                            Console.WriteLine($"{i}{j}{(char)(k+96)}");
                            total++;
                        }
                    }
                    else if (j % 2 == 0)
                    {
                        for (int k = 1; k <= numSeatsOddRow +2; k++)
                        {
                            Console.WriteLine($"{i}{j}{(char)(k + 96)}");
                            total++;
                        }
                    }
                    
                }
                numRowsFirstSector++;
            }
            Console.WriteLine(total);
        }
    }
}
