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
            int men = int.Parse(Console.ReadLine());
            int women = int.Parse(Console.ReadLine());
            int seats = int.Parse(Console.ReadLine());

            for (int i = 1; i <= men; i++)
            {
                for (int j = 1; j <= women; j++)
                {
                    if (seats == 0)
                    {
                        return;
                    }
                    Console.Write($"({i} <-> {j}) ");
                    seats--;
                }
            }
        }
    }
}
