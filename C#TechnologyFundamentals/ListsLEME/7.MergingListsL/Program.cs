using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.MergingListsL
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> resultList = new List<int>();

            int minCount = Math.Min(firstList.Count, secondList.Count);

            for (int i = 0; i < minCount; i++)
            {
                resultList.Add(firstList[i]);
                resultList.Add(secondList[i]);
            }

            List<int> biggerList;

            if (minCount == firstList.Count)
            {
                biggerList = secondList;
            }
            else
            {
                biggerList = firstList;
            }

            for (int i = minCount; i < biggerList.Count; i++)
            {
                resultList.Add(biggerList[i]);
            }

            Console.WriteLine(string.Join(" ", resultList));
        }
    }
}
