using API_Demo.Interfaces;
using ApiExceptionPipelineV2._0.Entities;
using System.Net;

namespace API_Demo.Services
{
    public class ExceptionService : DefaultException, IExceptionService
    {
        public BaseException CustomException(string detail)
        {
            return new()
            {
                Type = "https://baseurl.nl/exceptions/customException",
                Title = nameof(CustomException),
                Status = (int)HttpStatusCode.BadRequest,
                Detail = detail,
            };
        }
    }
}
