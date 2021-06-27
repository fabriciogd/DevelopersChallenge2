using System.Collections.Generic;
using System.Xml.Serialization;

namespace Nibo.Util.Parser.Models
{
    [XmlRoot(ElementName = "BANKTRANLIST")]
    public class BankTransaction
    {
        [XmlElement(ElementName = "DTSTART")]
        public string DateStart { get; set; }

        [XmlElement(ElementName = "DTEND")]
        public string DateEnd { get; set; }

        [XmlElement(ElementName = "STMTTRN")]
        public List<TransactionInfo> Transactions { get; set; }
    }
}