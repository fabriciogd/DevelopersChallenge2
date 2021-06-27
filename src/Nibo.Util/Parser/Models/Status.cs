using System.Xml.Serialization;

namespace Nibo.Util.Parser.Models
{
    [XmlRoot(ElementName = "STATUS")]
    public class Status
    {
        [XmlElement(ElementName = "CODE")]
        public string Code { get; set; }

        [XmlElement(ElementName = "SEVERITY")]
        public string Severity { get; set; }
    }
}