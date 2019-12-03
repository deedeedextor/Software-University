using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PetClinic.DataProcessor.Dtos.Import
{
    [XmlType("Vet")]
    public class ImportVetDto
    {
        public string Name { get; set; }

        public string Profession { get; set; }

        public int Age { get; set; }

        public string PhoneNumber { get; set; }
    }
}
