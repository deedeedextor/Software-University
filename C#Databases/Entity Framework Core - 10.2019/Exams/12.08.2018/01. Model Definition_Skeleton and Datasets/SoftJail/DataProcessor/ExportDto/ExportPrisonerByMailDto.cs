namespace SoftJail.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

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
