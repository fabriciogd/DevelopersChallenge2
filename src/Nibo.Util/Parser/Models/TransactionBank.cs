using System;

namespace Nibo.Util.Parser.Models
{
    public class TransactionBank
    {
        public int BankId { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; }

        public decimal Amount { get; set; }

        public string Memo { get; set; }
    }
}
