using Nibo.Application.Context;
using Nibo.Domain.Entity;
using Nibo.Domain.Interfaces;

namespace Nibo.Persistence.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(INiboDBContext context) : base(context) { }
    }
}
