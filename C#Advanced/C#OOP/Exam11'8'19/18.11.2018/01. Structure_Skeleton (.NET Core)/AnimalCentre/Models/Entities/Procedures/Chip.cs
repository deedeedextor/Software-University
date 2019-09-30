using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Entities.Procedures
{
    public class Chip : Procedure
    {
        private const int Decreaseappiness = 5;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.IsChipped )
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }

            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

            this.AddAnimalProcedure(animal);

            animal.ProcedureTime -= procedureTime;
            animal.Happiness -= Decreaseappiness;
            animal.IsChipped = true;
        }
    }
}
