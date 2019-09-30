namespace CustomStack
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var stack = new StackOfStrings();

            stack.Pushrange("1", "2", "3");

            Console.WriteLine(stack.Pop());
        }
    }
}
