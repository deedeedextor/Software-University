namespace CustomStack
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = new CustomStack();

            numbers.Push(1);
            numbers.Push(2);
            numbers.Push(3);

            numbers.Pop();

            Console.WriteLine(numbers.Peek() == 2);
            Console.WriteLine(numbers.Count == 2);
            Console.WriteLine(numbers.Contains(5) == true);

            numbers.Clear();
            Console.WriteLine(numbers.Count == 0);
        }
    }
}
