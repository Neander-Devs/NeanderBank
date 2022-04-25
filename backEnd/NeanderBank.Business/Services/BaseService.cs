using NeanderBank.Business.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeanderBank.Business.Services
{
    public class BaseService
    {
        private readonly IResponseService _responseService;

        protected BaseService(IResponseService responseService)
        {
            _responseService = responseService;
        }

        protected void AddError(string message)
        {
            _responseService.AddError(message);
        }

        protected void AddError(string[] messages)
        {
            _responseService.AddError(messages);
        }

        protected void AddError(IEnumerable<string> messages)
        {
            _responseService.AddError(messages);
        }

        protected bool HasError()
        {
            return _responseService.GetErrors().Any();
        }

        protected List<string> GetErrors()
        {
            return _responseService.GetErrors();
        }
    }
}
