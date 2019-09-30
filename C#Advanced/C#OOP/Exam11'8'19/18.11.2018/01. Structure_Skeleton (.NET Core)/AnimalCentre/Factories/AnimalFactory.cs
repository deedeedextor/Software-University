using AnimalCentre.Factories.Contracts;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AnimalCentre.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            var animalType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(a => a.Name == type)
                .FirstOrDefault();

            var parameters = new object[]
            {
                name,
                energy,
                happiness,
                procedureTime
            };

            IAnimal animal = null;

            try
            {
                animal = (IAnimal)Activator.CreateInstance(animalType, parameters);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.InnerException.Message);
            }

            return animal;
        }
    }
}
