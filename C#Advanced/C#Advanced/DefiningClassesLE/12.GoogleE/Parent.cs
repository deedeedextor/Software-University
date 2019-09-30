﻿namespace _12.GoogleE
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Parent
    {
        private string name;
        private string birthday;

        public Parent(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Birthday
        {
            get { return this.birthday; }
            set { this.birthday = value; }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Birthday}";
        }
    }
}
