using ApiExceptionPipelineV2._0.Entities;
using ApiExceptionPipelineV2._0.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExceptionController : ControllerBase
    {
        private readonly IException _exception;
        public ExceptionController(IException exception)
        {
            _exception = exception;
        }

        [HttpGet("TryNotImplementedException")]
        public Task TrySystemException()
        {
            throw new NotImplementedException();
        }

        [HttpGet("TryBadRequestException")]
        public Task TryBadRequestException()
        {
            throw _exception.BadRequest(
                "this is a bad request"
            );
        }

        [HttpGet("TryForbiddenException")]
        public Task TryForbiddenException()
        {
            throw _exception.Forbidden(
                "this is forbidden"
            );
        }
    }
}