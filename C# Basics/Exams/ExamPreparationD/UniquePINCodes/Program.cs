using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniquePINCodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumberBorder = int.Parse(Console.ReadLine());
            int secondNumberBorder = int.Parse(Console.ReadLine());
            int thirdNumberBorder = int.Parse(Console.ReadLine());

            for (int i = 1; i <= firstNumberBorder; i++)
            {
                for (int j = 1; j <= secondNumberBorder; j++)
                {
                    for (int k = 1; k <= thirdNumberBorder; k++)
                    {
                        switch (j)
                        {
                            case 2:
                            case 3:
                            case 5:
                            case 7:

                                if (i % 2 == 0 && k % 2 == 0)
                                {
                                    Console.WriteLine($"{i} {j} {k}");
                                }
                                break;
                        } 
                    }
                }
            }
        }
    }
}
