using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly List<IAstronaut> astronautsRepository;

        public AstronautRepository()
        {
            this.astronautsRepository = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models
            => this.astronautsRepository.AsReadOnly();

        public void Add(IAstronaut model)
        {
            this.astronautsRepository.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            return this.astronautsRepository.FirstOrDefault(a => a.Name == name);
        }

        public bool Remove(IAstronaut model)
        {
            return this.astronautsRepository.Remove(model);
        }
    }
}
