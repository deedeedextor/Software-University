using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ArrayManipulatorE
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                if (command[0] == "end")
                {
                    break;
                }

                if (command[0] == "exchange")
                {
                    int action = int.Parse(command[1]);

                    if (action >= array.Length || action < 0)
                    {
                        Console.WriteLine("Invalid index");
                        command = Console.ReadLine().Split();
                        continue;
                    }
                    array = ExchangeArray(array, action);
                }

                else if (command[0] == "max")
                {
                    if (command[1] == "even")
                    {
                        PrintMaxIndex(array, command[1]);
                    }
                    else if (command[1] == "odd")
                    {
                        PrintMaxIndex(array, command[1]);
                    }
                }
                else if (command[0] == "min")
                {
                    if (command[1] == "even")
                    {
                        PrintMinIndex(array, command[1]);
                    }
                    else if (command[1] == "odd")
                    {
                        PrintMinIndex(array, command[1]);
                    }
                }
                else if (command[0] == "first")
                {
                    int count = int.Parse(command[1]);

                    if (count > array.Length || count < 0)
                    {
                        Console.WriteLine("Invalid count");
                        command = Console.ReadLine().Split();
                        continue;
                    }

                    if (command[2] == "even")
                    {
                        PrintFirstElements(array, command[2], command[1]);
                    }

                    else
                    {
                        PrintFirstElements(array, command[2], command[1]);
                    }
                }
                else if (command[0] == "last")
                {
                    int count = int.Parse(command[1]);

                    if (count > array.Length || count < 0)
                    {
                        Console.WriteLine("Invalid count");
                        command = Console.ReadLine().Split();
                        continue;
                    }

                    if (command[2] == "even")
                    {
                        PrintLastElements(array, command[2], command[1]);
                    }

                    else
                    {
                        PrintLastElements(array, command[2], command[1]);
                    }
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine("[{0}]", string.Join(", ", array));
        }

        private static void PrintLastElements(int[] arr, string command, string count)
        {
            List<int> currentList = new List<int>();
            int currentCount = int.Parse(count);
            if (command == "even")
            {
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (arr[i] % 2 == 0)
                    {
                        currentList.Add(arr[i]);
                        currentCount--;
                        if (currentCount < 1)
                        {
                            break;
                        }
                    }
                }
                currentList.Reverse();
                Console.WriteLine("[{0}]", string.Join(", ", currentList));
            }
            else
            {
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (arr[i] % 2 != 0)
                    {
                        currentList.Add(arr[i]);
                        currentCount--;
                        if (currentCount < 1)
                        {
                            break;
                        }
                    }
                }
                currentList.Reverse();
                Console.WriteLine("[{0}]", string.Join(", ", currentList));
            }
        }
        private static void PrintFirstElements(int[] arr, string command, string count)
        {
            List<int> currentList = new List<int>();
            int currentCount = int.Parse(count);

            if (command == "even")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0)
                    {
                        currentList.Add(arr[i]);
                        currentCount--;

                        if (currentCount < 1)
                        {
                            break;
                        }
                    }
                }
                Console.WriteLine("[{0}]", string.Join(", ", currentList));
            }

            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 != 0)
                    {
                        currentList.Add(arr[i]);
                        currentCount--;

                        if (currentCount < 1)
                        {
                            break;
                        }
                    }
                }
                Console.WriteLine("[{0}]", string.Join(", ", currentList));
            }

        }

        private static void PrintMinIndex(int[] arr, string command)
        {
            int index = -1;
            int min = int.MaxValue;

            if (command == "even")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0)
                    {
                        if (min >= arr[i])
                        {
                            min = arr[i];
                            index = i;
                        }
                    }
                }
            }

            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 != 0)
                    {
                        if (min >= arr[i])
                        {
                            min = arr[i];
                            index = i;
                        }
                    }
                }
            }

            if (index >= 0)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        private static void PrintMaxIndex(int[] arr, string command)
        {
            int index = -1;
            int max = int.MinValue;

            if (command == "even")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0)
                    {
                        if (max <= arr[i])
                        {
                            max = arr[i];
                            index = i;
                        }
                    }
                }
            }

            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 != 0)
                    {
                        if (max <= arr[i])
                        {
                            max = arr[i];
                            index = i;
                        }
                    }
                }
            }

            if (index >= 0)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        private static int[] ExchangeArray(int[] array, int action)
        {
            int currentNumber = 0;

            for (int i = 0; i < array.Length - 1 - action; i++)
            {
                currentNumber = array[array.Length - 1];

                for (int j = array.Length - 1; j >= 1; j--)
                {
                    array[j] = array[j - 1];
                }
                array[0] = currentNumber;
            }
            return array;
        }
    }
}
 