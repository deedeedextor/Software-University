using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.ImportDto
{
    [XmlType("Purchase")]
    public class ImportPurchaseDto
    {
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "Key")]
        public string Key { get; set; }

        [XmlElement(ElementName = "Card")]
        public string CardNumber { get; set; }

        [XmlElement(ElementName = "Date")]
        public string Date { get; set; }
    }
}
