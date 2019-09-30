using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.StudentsE
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] studentsProps = Console.ReadLine().Split();

                string firstName = studentsProps[0];
                string secondName = studentsProps[1];
                double grade = double.Parse(studentsProps[2]);

                Student student = new Student(firstName, secondName, grade);
                students.Add(student);
            }

            students = students.OrderBy(x => x.Grade).ToList();
            students.Reverse();

            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
        }
    }

    class Student
    {
        public Student(string firstName, string secondName, double grade)
        {
            FirstName = firstName;
            SecondName = secondName;
            Grade = grade;
        }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {SecondName}: {Grade:F2}";
        }
    }
}
