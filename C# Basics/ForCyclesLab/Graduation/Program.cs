using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int classes = 1;
            double badGrades = 0;
            double sum = 0;
            double avg = 0;

            while (classes <=12)
            {
                double currentGrade = double.Parse(Console.ReadLine());

                if (currentGrade >= 4.00)
                {
                    sum += currentGrade;
                    if (classes == 12)
                    {
                        avg = sum / 12;
                        Console.WriteLine($"{name} graduated. Average grade: {avg:F2}");
                    }
                    classes++;
                }
                else
                {
                    badGrades++;
                    if (badGrades > 1)
                    {
                        Console.WriteLine($"{name} has been excluded at {classes} grade");
                        break;
                    }
                }
            }
            //double avg = sum / 12;
            //Console.WriteLine($"{name} graduated. Average grade: {avg:F2}");
        }
    }
}
               
               