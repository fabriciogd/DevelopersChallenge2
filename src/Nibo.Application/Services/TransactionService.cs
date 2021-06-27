using Microsoft.AspNetCore.Http;
using Nibo.Application.Context;
using Nibo.Application.Interfaces;
using Nibo.Domain.DTO;
using Nibo.Domain.Entity;
using Nibo.Domain.Interfaces;
using Nibo.Util.Parser;
using Nibo.Util.Parser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibo.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionService(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork)
        {
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TransactionDTO>> GetAllAsync()
        {
            var transactions = await _transactionRepository.GetAllAsync();

            return transactions.Select(t => new TransactionDTO()
            {
                Id = t.Id,
                BankId = t.BankId,
                Date = t.Date,
                Type = t.Type,
                Amount = t.Amount,
                Memo = t.Memo
            });
        }

        public async Task<bool> ImportAsync(IEnumerable<TransactionBank> imports)
        {
            List<Transaction> transactions = new List<Transaction>();

            foreach (var import in imports)
            {
                bool transactionExists = await _transactionRepository.ExistsAsync(
                    a => 
                        a.BankId == import.BankId &&
                        a.Date == import.Date &&
                        a.Type == import.Type &&
                        a.Amount == import.Amount &&
                        a.Memo == import.Memo
                );

                if (!transactionExists)
                {
                    transactions.Add(new Transaction()
                    {
                        BankId = import.BankId,
                        Date = import.Date,
                        Type = import.Type,
                        Amount = import.Amount,
                        Memo = import.Memo
                    });
                }
            }

            await _transactionRepository.AddRangeAsync(transactions);

            await _unitOfWork.SaveChangesAsync();

            return transactions.Count > 0;
        }
    }
}
