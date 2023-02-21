using ApiExceptionPipelineV2._0.Interfaces;
using System.Net;

namespace ApiExceptionPipelineV2._0.Entities
{
    public class DefaultException: IException
    {
        // StatusCode = 400
        public virtual BaseException BadRequest(string detail)
         => new()
         {
             Type = "https://baseurl.nl/exceptions/badrequest",
             Title = nameof(BadRequest),
             Status = (int)HttpStatusCode.BadRequest,
             Detail = detail,
         };

        // StatusCode = 401
        public virtual BaseException UnAuthorized(string detail)
        => new()
        {
            Type = "https://baseurl.nl/exceptions/unauthorized",
            Title = nameof(UnAuthorized),
            Status = (int)HttpStatusCode.Unauthorized,
            Detail = detail,
        };

        // StatusCode = 403
        public virtual BaseException Forbidden(string detail)
        => new()
        {
            Type = "https://baseurl.nl/exceptions/forbidden",
            Title = nameof(Forbidden),
            Status = (int)HttpStatusCode.Forbidden,
            Detail = detail,
        };

        // StatusCode = 404
        public virtual BaseException NotFound(string detail)
        => new()
        {
            Type = "https://baseurl.nl/exceptions/notfound",
            Title = nameof(NotFound),
            Status = (int)HttpStatusCode.NotFound,
            Detail = detail,
        };

        // StatusCode = 405
        public virtual BaseException MethodNotAllowed(string detail)
        => new()
        {
            Type = "https://baseurl.nl/exceptions/methodnotallowed",
            Title = nameof(MethodNotAllowed),
            Status = (int)HttpStatusCode.MethodNotAllowed,
            Detail = detail,
        };

        // StatusCode = 408
        public virtual BaseException RequestTimedOut(string detail)
        => new()
        {
            Type = "https://baseurl.nl/exceptions/requesttimedout",
            Title = nameof(RequestTimedOut),
            Status = (int)HttpStatusCode.RequestTimeout,
            Detail = detail,
        };
    }
}
