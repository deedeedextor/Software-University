namespace MergeSortDemo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> unsortedCollection = new List<int>();
            List<int> sortedCollection;

            Random random = new Random();

            Console.WriteLine("Original array elements are: ");

            for (int i = 0; i < 10; i++)
            {
                unsortedCollection.Add(random.Next(0, 100));
                Console.Write(unsortedCollection[i] + " ");
            }

            Console.WriteLine();

            sortedCollection = MergeSort(unsortedCollection);

            Console.WriteLine("Sorted array elements are: ");

            foreach (var element in sortedCollection)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }

        private static List<int> MergeSort(List<int> unsorted)
        {
            if (unsorted.Count <= 1)
            {
                return unsorted;
            }

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middlePoint = unsorted.Count / 2;

            //dividing the unsorted collection
            for (int i = 0; i < middlePoint; i++)
            {
                left.Add(unsorted[i]);
            }

            for (int i = middlePoint; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> sortedCollection = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    //Comparing which of the two elements is smaller
                    if (left.First() <= right.First())
                    {
                        sortedCollection.Add(left.First());
                        left.Remove(left.First());
                    }

                    else
                    {
                        sortedCollection.Add(right.First());
                        right.Remove(right.First());
                    }
                }

                else if (left.Count > 0)
                {
                    sortedCollection.Add(left.First());
                    left.Remove(left.First());
                }

                else if (right.Count > 0)
                {
                    sortedCollection.Add(right.First());
                    right.Remove(right.First());
                }
            }

            return sortedCollection;
        }
    }
}
