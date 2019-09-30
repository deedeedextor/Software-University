using System;

namespace _3.SubstringL
{
    class Program
    {
        static void Main(string[] args)
        {
            string removedWord = Console.ReadLine();

            string text = Console.ReadLine();

            //text = text.Replace(removedWord, string.Empty);

            int index = text.IndexOf(removedWord);

            while (index != -1)
            {
                text = text.Remove(index, removedWord.Length);
                index = text.IndexOf(removedWord);
            }
            Console.WriteLine(text);
        }
    }
}
