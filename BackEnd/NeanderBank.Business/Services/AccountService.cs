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
    public class AccountService : BaseService, IAccountService
    {
        private readonly IAccountRepository _repository;
        private readonly ICostumerService _costumerService;
        public AccountService(IResponseService responseService, IAccountRepository repository, ICostumerService costumerService) : base(responseService)
        {
            _repository = repository;
            _costumerService = costumerService;
        }

        public async Task<Account> GetById(int id)
        {
            return await _repository.GetActiveById(id);
        }

        public async Task<Account> AddAccount(Account account)
        {
            var owner = await _costumerService.GetById(account.OwnerId);
            if(owner == null)
            {
                AddError("Cliente não encontrado para conta!");
                return account;
            }
            account.OwnerId = owner.Id;

            if (!await IsValid(account, true)) return null;

            account.Number = AccountNumber.Trim(account.Number);

            return await _repository.Add(account);
        }

        public async Task<Account> UpdateAccount(Account account)
        {
            var owner = await _costumerService.GetById(account.OwnerId);
            if (owner == null)
            {
                AddError("Cliente não encontrado para conta!");
                return account;
            }
            account.OwnerId = owner.Id;

            if (!await IsValid(account, false)) return null;

            account.Number = AccountNumber.Trim(account.Number);

            return await _repository.Update(account);
        }

        private async Task<bool> IsValid(Account account, bool isAdding)
        {
            string[] nullValues = account.GetNullValues(nameof(account.Transactions), nameof(account.Owner));
            if (nullValues.Any())
                _responseService.NullValue(nullValues);

            account.Number = AccountNumber.Trim(account.Number);

            string[] truncatedStrings = account.GetTruncatedStrings();
            if (truncatedStrings.Any())
                _responseService.TruncatedString(truncatedStrings);

            if (!AccountNumber.isValid(account.Number))
                AddError("Número da conta inválido!");

            if (isAdding)
            {
                var foundByNumber = await _repository.GetActiveByAccountNumber(account.Number);
                if (foundByNumber != null)
                    AddError("Já existe uma conta cadastrada com este número!");
            }

            if(account.Agency.Length != 4 || account.Agency.Any(c => !char.IsNumber(c)))
                AddError("Número de agência deve conter apenas 4 dígitos numéricos!");

            if (account.Password.Length != 8 || account.Password.Any(c => !char.IsNumber(c)))
                AddError("Obrigatório senha com 8 caracteres numéricos!");

            return !HasError();
        }
    }
}
