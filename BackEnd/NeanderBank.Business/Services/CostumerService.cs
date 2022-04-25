using Microsoft.EntityFrameworkCore;
using NeanderBank.Business.Interfaces.Repositories;
using NeanderBank.Business.Interfaces.Services;
using NeanderBank.Business.Models;
using NeanderBank.Business.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeanderBank.Business.Services
{
    public class CostumerService : BaseService, ICostumerService
    {
        private readonly ICostumerRepository _repository;
        public CostumerService(IResponseService responseService, ICostumerRepository repository) : base(responseService)
        {
            _repository = repository;
        }

        public async Task<Costumer> GetByCPF(string cpf)
        {
            if (!CPF.isValid(cpf))
            {
                AddError($"CPF inválido! Deve conter apenas números, pode ou não conter '.' e '-'. Valor recebido: {cpf}");
                return null;
            }
            return await _repository.GetByCPF(CPF.Trim(cpf));
        }

        public async Task<Costumer> GetByAccount(string account)
        {
            if (!AccountNumber.isValid(account))
            {
                AddError($"Número da conta inválido! Deve conter apenas números, pode ou não conter '-'. Valor recebido: {account}");
                return null;
            }
            return await _repository.GetByAccount(AccountNumber.Trim(account));
        }

        public async Task<Costumer> AddCostumer(Costumer costumer)
        {
            
        }

        private bool IsValid(Costumer costumer)
        {

        }
    }
}
