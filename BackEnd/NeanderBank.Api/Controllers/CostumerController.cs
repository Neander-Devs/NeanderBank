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
    [Route("api/costumer")]
    public class CostumerController : MainController
    {
        private readonly IMapper _mapper;
        private readonly ICostumerService _costumerService;
        private readonly ICostumerRepository _costumerRepository;
        public CostumerController(IMapper mapper, IResponseService responseService, ICostumerService costumerService, ICostumerRepository costumerRepository) : base(responseService)
        {
            _mapper = mapper;
            _costumerService = costumerService;
            _costumerRepository = costumerRepository;
        }

        [HttpGet("cpf")]
        public async Task<ActionResult<Costumer>> GetByCPF(string cpf)
        {
            return CustomResponse(await _costumerService.GetByCPF(cpf));
        }

        [HttpGet("account")]
        public async Task<ActionResult<Costumer>> GetByAccount(string account)
        {
            return CustomResponse(await _costumerService.GetByAccount(account));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Costumer>> GetById(int id)
        {
            return CustomResponse(await _costumerService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Costumer>> PostCostumer([FromForm] CostumerDTO costumer)
        {
            if (costumer == null)
            {
                AddError("Objeto do cliente está nulo.");
                return CustomResponse(costumer);
            }

            var _costumer = _mapper.Map<Costumer>(costumer);

            return CustomResponse(await _costumerService.AddCostumer(_costumer));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Costumer>> PutCostumer(int id, [FromForm] CostumerDTO costumer)
        {
            if(costumer.Id != id)
            {
                _responseService.DivergentId(id, costumer.Id);
                return CustomResponse(costumer);
            }
            if (costumer == null)
            {
                AddError("Objeto do cliente está nulo.");
                return CustomResponse(costumer);
            }

            var _costumer = _mapper.Map<Costumer>(costumer);

            return CustomResponse(await _costumerService.UpdateCostumer(_costumer));
        }
    }
}
