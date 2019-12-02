using System.Xml.Serialization;

namespace FastFood.DataProcessor.Dto.Export
{
    [XmlType("MostPopularItem")]
    public class ExportMostPopularItemDto
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "TotalMade")]
        public decimal TotalMade { get; set; }

        [XmlElement(ElementName = "TimesSold")]
        public int TimesSold { get; set; }
    }
}