using ApiExceptionPipelineV2._0.Interfaces;
using System.Net;

namespace ApiExceptionPipelineV2._0.Entities
{
    public class DefaultException : IException
    {
        // StatusCode = 400
        public virtual BaseException BadRequest(string detail)
         => new()
         {
             Type = "/badrequest",
             Title = nameof(BadRequest),
             Status = (int)HttpStatusCode.BadRequest,
             Detail = detail,
         };

        // StatusCode = 401
        public virtual BaseException UnAuthorized(string detail)
        => new()
        {
            Type = "/unauthorized",
            Title = nameof(UnAuthorized),
            Status = (int)HttpStatusCode.Unauthorized,
            Detail = detail,
        };

        // StatusCode = 403
        public virtual BaseException Forbidden(string detail)
        => new()
        {
            Type = "/forbidden",
            Title = nameof(Forbidden),
            Status = (int)HttpStatusCode.Forbidden,
            Detail = detail,
        };

        // StatusCode = 404
        public virtual BaseException NotFound(string detail)
        => new()
        {
            Type = "/notfound",
            Title = nameof(NotFound),
            Status = (int)HttpStatusCode.NotFound,
            Detail = detail,
        };

        // StatusCode = 405
        public virtual BaseException MethodNotAllowed(string detail)
        => new()
        {
            Type = "/methodnotallowed",
            Title = nameof(MethodNotAllowed),
            Status = (int)HttpStatusCode.MethodNotAllowed,
            Detail = detail,
        };

        // StatusCode = 408
        public virtual BaseException RequestTimedOut(string detail)
        => new()
        {
            Type = "/requesttimedout",
            Title = nameof(RequestTimedOut),
            Status = (int)HttpStatusCode.RequestTimeout,
            Detail = detail,
        };
    }
}
