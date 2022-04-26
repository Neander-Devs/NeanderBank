using NeanderBank.Business.Models;
using NeanderBank.Data.Context;
using NeanderBank.Data.Repositories;
using NeanderBank.Business.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NeanderBank.Data.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(NeanderBankContext db) : base(db)
        {
            
        }

        public async Task<Account> GetActiveById(int id, bool track = false)
        {
            return await (track ? DbSet.AsTracking() : DbSet.AsNoTracking())
                .Include(a => a.Owner)
                .Where(a => id.Equals(a.Id) && a.IsActive)
                .FirstOrDefaultAsync();
        }

        public async Task<Account> GetActiveByAccountNumber(string accountNumber)
        {
            return await DbSet.AsNoTracking()
                .Include(a => a.Owner)
                .Where(a => accountNumber.Equals(a.Number) && a.IsActive)
                .FirstOrDefaultAsync();
        }
    }
}