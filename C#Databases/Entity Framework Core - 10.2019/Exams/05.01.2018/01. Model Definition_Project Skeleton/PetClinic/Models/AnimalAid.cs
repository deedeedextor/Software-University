using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetClinic.Models
{
    public class AnimalAid
    {
        public int Id { get; set; }

        [Required, StringLength(30), MinLength(3)]
        public string Name { get; set; }

        [Required, Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        public ICollection<ProcedureAnimalAid> AnimalAidProcedures { get; set; } = new HashSet<ProcedureAnimalAid>();
    }
}
