﻿namespace _2.BookShopE
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Book
    {
        private string title;
        private string author;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            protected set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }

                this.title = value;
            }
        }

        public string Author
        {
            get
            {
                return this.author;
            }

            protected set
            {
                string[] splittedName = value.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string secondName = splittedName[1];

                if (char.IsDigit(secondName[0]))
                {
                    throw new ArgumentException("Author not valid!");
                }

                this.author = value;
            }
        }

        public virtual decimal Price
        {
            get
            {
                return this.price;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            var information = new StringBuilder();

            information.AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Title: {this.Title}")
                .AppendLine($"Author: {this.Author}")
                .AppendLine($"Price: {this.Price:f2}");

            return information.ToString().TrimEnd();
        }
    }
}
