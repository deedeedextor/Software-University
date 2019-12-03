using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PetClinic.Models
{
    public class Procedure
    {
        public int Id { get; set; }
        
        [Required, ForeignKey(nameof(Animal))]
        public int AnimalId { get; set; }

        public Animal Animal { get; set; }

        [Required, ForeignKey(nameof(Vet))]
        public int VetId { get; set; }

        public Vet Vet { get; set; }

        public ICollection<ProcedureAnimalAid> ProcedureAnimalAids { get; set; } = new HashSet<ProcedureAnimalAid>();

        [NotMapped]
        public decimal Cost { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
    }
}
