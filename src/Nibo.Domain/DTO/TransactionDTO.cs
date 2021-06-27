using System;

namespace Nibo.Domain.DTO
{
    public class TransactionDTO
    {
        public int Id { get; set; }

        public int BankId { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; }

        public decimal Amount { get; set; }

        public string Memo { get; set; }
    }
}
