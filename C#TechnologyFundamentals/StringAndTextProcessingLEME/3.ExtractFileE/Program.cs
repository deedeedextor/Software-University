using System;

namespace _3.ExtractFileE
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int startIndexofFile = input.LastIndexOf('\\') + 1;

            string file = input.Substring(startIndexofFile);
            int indexOfPoint = file.LastIndexOf('.') + 1;

            string nameFile = file.Substring(0, indexOfPoint - 1);
            string extension = file.Substring(indexOfPoint);

            Console.WriteLine($"File name: {nameFile}\nFile extension: {extension}");
        }
    }
}
