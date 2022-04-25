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

        public async Task<Costumer> GetById(int id)
        {
            return await _repository.GetActiveById(id);
        }

        public async Task<Costumer> AddCostumer(Costumer costumer)
        {
            if (!IsValid(costumer, true)) return null;
            costumer.CPF = CPF.Trim(costumer.CPF);
            costumer.CEP = CEP.Trim(costumer.CEP);

            return await _repository.Add(costumer);
        }

        public async Task<Costumer> UpdateCostumer(Costumer costumer)
        {
            var oldCostumer = await _repository.GetByIdNoTracking(costumer.Id);
            if (oldCostumer == null)
            {
                AddError("Cliente não encontrado!");
                return costumer;
            }

            if (!IsValid(costumer, false)) return null;

            costumer.CPF = CPF.Trim(costumer.CPF);
            costumer.CEP = CEP.Trim(costumer.CEP);

            if (HasError()) return costumer;

            return await _repository.Update(costumer);
        }

        private bool IsValid(Costumer costumer, bool isAdding)
        {
            string[] nullValues = costumer.GetNullValues(nameof(costumer.Accounts));
            if (nullValues.Any())
                _responseService.NullValue(nullValues);

            string[] truncatedStrings = costumer.GetTruncatedStrings();
            if (truncatedStrings.Any())
                _responseService.TruncatedString(truncatedStrings);

            if (isAdding)
            {
                var foundByCPF = _repository.GetByCPF(costumer.CPF);
                if (foundByCPF != null)
                    AddError("Já existe um cliente cadastrado com este CPF!");
            }

            if (costumer.BirthDate > DateTime.Now.AddYears(-18))
                AddError("Obrigatório ser maior de 18 anos para abrir uma conta.");

            if (costumer.BirthDate < DateTime.Now.AddYears(-120))
                AddError("Data de nascimento inválida! Deve ser superior a " + DateTime.Now.AddYears(-120).ToShortDateString());

            if (!CPF.isValid(costumer.CPF))
                AddError($"CPF inválido! Deve conter apenas números (podendo conter '.' e'-'). Valor recebido: {costumer.CPF}");

            if (!costumer.Address.Any(c => char.IsNumber(c)))
                AddError("Endereço deve conter um número!");

            if (!CEP.isValid(costumer.CEP))
                AddError($"CEP inválido! Deve conter apenas números (podendo conter '-'). Valor recebido: {costumer.CEP}");

            return !HasError();
        }
    }
}
