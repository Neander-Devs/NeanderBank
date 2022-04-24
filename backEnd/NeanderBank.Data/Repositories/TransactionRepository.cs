using NeanderBank.Business.Models;
using NeanderBank.Data.Context;
using NeanderBank.Data.Repositories;
using NeanderBank.Business.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace NeanderBank.Data.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(NeanderBankContext db) : base(db)
        {
            
        }
    }
}