using System;
using System.Linq;
using System.Collections.Generic;

namespace _7.OrderByAgeE
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                if (input == "End")
                {
                    break;
                }

                string[] studentsProps = input.Split();

                string name = studentsProps[0];
                string id = studentsProps[1];
                int age = int.Parse(studentsProps[2]);

                Student student = new Student(name, id, age);
                students.Add(student);

                input = Console.ReadLine();
            }

            List<Student> filteredStudents = students.OrderBy(x => x.Age).ToList();

            foreach (Student student in filteredStudents)
            {
                Console.WriteLine($"{student.Name} with ID: {student.Id} is {student.Age} years old.");
            }
        }    
    }

    class Student
    {
        public Student(string name, string id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }

        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
    }
}
