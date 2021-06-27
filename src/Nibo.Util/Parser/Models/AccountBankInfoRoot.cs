using System.Xml.Serialization;

namespace Nibo.Util.Parser.Models
{
    [XmlRoot(ElementName = "BANKMSGSRSV1")]
    public class AccountBankInfoRoot
    {
        [XmlElement(ElementName = "STMTTRNRS")]
        public AccountRequestInfoRoot AccountRequestInfoRoot { get; set; }
    }
}