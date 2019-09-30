using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.MixedUpListsME
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstListNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondListNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> resultList = new List<int>();
            List<int> numbersRange = new List<int>();
            
            int theSmallestList = Math.Min(firstListNumbers.Count, secondListNumbers.Count);
            secondListNumbers.Reverse();

            for (int i = 0; i < theSmallestList; i++)
            {
                resultList.Add(firstListNumbers[i]);
                resultList.Add(secondListNumbers[i]);
            }

            List<int> theBiggestList;

            if (theSmallestList == firstListNumbers.Count)
            {
                theBiggestList = secondListNumbers;
            }
            else
            {
                theBiggestList = firstListNumbers;
            }

            for (int i = theSmallestList; i < theBiggestList.Count; i++)
            {
                numbersRange.Add(theBiggestList[i]);
            }
            numbersRange.Sort();

            List<int> output = resultList.FindAll(n => n > numbersRange[0] && n < numbersRange[1]);
            output.Sort();
            Console.WriteLine(string.Join(" ", output));
        }
    }
}
