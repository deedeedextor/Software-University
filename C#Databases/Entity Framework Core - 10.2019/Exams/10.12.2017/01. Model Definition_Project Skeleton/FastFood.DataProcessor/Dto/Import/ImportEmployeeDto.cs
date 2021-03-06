﻿namespace FastFood.DataProcessor.Dto.Import
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ImportEmployeeDto
    {
        [Required, StringLength(30), MinLength(3)]
        public string Name { get; set; }

        [Required, Range(15, 80)]
        public int Age { get; set; }

        [Required, StringLength(30), MinLength(3)]
        public string Position { get; set; }
    }
}
