using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Entities.Procedures
{
    public class DentalCare : Procedure
    {
        private const int AdditionalHappiness = 12;
        private const int AdditionalEnergy = 10;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

            this.AddAnimalProcedure(animal);

            animal.ProcedureTime -= procedureTime;
            animal.Happiness += AdditionalHappiness;
            animal.Energy += AdditionalEnergy;
        }
    }
}
