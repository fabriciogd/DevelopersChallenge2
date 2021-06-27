using System;
using System.Xml.Serialization;

namespace Nibo.Util.Parser.Models
{
    [XmlRoot(ElementName = "STMTTRN")]
    public class TransactionInfo
    {
        [XmlElement(ElementName = "TRNTYPE")]
        public string Type { get; set; }

        [XmlElement(ElementName = "DTPOSTED")]
        public string DatePosted { get; set; }

        public DateTime Date => DateParser.Parse(DatePosted);

        [XmlElement(ElementName = "TRNAMT")]
        public string Ammount { get; set; }

        [XmlElement(ElementName = "MEMO")]
        public string Memo { get; set; }
    }
}