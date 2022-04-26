using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NeanderBank.Business.Interfaces.Repositories;
using NeanderBank.Business.Interfaces.Services;
using NeanderBank.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeanderBank.Api.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        public AccountController(IMapper mapper, IResponseService responseService, IAccountService accountService) : base(responseService)
        {
            _mapper = mapper;
            _accountService = accountService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Account>> GetById(int id)
        {
            return CustomResponse(await _accountService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount([FromForm] AccountDTO account)
        {
            if (account == null)
            {
                AddError("Objeto da conta está nulo.");
                return CustomResponse(account);
            }

            var _account = _mapper.Map<Account>(account);

            return CustomResponse(await _accountService.AddAccount(_account));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Costumer>> PutAccount(int id, [FromForm] AccountDTO account)
        {
            if(account.Id != id)
            {
                _responseService.DivergentId(id, account.Id);
                return CustomResponse(account);
            }
            if (account == null)
            {
                AddError("Objeto da conta está nulo.");
                return CustomResponse(account);
            }

            var _account = _mapper.Map<Account>(account);

            return CustomResponse(await _accountService.UpdateAccount(_account));
        }
    }
}
