using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace PetClinic.DataProcessor.Dtos.Import
{
    [XmlType("AnimalAid")]
    public class AnimalAidDto
    {
        [XmlElement("Name")]
        [Required, StringLength(30), MinLength(3)]
        public string Name { get; set; }
    }
}