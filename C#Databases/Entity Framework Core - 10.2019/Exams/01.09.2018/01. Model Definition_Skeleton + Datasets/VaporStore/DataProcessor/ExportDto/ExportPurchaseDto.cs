using System.Xml.Serialization;

namespace VaporStore.DataProcessor.ExportDto
{
    [XmlType("Purchase")]
    public class ExportPurchaseDto
    {
        [XmlElement(ElementName = "Card")]
        public string Card { get; set; }

        [XmlElement(ElementName = "Cvc")]
        public string Cvc { get; set; }

        [XmlElement(ElementName = "Date")]
        public string Date { get; set; }

        [XmlElement(ElementName = "Game")]
        public ExportGameDto Game { get; set; }
    }
}