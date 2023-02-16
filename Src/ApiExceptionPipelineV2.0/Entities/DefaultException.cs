using ApiExceptionPipelineV2._0.Interfaces;
using System.Net;

namespace ApiExceptionPipelineV2._0.Entities
{
    public class DefaultException: IException
    {
        // StatusCode = 400
        public BaseException BadRequest(string title, string detail)
         => new BaseException()
         {
             Type = "https://baseurl.nl/exceptions/badrequest",
             Title = title,
             Status = (int)HttpStatusCode.BadRequest,
             Detail = detail,
         };

        // StatusCode = 401
        public BaseException UnAuthorized(string title, string detail)
        => new BaseException();

        // StatusCode = 403
        public BaseException Forbidden(string title, string detail)
        => new BaseException();

        // StatusCode = 404
        public BaseException NotFound(string title, string detail)
        => new BaseException();

        // StatusCode = 405
        public BaseException MethodNotAllowed(string title, string detail)
        => new BaseException();

        // StatusCode = 408
        public BaseException RequestTimedOut(string title, string detail)
        => new BaseException();
    }
}
