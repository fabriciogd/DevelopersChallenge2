using Microsoft.EntityFrameworkCore;
using Nibo.Application.Context;
using Nibo.Domain.Entity;
using Nibo.Persistence.Configurations;

namespace Nibo.Persistence.Context
{
    public class NiboDBContext : DbContext, INiboDBContext
    {
        public DbSet<Transaction> Transactions { get; set; }

        public NiboDBContext(DbContextOptions<NiboDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
        }
    }
}
