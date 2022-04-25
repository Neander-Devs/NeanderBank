using NeanderBank.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeanderBank.Business.Interfaces.Repositories
{
    public interface ICostumerRepository : IRepository<Costumer>
    {
        Task<Costumer> GetByCPF(string cpf);
        Task<Costumer> GetByAccount(string account);
    }
}
