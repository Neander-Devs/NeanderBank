using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NeanderBank.Business.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeanderBank.Api.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionsController : MainController
    {
        public TransactionsController(IResponseService responseService) : base(responseService)
        {
            
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new List<string>()
            {
                "transação 01",
                "transação 02",
                "transação 03",
                "transação 04",
                "transação 05",
                "transação 06",
                "transação 07",
                "transação 08",
                "transação 09",
                "transação 10"
            };
        }
    }
}
