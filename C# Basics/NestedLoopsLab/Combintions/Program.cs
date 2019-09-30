using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combintions
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;
            int countCombinations = 0;

           
            for (int i = 0; i <= num; i++)
            {
                for (int k = 0; k <= num; k++)
                {
                    for (int l = 0; l <= num; l++)
                    {
                        for (int m = 0; m <= num; m++)
                        {
                            for (int n = 0; n <= num; n++)
                            {
                                sum = i + k + l + m + n;

                                if (sum == num)
                                {                                  
                                    countCombinations++;                                
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(countCombinations);
        }
    }
}
