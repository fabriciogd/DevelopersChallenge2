using Microsoft.AspNetCore.Http;
using Nibo.Domain.DTO;
using Nibo.Domain.Entity;
using Nibo.Util.Parser.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nibo.Application.Interfaces
{
    public interface ITransactionService
    {
        public Task<bool> ImportAsync(IEnumerable<TransactionBank> imports);

        public Task<IEnumerable<TransactionDTO>> GetAllAsync();
    }
}
