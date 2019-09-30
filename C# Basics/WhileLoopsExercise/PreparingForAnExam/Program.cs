using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreparingForAnExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int badGrades = int.Parse(Console.ReadLine());

            int countBadGrades = 0;
            int counter = 0;
            double sum = 0;
            string lastTask = string.Empty;
           
            while (true)
            {
                string task = Console.ReadLine();
                int currentGrade = 0;
               
                if (task != "Enough")
                {
                    counter++;
                    currentGrade = int.Parse(Console.ReadLine());
                    lastTask = task;
                }
                sum += currentGrade;

                if (task == "Enough")
                {                                      
                    double average = sum / counter;
                    Console.WriteLine($"Average score: {average:F2}");
                    Console.WriteLine($"Number of problems: {counter}");
                    Console.WriteLine($"Last problem: {lastTask}");
                    return;
                }

                if (currentGrade <= 4)
                {
                    countBadGrades++;
                }

                if (countBadGrades == badGrades)
                { 
                    Console.WriteLine($"You need a break, {countBadGrades} poor grades.");
                    return;
                }              
            }
        }
    }

}
