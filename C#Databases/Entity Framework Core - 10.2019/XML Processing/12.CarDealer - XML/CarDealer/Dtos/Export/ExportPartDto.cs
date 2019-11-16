using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    [XmlType("part")]
    public class ExportPartDto
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }


        [XmlAttribute(AttributeName = "price")]
        public decimal Price { get; set; }
    }
}
