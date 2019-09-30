using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.PokemonDon_tGoE
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToList();

            int sum = 0;

            while (numbers.Count != 0)
            {
                if (numbers.Count == 0)
                {
                    break;
                }

                int index = int.Parse(Console.ReadLine());

                int element;

                if (index < 0)
                {
                    element = numbers[0];
                    numbers[0] = numbers[numbers.Count - 1];
                }

                else if (index >= numbers.Count)
                {
                    element = numbers[numbers.Count - 1];
                    numbers[numbers.Count - 1] = numbers[0];
                }

                else
                {
                    element = numbers[index];
                    numbers.RemoveAt(index);
                }
                sum += element;

                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] <= element)
                    {
                        numbers[i] += element;
                    }
                    else
                    {
                        numbers[i] -= element;
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
