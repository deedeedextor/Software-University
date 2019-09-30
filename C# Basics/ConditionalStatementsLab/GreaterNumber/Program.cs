using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreaterNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            if (firstNumber > secondNumber)
            {
              Console.WriteLine(firstNumber);
            }
            else
            {
              Console.WriteLine(secondNumber);
            }

            //Console.WriteLine(Math.Max(firstNumber, secondNumber));

           // int minNumber = Math.Min(firstNumber, secondNumber);

          //  if (minNumber == firstNumber)
          //  {
          //      Console.WriteLine(secondNumber);
          //  }
          //  else
          //  {
          //      Console.WriteLine(firstNumber);
         //   }
        }
    }
}
