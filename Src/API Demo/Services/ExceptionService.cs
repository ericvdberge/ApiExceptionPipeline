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
                Type = "/customException",
                Title = nameof(CustomException),
                Status = (int)HttpStatusCode.BadRequest,
                Detail = detail,
            };
        }

        public override BaseException BadRequest(string detail)
        {
            return new()
            {
                Type = "/badrequestcustom",
                Title = nameof(BadRequest),
                Status = (int)HttpStatusCode.BadRequest,
                Detail = detail,
            };
        }
    }
}
