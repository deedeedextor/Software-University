using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace PetClinic.DataProcessor.Dtos.Import
{
    [XmlType("Procedure")]
    public class ImportProcedureDto
    {
        [XmlElement("Vet")]
        [Required, StringLength(40), MinLength(3)]
        public string Vet { get; set; }

        [XmlElement("Animal")]
        [Required, StringLength(20), MinLength(3)]
        public string Animal { get; set; }

        [XmlElement("DateTime")]
        [Required]
        public string DateTime { get; set; }

        [XmlArray("AnimalAids")]
        public AnimalAidDto[] AnimalAids { get; set; }
    }
}
