namespace CustomLinkedList
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var list = new DoublyLinkedList<int>();

            list.AddFirst(15);
            list.AddFirst(20);
            list.AddFirst(25);
            list.AddFirst(30);

            //30-25-20-15

            list.AddLast(5);
            list.AddLast(3);
            list.AddLast(1);

            //30-25-20-15-5-3-1

            Console.WriteLine(list.Count == 7);
            list.ForEach(l => Console.WriteLine(l));

            list.RemoveFirst();
            list.RemoveLast();

            // 25-20-15-5-3

            Console.WriteLine(list.Count == 5);
            list.ForEach(l => Console.WriteLine(l));

            list.ToArray();
            list.RemoveLast();
            Console.WriteLine(list.Count == 4);
            list.ForEach(l => Console.WriteLine(l));

            Console.WriteLine(list.Contains(5) == true);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
