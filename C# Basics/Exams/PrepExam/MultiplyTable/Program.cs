using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int result = 0;

            int digi1 = number / 100 % 10;
            int digi2 = number / 10 % 10;
            int digi3 = number % 10;           

            for (int i = 1; i <= digi1; i++) 
            {
                for (int j = 1; j <= digi2; j++)
                {
                    for (int k = 1; k <= digi3; k++)
                    {                     
                        result = i * j * k;
                        Console.WriteLine($"{i} * {j} * {k} = {result}");
                    }
                }               
            }           
        }
    }
}
