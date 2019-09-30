using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Models.Entities
{
    public class Hotel : IHotel
    {
        private const int Capacity = 10;
        private Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
        }

        public IReadOnlyDictionary<string, IAnimal> Animals
            => this.animals;

        public void Accommodate(IAnimal animal)
        {
            if (this.animals.Count == Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (this.animals.Any(e => e.Key == animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }

            this.animals.Add(animal.Name, animal);
        }

        public void Adopt(string animalName, string owner)
        {
            if (!this.animals.Any(e => e.Key == animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            var adoptedAnimal = this.animals
                .Select(e => e.Value)
                .Where(e => e.Name == animalName)
                .FirstOrDefault();

            adoptedAnimal.Owner = owner;
            adoptedAnimal.IsAdopt = true;

            this.animals.Remove(adoptedAnimal.Name);
        }
    }
}
