using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;
            int counter = 0;

            for (char i = 'B'; i <= 'L'; i++)           
            {
                if (i%2 != 0)
                {
                    continue;
                }
                for (char j = 'f'; j >= 'a'; j--)
                {
                    for (char k = 'A'; k <= 'C'; k++)
                    {
                        for (int l = 1; l <= 10; l++)
                        {
                            for (int m = 10; m >= 1; m--)
                            {
                                counter++;

                                if (counter == number)
                                {
                                    sum = i + j + k + l + m;
                                    Console.WriteLine($"Ticket combination: {i}{j}{k}{l}{m}");
                                    Console.WriteLine($"Prize: {sum} lv.");
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
