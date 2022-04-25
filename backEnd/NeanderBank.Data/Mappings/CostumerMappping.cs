using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeanderBank.Business.Config;
using NeanderBank.Business.Models;
using System.Collections.Generic;

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
                .HasColumnType($"varchar({AppSettings.StringLengths[typeof(Costumer)][nameof(Costumer.Name)]})");

            builder.Property(d => d.CPF)
                .IsRequired()
                .HasColumnType($"varchar({AppSettings.StringLengths[typeof(Costumer)][nameof(Costumer.CPF)]})");

            builder.Property(d => d.Address)
                .IsRequired()
                .HasColumnType($"varchar({AppSettings.StringLengths[typeof(Costumer)][nameof(Costumer.Address)]})");

            builder.Property(d => d.Neighboorhood)
                .IsRequired()
                .HasColumnType($"varchar({AppSettings.StringLengths[typeof(Costumer)][nameof(Costumer.Neighboorhood)]})");

            builder.Property(d => d.City)
                .IsRequired()
                .HasColumnType($"varchar({AppSettings.StringLengths[typeof(Costumer)][nameof(Costumer.City)]})");

            builder.Property(d => d.State)
                .IsRequired()
                .HasColumnType($"varchar({AppSettings.StringLengths[typeof(Costumer)][nameof(Costumer.State)]})");

            builder.Property(d => d.CEP)
                .IsRequired()
                .HasColumnType($"varchar({AppSettings.StringLengths[typeof(Costumer)][nameof(Costumer.CEP)]})");

            builder.Property(d => d.BirthDate)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(d => d.IsActive)
                .IsRequired()
                .HasDefaultValue(true);
        }
    }
}