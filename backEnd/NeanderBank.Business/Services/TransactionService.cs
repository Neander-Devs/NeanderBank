using Microsoft.EntityFrameworkCore;
using NeanderBank.Business.Interfaces.Repositories;
using NeanderBank.Business.Interfaces.Services;
using NeanderBank.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeanderBank.Business.Services
{
    public class TransactionService : BaseService, ITransactionService
    {
        private readonly ITransactionRepository _repository;
        public TransactionService(IResponseService responseService, ITransactionRepository repository) : base(responseService)
        {
            _repository = repository;
        }
    }
}
