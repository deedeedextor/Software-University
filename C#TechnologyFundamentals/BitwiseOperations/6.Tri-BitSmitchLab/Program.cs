using System;

namespace _6.Tri_BitSmitchLab
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int position = int.Parse(Console.ReadLine());

            int mask = 7;
            mask = mask << position;

            Console.WriteLine(number ^ mask);
        }
    }
}
