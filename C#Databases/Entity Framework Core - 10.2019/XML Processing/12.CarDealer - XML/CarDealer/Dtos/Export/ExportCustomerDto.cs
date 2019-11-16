using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    [XmlType("customer")]
    public class ExportCustomerDto
    {
        [XmlAttribute(AttributeName = "full-name")]
        public string FullName { get; set; }

        [XmlAttribute(AttributeName = "bought-cars")]
        public int BoughtCars { get; set; }

        [XmlAttribute(AttributeName = "spent-money")]
        public decimal SpendMoney { get; set; }
    }
}
