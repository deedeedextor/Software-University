using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Prisoner")]
    public class ExportPrisonerByMailDto
    {
        [XmlElement(ElementName = "Id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "IncarcerationDate")]
        public string IncarcerationDate { get; set; }
        
        [XmlArray("EncryptedMessages")]
        public ExportMailDto[] EncryptedMessages { get; set; }
    }
}
