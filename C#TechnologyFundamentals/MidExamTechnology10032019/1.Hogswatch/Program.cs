using System;

namespace _1.Hogswatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int homes = int.Parse(Console.ReadLine());
            int initialPresents = int.Parse(Console.ReadLine());
            int presentsToGive = initialPresents;
            int returningCount = 0;
            int additionalPresents = 0;
            int sumPresents = 0;

            for (int i = 1; i <= homes; i++)
            {
                int childrenPerHouse = int.Parse(Console.ReadLine());

                if (childrenPerHouse > presentsToGive)
                {
                    additionalPresents = childrenPerHouse - presentsToGive;
                    presentsToGive = (initialPresents / i) * (homes - i) + additionalPresents;
                    sumPresents += presentsToGive;
                    presentsToGive -= additionalPresents;
                    returningCount++;
                }

                else
                {
                    presentsToGive -= childrenPerHouse;
                }
            }

            if (returningCount == 0)
            {
                Console.WriteLine(presentsToGive);
            }
            else
            {
                Console.WriteLine($"{returningCount}\n{sumPresents}");
            }
        }
    }
}
