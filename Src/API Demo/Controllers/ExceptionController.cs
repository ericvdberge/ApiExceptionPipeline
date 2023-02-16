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

        [HttpGet("TryStandardException")]
        public Task TryStandardException()
        {
            throw _exception.BadRequest(
                "test error", 
                "this is the detail"
            );
        }
    }
}