using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Entities.Procedures
{
    public abstract class Procedure : IProcedure
    {
        private readonly List<IAnimal> procedureHistory;

        public Procedure()
        {
            this.procedureHistory = new List<IAnimal>();
        }

        public IReadOnlyCollection<IAnimal> ProcedureHistory
            => this.procedureHistory.AsReadOnly();

        public string History()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var animal in this.procedureHistory)
            {
                sb.AppendLine($"{animal}");
            }

            return sb.ToString().TrimEnd();
        }

        public abstract void DoService(IAnimal animal, int procedureTime);

        protected void AddAnimalProcedure(IAnimal animal)
        {
            this.procedureHistory.Add(animal);
        }
    }
}
