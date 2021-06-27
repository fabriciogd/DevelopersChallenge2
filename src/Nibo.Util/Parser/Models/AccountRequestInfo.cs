using System.Xml.Serialization;

namespace Nibo.Util.Parser.Models
{
    [XmlRoot(ElementName = "STMTRS")]
    public class AccountRequestInfo
    {
        [XmlElement(ElementName = "BANKACCTFROM")]
        public AccountData AccountData { get; set; }

        [XmlElement(ElementName = "BANKTRANLIST")]
        public BankTransaction BankTransaction { get; set; }
    }
}