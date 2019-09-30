namespace _12.GoogleE
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        private string name;
        private Car car;
        private Company company;
        private List<Pokemon> pokemons;
        private List<Parent> parents;
        private List<Child> children;

        public Person(string name)
        {
            this.Name = name;
            this.pokemons = new List<Pokemon>();
            this.parents = new List<Parent>();
            this.children = new List<Child>();
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public void AssignACompany(Company company)
        {
            this.company = company;
        }

        public void AssignACar(Car car)
        {
            this.car = car;
        }

        public void AddInCollection(Pokemon pokemon)
        {
            this.pokemons.Add(pokemon);
        }

        public void AddInCollection(Parent parent)
        {
            this.parents.Add(parent);
        }

        public void AddInCollection(Child child)
        {
            this.children.Add(child);
        }

        public override string ToString()
        {
            StringBuilder information = new StringBuilder();

            information.AppendLine(this.Name);

            information.AppendLine("Company:");

            if (this.company != null)
            {
                information.AppendLine(this.company.ToString());
            }

            information.AppendLine("Car:");

            if (this.car != null)
            {
                information.AppendLine(this.car.ToString());
            }

            information.AppendLine("Pokemon:");

            if (this.pokemons.Count != 0)
            {
                foreach (Pokemon pokemon in this.pokemons)
                {
                    information.AppendLine(pokemon.ToString());
                }
            }

            information.AppendLine("Parents:");

            if (this.parents.Count != 0)
            {
                foreach (Parent parent in this.parents)
                {
                    information.AppendLine(parent.ToString());
                }
            }

            information.AppendLine("Children:");

            if (this.children.Count != 0)
            {
                foreach (Child child in this.children)
                {
                    information.AppendLine(child.ToString());
                }
            }

            return information.ToString();
        }
    }
}
