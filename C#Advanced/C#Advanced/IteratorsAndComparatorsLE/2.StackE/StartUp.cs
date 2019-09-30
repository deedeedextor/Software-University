namespace _2.StackE
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            CustomStack<int> customStack = new CustomStack<int>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] splittedInput = input.Split(" ", 2);

                string command = splittedInput[0];

                if (command == "Push")
                {
                    int[] numbers = splittedInput[1]
                        .Split(", ")
                        .Select(int.Parse)
                        .ToArray();

                    customStack.Push(numbers);
                }

                else
                {
                    try
                    {
                        customStack.Pop();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var number in customStack)
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}
