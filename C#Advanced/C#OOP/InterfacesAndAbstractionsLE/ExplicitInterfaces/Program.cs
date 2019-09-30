namespace ExplicitInterfaces
{
    using ExplicitInterfaces.Interfaces;
    using ExplicitInterfaces.Models;
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            PrintName();
        }

        private static void PrintName()
        {
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                var citizenTokens = input.Split();
                var name = citizenTokens[0];

                //var person = new Citizen(name);

                //Console.WriteLine(((IPerson)person).GetName());
                //Console.WriteLine(((IResident)person).GetName());

                IPerson person = new Citizen(name);
                Console.WriteLine(person.GetName());

                IResident resident = new Citizen(name);
                Console.WriteLine(resident.GetName());
            } 
        }
    }
}
