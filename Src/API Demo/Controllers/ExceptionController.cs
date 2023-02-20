using API_Demo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExceptionController : ControllerBase
    {
        private readonly IExceptionService _exceptionService;
        public ExceptionController(IExceptionService exception)
        {
            _exceptionService = exception;
        }

        [HttpGet("TryNotImplementedException")]
        public Task TrySystemException()
        {
            throw new NotImplementedException();
        }

        [HttpGet("TryBadRequestException")]
        public Task TryBadRequestException()
        {
            throw _exceptionService.BadRequest(
                "this is a bad request"
            );
        }

        [HttpGet("TryForbiddenException")]
        public Task TryForbiddenException()
        {
            throw _exceptionService.Forbidden(
                "this is forbidden"
            );
        }

        [HttpGet("TryCustomException")]
        public Task TryCustomException()
        {
            throw _exceptionService.CustomException(
                "this is a custom problem"
            );
        }
    }
}