using Microsoft.EntityFrameworkCore;
using NeanderBank.Business.Models;

namespace NeanderBank.Data.Context
{
    public class NeanderBankContext : DbContext
    {
        public NeanderBankContext(DbContextOptions<NeanderBankContext> options)
            : base(options)
        {
        }

        public DbSet<Costumer> Costumers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NeanderBankContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
