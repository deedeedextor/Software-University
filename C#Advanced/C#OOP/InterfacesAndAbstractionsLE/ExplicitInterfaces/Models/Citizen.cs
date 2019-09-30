namespace ExplicitInterfaces.Models
{
    using ExplicitInterfaces.Interfaces;

    public class Citizen : IResident, IPerson
    {
        public Citizen(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public string Country { get; private set; }

        public int Age { get; private set; }

        string IPerson.GetName()
        {
            return this.Name;
        }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }
    }
}
