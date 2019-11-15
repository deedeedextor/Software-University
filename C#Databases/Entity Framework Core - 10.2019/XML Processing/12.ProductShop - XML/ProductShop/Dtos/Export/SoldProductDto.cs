using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{

    public class SoldProductDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public ExportSoldProductDto[] SoldProducts { get; set; }
    }
}
