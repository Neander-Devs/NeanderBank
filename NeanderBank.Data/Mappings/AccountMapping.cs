using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeanderBank.Business.Models;

namespace NeanderBank.Data.Mappings
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(d => d.Id);
            builder.HasOne(a => a.Owner)
                .WithMany(c => c.Accounts);

            builder.HasMany(a => a.Transactions)
                .WithOne(t => t.SenderAccount);

            builder.Property(d => d.Number)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(d => d.Password)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(d => d.Agency)
                .IsRequired()
                .HasColumnType("varchar(4)");

            builder.Property(d => d.Balance)
                .IsRequired();

            builder.Property(d => d.MaxWithDraw)
                .IsRequired();

            builder.Property(d => d.MaxOverdraft)
                .IsRequired();

            builder.Property(d => d.UsingOverdraft)
                .IsRequired();
        }
    }
}