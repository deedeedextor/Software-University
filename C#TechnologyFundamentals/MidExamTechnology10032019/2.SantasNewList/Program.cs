using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.SantasNewList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Child> children = new List<Child>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                

                string[] childrenProps = input.Split("->");

                string childName = childrenProps[0];
                string typeOfToy = childrenProps[1];
                int amountOfToys = int.Parse(childrenProps[2]);

                Child child = new Child(childName, typeOfToy, amountOfToys);
                children.Add(child);
            }
            
        }
    }

    class Child
    {
        public Child(string childName, string typeOfToy, int amountOfToys)
        {
            ChildName = childName;
            TypeOfToy = typeOfToy;
            AmountOfToys = amountOfToys;
        }
        public string ChildName { get; set; }
        public string TypeOfToy { get; set; }
        public int AmountOfToys { get; set; }
    }


}
