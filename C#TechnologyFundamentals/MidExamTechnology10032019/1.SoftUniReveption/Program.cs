using System;

namespace _1.SoftUniReveption
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmploee = int.Parse(Console.ReadLine());
            int secondEmploee = int.Parse(Console.ReadLine());
            int thirdEmploee = int.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            int hours = 0;

            int studentsPerHour = firstEmploee + secondEmploee + thirdEmploee;

            while (students > 0 )
            {
                if (students < studentsPerHour)
                {
                    hours++;
                    students = 0;
                    break;
                }

                hours++;
                students -= studentsPerHour;

                if (hours % 4 == 0)
                {
                    hours++;
                    continue;
                }
            }
            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
