using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace FastFood.DataProcessor.Dto.Import
{
    [XmlType("Item")]
    public class ImportOrderItemsDto
    {
        [Required]
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Quantity")]
        [Required, Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}