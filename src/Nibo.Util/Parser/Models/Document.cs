using System.Xml.Serialization;

namespace Nibo.Util.Parser.Models
{
    [XmlRoot(ElementName = "OFX")]
    public class Document
    {
        [XmlElement(ElementName = "BANKMSGSRSV1")]
        public AccountBankInfoRoot AccountBankInfoRoot { get; set; }
    }
}
