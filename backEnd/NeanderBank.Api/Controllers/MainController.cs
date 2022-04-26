using Microsoft.AspNetCore.Mvc;
using NeanderBank.Business.Interfaces.Services;
using System.Linq;

namespace NeanderBank.Api.Controllers
{
    public abstract class MainController : ControllerBase
    {
        protected readonly IResponseService _responseService;

        protected MainController(IResponseService responseService)
        {
            _responseService = responseService;
        }

        protected bool HasError()
        {
            return _responseService.HasError();
        }

        protected ActionResult CustomResponse(object result = null, string customMessage = null)
        {
            if (!HasError())
            {
                if (!string.IsNullOrEmpty(customMessage))
                {
                    return Ok(new
                    {
                        Success = true,
                        CustomMessage = customMessage,
                        Data = result
                    });
                }

                return Ok(new
                {
                    Success = true,
                    Data = result
                });
            }

            return BadRequest(new
            {
                Success = false,
                Errors = _responseService.GetErrors().Select(n => n)
            });
        }

        protected void AddError(string error)
        {
            _responseService.AddError(error);
        }
    }
}
