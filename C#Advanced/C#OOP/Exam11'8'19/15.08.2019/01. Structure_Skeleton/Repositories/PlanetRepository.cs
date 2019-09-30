using SpaceStation.Models.Planets;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> planetsRepository;

        public PlanetRepository()
        {
            this.planetsRepository = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models
            => this.planetsRepository.AsReadOnly();

        public void Add(IPlanet model)
        {
            this.planetsRepository.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return this.planetsRepository.FirstOrDefault(a => a.Name == name);
        }

        public bool Remove(IPlanet model)
        {
            return this.planetsRepository.Remove(model);
        }
    }
}
