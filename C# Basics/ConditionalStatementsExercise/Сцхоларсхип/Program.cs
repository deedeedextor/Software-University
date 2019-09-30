using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double averageGrade = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());

            double scholarshipSalary = Math.Floor(minSalary * 0.35);
            double scholarshipGrade = Math.Floor(averageGrade * 25);


            if (income > minSalary)
            {
                if(averageGrade  <= 4.5)
                {
                    Console.WriteLine("You cannot get a scholarship!");
                }

                else if(averageGrade  > 4.5 && averageGrade < 5.5)
                {
                    Console.WriteLine("You cannot get a scholarship!");
                }
                else if(averageGrade >= 5.5)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {scholarshipGrade} BGN");
                }
            }

            else if(income <= minSalary){
                if (averageGrade <= 4.5)
                {
                    Console.WriteLine("You cannot get a scholarship!");
                }
                else if (averageGrade > 4.5 && averageGrade  < 5.5)
                {
                    Console.WriteLine($"You get a Social scholarship {scholarshipSalary} BGN");
                }
                else if (averageGrade >= 5.5)
                {
                    if (scholarshipGrade >= scholarshipSalary)
                    {
                        Console.WriteLine($"You get a scholarship for excellent results {scholarshipGrade} BGN");
                    }
                    else if (scholarshipGrade <= scholarshipSalary)
                    {
                        Console.WriteLine($"You get a Social scholarship {scholarshipSalary} BGN");
                    }
                }
            }
        }
    }
}
