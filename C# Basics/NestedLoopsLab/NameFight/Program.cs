using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameFight
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int maxCombination = int.MinValue;
            string winner = string.Empty;

            while (name != "STOP")
            {
                int currentSum = 0;
                for (int i = 0; i < name.Length; i++)
                {
                    currentSum += name[i];
                }

                if (currentSum > maxCombination)
                {
                    maxCombination = currentSum;
                    winner = $"Winner is {name} - {currentSum}!";
                }
                name = Console.ReadLine();              
            }

            Console.WriteLine(winner);
        }
    }
}
