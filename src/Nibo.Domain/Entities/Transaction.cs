using Nibo.Domain.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nibo.Domain.Entity
{
    [Table("Transactions")]
    public class Transaction: Poco
    {
        public Transaction()
        {

        }

        public int BankId { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; }

        public decimal Amount { get; set; }

        public string Memo { get; set; }
    }
}
