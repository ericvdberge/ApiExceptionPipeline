using API_Demo.Exceptions;
using ApiExceptionPipelineV2._0.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExceptionController : ControllerBase
    {
        [HttpGet("TryNotImplementedException")]
        public Task TrySystemException()
        {
            throw new NotImplementedException();
        }

        [HttpGet("TryStandardException")]
        public Task TryStandardException()
        {
            throw DefaultException.BadRequest(
                "test error", 
                "this is the detail", 
                "/Exception/TryStandardException"
            );
        }
    }
}