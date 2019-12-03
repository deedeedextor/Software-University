using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetClinic.DataProcessor.Dtos.Import
{
    public class ImportAnimalAidDto
    {
        [Required, StringLength(30), MinLength(3)]
        public string Name { get; set; }

        [Required, Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
