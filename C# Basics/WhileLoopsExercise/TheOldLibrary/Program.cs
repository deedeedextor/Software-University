using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOldLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            string bookName = Console.ReadLine();
            int capacity = int.Parse(Console.ReadLine());

            int bookcount = 0;
            string LibraryBooks = string.Empty;

            while (LibraryBooks != bookName)
            {
                LibraryBooks = Console.ReadLine();               

                if (LibraryBooks == bookName)
                {
                    Console.WriteLine($"You checked {bookcount} books and found it.");
                    break;
                }
                bookcount++;

                if (bookcount == capacity)
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {bookcount} books.");
                    break;
                }              
               
            }
        }
    }
}
