using Microsoft.EntityFrameworkCore;
using Nibo.Application.Context;
using System.Transactions;

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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NiboDBContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
