using System.Xml.Serialization;

namespace Nibo.Util.Parser.Models
{
    [XmlRoot(ElementName = "BANKACCTFROM")]
    public class AccountData
    {
        [XmlElement(ElementName = "BANKID")]
        public string BankId { get; set; }
    }
}