using NeanderBank.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeanderBank.Business.Interfaces.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account> GetActiveById(int id, bool track = false);
        Task<Account> GetActiveByAccountNumber(string accountNumber);
    }
}
