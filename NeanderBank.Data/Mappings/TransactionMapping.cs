using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeanderBank.Business.Models;

namespace NeanderBank.Data.Mappings
{
    public class TransactionMapping : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.TransferDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(d => d.Balance)
                .IsRequired();

            builder.Property(d => d.Value)
                .IsRequired();

            builder.Property(d => d.ReceiverAccountId)
                .IsRequired(false);
            builder.Property(d => d.SenderAccountId)
                .IsRequired(false);
        }
    }
}