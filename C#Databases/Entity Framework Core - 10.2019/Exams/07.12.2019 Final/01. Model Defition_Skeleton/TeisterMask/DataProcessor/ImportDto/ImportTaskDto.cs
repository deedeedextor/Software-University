using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Task")]
    public class ImportTaskDto
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "OpenDate")]
        public string OpenDate { get; set; }

        [XmlElement(ElementName = "DueDate")]
        public string DueDate { get; set; }

        [XmlElement(ElementName = "ExecutionType")]
        public string ExecutionType { get; set; }

        [XmlElement(ElementName = "LabelType")]
        public string LabelType { get; set; }
    }
}