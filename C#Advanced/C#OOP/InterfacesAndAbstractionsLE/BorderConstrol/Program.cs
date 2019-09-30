namespace BorderConstrol
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            List<Buyer> buyers = new List<Buyer>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfLines; i++)
            {
                var personData = Console.ReadLine()
                    .Split();
                var name = personData[0];

                if (personData.Length == 4)
                {
                    var age = int.Parse(personData[1]);
                    var id = personData[2];
                    var birthdate = personData[3];

                    buyers.Add(new Citizen(name, age, id, birthdate));
                }

                else
                {
                    var ageRebel = personData[1];
                    var group = personData[2];

                    buyers.Add(new Rebel(name, ageRebel, group));
                }
            }

            var nameToCheck = Console.ReadLine();

            while (nameToCheck != "End")
            {
                var currentBuyer = buyers.FirstOrDefault(p => p.Name == nameToCheck);

                if (currentBuyer != null)
                {
                    currentBuyer.BuyFood();
                }

                nameToCheck = Console.ReadLine();
            }

            Console.WriteLine(buyers.Sum(p => p.Food));
        }
    }
}
