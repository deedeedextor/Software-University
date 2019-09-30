using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementEqualsTheSumOfTheOthers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int max = int.MinValue;

            for (int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                
                if (number > max)
                {
                    max = number;
                }
                sum += number;
            }
            sum -= max;

            if (sum == max)
            {
                Console.WriteLine($"Yes, Sum = {sum}");
            }
            else
            {
                Console.WriteLine($"No, Diff = {Math.Abs(sum - max)}"); 
            }

        }
    }
}
