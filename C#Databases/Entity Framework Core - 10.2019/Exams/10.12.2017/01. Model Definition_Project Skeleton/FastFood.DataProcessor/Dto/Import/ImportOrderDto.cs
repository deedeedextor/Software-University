using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace FastFood.DataProcessor.Dto.Import
{
    [XmlType("Order")]
    public class ImportOrderDto
    {
        [Required]
        [XmlElement(ElementName = "Customer")]
        public string Customer { get; set; }

        [Required]
        [XmlElement(ElementName = "Employee")]
        public string Employee { get; set; }

        [Required]
        [XmlElement(ElementName = "DateTime")]
        public string DateTime { get; set; }

        [Required]
        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }

        [XmlArray("Items")]
        public ImportOrderItemsDto[] Items { get; set; }
    }
}
