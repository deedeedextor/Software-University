using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.AverageStudentGradesL
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            var studentsGrades = new Dictionary<string, List<double>>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] studentsProps = Console.ReadLine().Split();

                string student = studentsProps[0];
                double grade = double.Parse(studentsProps[1]);

                if (!studentsGrades.ContainsKey(student))
                {
                    studentsGrades[student] = new List<double>();
                }

                studentsGrades[student].Add(grade);
            }

            foreach (var studentsKvp in studentsGrades)
            {
                string studentName = studentsKvp.Key;
                List<double> studentsGrade = studentsKvp.Value;
                double averageGrade = studentsGrade.Average();

                Console.Write($"{studentName} -> ");

                foreach (var grade in studentsGrade)
                {
                    Console.Write($"{grade:F2} ");
                }

                Console.Write($"(avg: {averageGrade:F2})");
                Console.WriteLine();
            }
        }
    }
}
