using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("partId")]
    public class ImportPartsDto
    {
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
    }
}