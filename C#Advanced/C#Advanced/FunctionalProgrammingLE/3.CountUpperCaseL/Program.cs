using System;
using System.Linq;

namespace _3.CountUpperCaseL
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> checker = w => w[0] == w.ToUpper()[0];

            string[] words = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Where(checker)
                .ToArray();

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
