using System.Xml.Serialization;

namespace Nibo.Util.Parser.Models
{
    [XmlRoot(ElementName = "STMTTRNRS")]
    public class AccountRequestInfoRoot
    {
        [XmlElement(ElementName = "STATUS")]
        public Status Status { get; set; }

        [XmlElement(ElementName = "STMTRS")]
        public AccountRequestInfo AccountRequestInfo { get; set; }
    }
}