using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcellentGrate
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            //Console.WriteLine("Grade after ABS " + Math.Abs(grade));


            if (grade > 6.00)
            {
                grade = 6.00;
            }

            if (grade < 2.00)
            {
                grade = 2.00;
            }

            if (grade >= 5.50)
            {
                Console.WriteLine($"Excellent {grade}");
            }
            else if (grade >= 4.50)
            {
                Console.WriteLine($"Very Good {grade}");
            }
            else if (grade >= 3.50)
            {
                Console.WriteLine($"Good {grade}");
            }
            else if (grade >= 3.00)
            {
                Console.WriteLine($"Try again {grade}");
            }
            else if (grade < 3)
            {
                Console.WriteLine($"See you September {grade}");
            }

        }
    }
}
