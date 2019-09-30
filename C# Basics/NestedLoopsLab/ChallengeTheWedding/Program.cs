using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTheWedding
{
    class Program
    {
        static void Main(string[] args)
        {
            int mCounter = int.Parse(Console.ReadLine());
            int fCounter = int.Parse(Console.ReadLine());
            int tables = int.Parse(Console.ReadLine());

            for (int i = 1; i <= mCounter; i++)
            {
                for (int j = 1; j <= fCounter; j++)
                {
                    if (tables == 0)
                    {
                        return;
                    }

                    Console.Write($"({i} <-> {j}) ");
                    tables--;                   
                }
            }
        }
    }
}
