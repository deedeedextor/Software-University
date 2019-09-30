namespace CustomList
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = new CustomList();

            numbers.Add(5);
            numbers.Add(10);
            numbers.Add(15);

            Console.WriteLine(numbers.Count == 3);

            numbers.RemoveAt(0);

            //10, 15
            Console.WriteLine(numbers.Count == 2);

            //numbers.Insert(3, 1);
            numbers.Insert(2, 5);
            bool isValid = numbers.Contains(10);
            
            //10, 15, 5
            Console.WriteLine(isValid);
            Console.WriteLine(numbers.Count == 3);

            numbers.Swap(0, 2);

            Console.WriteLine(numbers[0].ToString() == 5.ToString());
            Console.WriteLine(numbers[2].ToString() == 10.ToString());

            Console.WriteLine(numbers.Count == 3);
        }
    }
}
