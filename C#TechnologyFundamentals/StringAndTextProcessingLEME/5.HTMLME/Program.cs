using System;
using System.Collections.Generic;

namespace _5.HTMLME
{
    class Program
    {
        static void Main(string[] args)
        {
            string articleName = Console.ReadLine();
            string articleContent = Console.ReadLine();
            string input = string.Empty;

            List<string> comments = new List<string>();

            while ((input = Console.ReadLine()) != "end of comments")
            {
                comments.Add(input);
            }
            Console.WriteLine($"<h1>\n{articleName}\n</h1>");
            Console.WriteLine($"<article>\n{articleContent}\n</article>");

            foreach (var comment in comments)
            {
                Console.WriteLine($"<div>\n{comment}\n</div>");
            }
        }
    }
}
