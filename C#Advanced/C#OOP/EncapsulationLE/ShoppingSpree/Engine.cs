namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Engine
    {
        private List<Person> peopleCollection;
        private List<Product> productCollection;

        public Engine()
        {
            this.peopleCollection = new List<Person>();
            this.productCollection = new List<Product>();
        }

        public void Run()
        {
            try
            {
                GetPersonsInfo();
                GetProductsInfo();

                string purchase = Console.ReadLine();

                while (purchase != "END")
                {
                    string[] inputArguments = purchase
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    Person buyer = peopleCollection.FirstOrDefault(x => x.Name == inputArguments[0]);
                    Product product = productCollection.FirstOrDefault(y => y.Name == inputArguments[1]);

                    buyer.AddProduct(product);

                    purchase = Console.ReadLine();
                }

                foreach (Person person in peopleCollection)
                {
                    if (person.Products.Count > 0)
                    {
                        Console.WriteLine("{0} - {1}", person.Name, String.Join(", ", person.Products.Select(p => p.Name)));
                    }
                    else
                    {
                        Console.WriteLine("{0} - Nothing bought", person.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void GetProductsInfo()
        {
            string[] products = Console.ReadLine()
                    .Split(new[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < products.Length; i += 2)
            {
                string name = products[i];
                decimal cost = decimal.Parse(products[i + 1]);

                Product product = new Product(name, cost);

                productCollection.Add(product);
            }
        }

        private void GetPersonsInfo()
        {
            string[] people = Console.ReadLine()
                    .Split(new[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < people.Length; i += 2)
            {
                string name = people[i];
                decimal money = decimal.Parse(people[i + 1]);

                Person person = new Person(name, money);

                peopleCollection.Add(person);
            }
        }
    }
}
