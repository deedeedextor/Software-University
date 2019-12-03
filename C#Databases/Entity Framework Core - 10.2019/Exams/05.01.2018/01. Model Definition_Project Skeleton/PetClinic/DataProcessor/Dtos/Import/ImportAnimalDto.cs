using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.DataProcessor.Dtos.Import
{
    public class ImportAnimalDto
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int Age { get; set; }

        public ImportPassportDto Passport { get; set; }
    }
}
