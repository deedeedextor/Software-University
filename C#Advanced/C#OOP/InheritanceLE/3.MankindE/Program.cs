namespace _3.MankindE
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] studentTokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string studentFirstName = studentTokens[0];
                string studentLastName = studentTokens[1];
                string facultyNumber = studentTokens[2];

                Student student = new Student(studentFirstName, studentLastName, facultyNumber);

                string[] workerTokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string workerFirstName = workerTokens[0];
                string workerLastName = workerTokens[1];
                double weekSalary = double.Parse(workerTokens[2]);
                double hoursPerDay = double.Parse(workerTokens[3]);

                Worker worker = new Worker(workerFirstName, workerLastName, weekSalary, hoursPerDay);

                Console.WriteLine(student);
                Console.WriteLine();
                Console.WriteLine(worker);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
