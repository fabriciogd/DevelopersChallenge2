using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nibo.Domain.Entity;

namespace Nibo.Persistence.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(c => c.BankId)
                .IsRequired();

            builder.Property(c => c.Date)
                .IsRequired();

            builder.Property(c => c.Type)
                .IsRequired();

            builder.Property(c => c.Amount)
               .IsRequired();

            builder.Property(c => c.Memo)
                .IsRequired();
        }
    }
}
