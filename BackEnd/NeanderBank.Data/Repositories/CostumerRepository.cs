﻿using NeanderBank.Business.Models;
using NeanderBank.Data.Context;
using NeanderBank.Data.Repositories;
using NeanderBank.Business.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NeanderBank.Data.Repositories
{
    public class CostumerRepository : Repository<Costumer>, ICostumerRepository
    {
        public CostumerRepository(NeanderBankContext db) : base(db)
        {
            
        }

        public async Task<Costumer> GetByCPF(string cpf)
        {
            return await DbSet.AsNoTracking()
                .Include(c => c.Accounts)
                .Where(c => cpf.Equals(c.CPF))
                .FirstOrDefaultAsync();
        }

        public async Task<Costumer> GetByAccount(string account)
        {
            return await DbSet.AsNoTracking()
                .Include(c => c.Accounts)
                .Where(c => c.Accounts.Any(a => account.Equals(a.Number)))
                .FirstOrDefaultAsync();
        }
    }
}