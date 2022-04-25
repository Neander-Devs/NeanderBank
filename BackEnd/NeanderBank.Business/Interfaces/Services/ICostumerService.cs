using NeanderBank.Business.Models;
using System;
using System.Threading.Tasks;

namespace NeanderBank.Business.Interfaces.Services
{
    public interface ICostumerService
    {
        Task<Costumer> GetByCPF(string cpf);
        Task<Costumer> GetByAccount(string account);
    }
}
