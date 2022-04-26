using NeanderBank.Business.Models;
using System;
using System.Threading.Tasks;

namespace NeanderBank.Business.Interfaces.Services
{
    public interface IAccountService
    {
        Task<Account> GetById(int id);
        Task<Account> AddAccount(Account account);
        Task<Account> UpdateAccount(Account account);
    }
}
