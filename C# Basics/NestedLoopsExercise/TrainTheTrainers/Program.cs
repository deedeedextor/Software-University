using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int juryNum = int.Parse(Console.ReadLine());
            double allPresentationGrads = 0;
            double countGrade = 0;

            while (true)
            {
                string presentation = Console.ReadLine();
                double gradesPresentation = 0;

                if (presentation == "Finish")
                {
                    double gradesSum = allPresentationGrads / countGrade;
                    Console.WriteLine($"Student's final assessment is {gradesSum:F2}.");
                    break;
                }

                for (int i = 0; i < juryNum; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    gradesPresentation += grade;
                    allPresentationGrads += grade;
                    countGrade++;
                }
                double singleGradePresentation = gradesPresentation / juryNum;
                Console.WriteLine($"{presentation} - {singleGradePresentation:F2}.");
            }


        }
    }
}
