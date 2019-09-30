using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.TriFunctionE
{
    class Program
    {
        static void Main(string[] args)
        {
            int maximumSum = int.Parse(Console.ReadLine());

            Func<string, char[]> funcCharArray = x => x.ToCharArray();
            Func<char, int> funcCast = y => (int)y;
            Func<string, bool> funcResult = x => funcCharArray(x)
                                                 .Select(funcCast)
                                                 .Sum() >= maximumSum;


            Console.WriteLine(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .FirstOrDefault(funcResult)); 
                
        }
    }
}
