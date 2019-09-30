using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafePasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int maxPasswords = int.Parse(Console.ReadLine());
            int counter = 0;

            for (char A = '#'; A <= '7'; A++)
            {
                for (char B = '@'; B <= '~'; B++)
                {
                    for (int x = 1; x <= a; x++)
                    {
                        for (int y = 1; y <= b; y++)
                        {
                            Console.Write($"{A}{B}{x}{y}{B}{A}|");
                            counter++;

                            if (counter >= maxPasswords || (x == a && y == b))
                            {
                                return;
                            }
                            A++;
                            B++;
                            if (A >'7')
                            {
                                A = '#';
                            }
                            if (B > '~')
                            {
                                B = '@';
                            }
                        }                        
                    }
                }
            }

        }
    }
}
