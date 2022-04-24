using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeanderBank.Business.Models;

namespace NeanderBank.Data.Mappings
{
    public class CostumerMappping : IEntityTypeConfiguration<Costumer>
    {
        public void Configure(EntityTypeBuilder<Costumer> builder)
        {
            builder.HasKey(d => d.Id);
            builder.HasMany(c => c.Accounts)
                .WithOne(a => a.Owner);

            builder.Property(d => d.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(d => d.CPF)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.Property(d => d.Address)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(d => d.Neighboorhood)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(d => d.City)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(d => d.State)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(d => d.CEP)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(d => d.BirthDate)
                .IsRequired()
                .HasColumnType("date");
        }
    }
}