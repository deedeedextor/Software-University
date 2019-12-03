﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetClinic.Models
{
    public class Animal
    {
        public int Id { get; set; }

        [Required, StringLength(20), MinLength(3)]
        public string Name { get; set; }

        [Required, StringLength(20), MinLength(3)]
        public string Type { get; set; }
        
        [Required, Range(1, 100)]
        public int Age { get; set; }

        [Required, ForeignKey(nameof(Passport))]
        public string PassportSerialNumber  { get; set; }

        public Passport Passport { get; set; }

        public ICollection<Procedure> Procedures { get; set; } = new HashSet<Procedure>();
    }
}
