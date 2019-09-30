using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Article2._0E
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] articleProps = Console.ReadLine().Split(", ");

                string title = articleProps[0];
                string content = articleProps[1];
                string author = articleProps[2];

                Article article = new Article(title, content, author);
                articles.Add(article);
            }

            string command = Console.ReadLine();

            if (command == "title")
            {
                articles = articles.OrderBy(x => x.Title).ToList();
            }

            else if (command == "content")
            {
                articles = articles.OrderBy(x => x.Content).ToList();
            }

            else if (command == "author")
            {
                articles = articles.OrderBy(x => x.Author).ToList();
            }

            foreach (Article article in articles)
            {
                Console.WriteLine(article);
            }
        }
    }

    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    };
}
