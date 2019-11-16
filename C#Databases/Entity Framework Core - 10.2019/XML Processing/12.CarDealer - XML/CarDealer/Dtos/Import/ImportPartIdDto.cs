using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlRoot(ElementName = "parts")]
    public class ImportPartIdDto
    {
        [XmlAttribute(AttributeName = "partId")]
        public int PartId { get; set; }
    }
}