using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.StudentInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            double averageGrade = double.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {name}, Age: {age}, Grade: {averageGrade:F2}");
        }
    }
}
