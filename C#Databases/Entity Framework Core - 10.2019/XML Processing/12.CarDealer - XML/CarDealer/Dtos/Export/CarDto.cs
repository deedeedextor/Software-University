using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    [XmlType("car")]
    public class CarDto
    {
        [XmlAttribute(AttributeName = "make")]
        public string Make { get; set; }

        [XmlAttribute(AttributeName = "model")]
        public string Model { get; set; }

        [XmlAttribute(AttributeName = "travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}