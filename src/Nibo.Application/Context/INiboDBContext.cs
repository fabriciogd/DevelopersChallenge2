using Microsoft.EntityFrameworkCore;
using Nibo.Domain.Entity;

namespace Nibo.Application.Context
{
    public interface INiboDBContext
    {
        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
