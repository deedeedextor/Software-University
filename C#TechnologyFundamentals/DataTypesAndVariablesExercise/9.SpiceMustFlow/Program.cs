using System;

namespace _9.SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int totalYield = 0;
            int daysCount = 0;
           
            while (startingYield >= 100)
            {
                totalYield += startingYield - 26;
                startingYield -= 10;

                daysCount++;
            }

            if (totalYield >= 26)
            {
                totalYield -= 26;
            }
          
            Console.WriteLine($"{daysCount}\n{totalYield}");           
        }
    }
}
