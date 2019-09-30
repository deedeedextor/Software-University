using System;
using System.Collections.Generic;

namespace _5.CalculateSequenceWithQueueE
{
    class Program
    {
        static void Main(string[] args)
        {
            long inputNumber = long.Parse(Console.ReadLine());

            var queue = new Queue<long>();
            queue.Enqueue(inputNumber);

            List<long> numbers = new List<long>();
            numbers.Add(inputNumber);

            for (int i = 0; i < 50; i++)
            {
                long currentNumber = queue.Dequeue();

                long first = currentNumber + 1;
                long second = currentNumber * 2 + 1;
                long third = currentNumber + 2;

                queue.Enqueue(first);
                queue.Enqueue(second);
                queue.Enqueue(third);

                numbers.Add(first);
                numbers.Add(second);
                numbers.Add(third);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
