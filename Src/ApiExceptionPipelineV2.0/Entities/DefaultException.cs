using System.Net;

namespace ApiExceptionPipelineV2._0.Entities
{
    public static class DefaultException
    {
        // StatusCode = 400
        public static BaseException BadRequest(string title, string detail, string instance)
         => new BaseException()
         {
             Type = "https://baseurl.nl/exceptions/badrequest",
             Title = title,
             Status = (int)HttpStatusCode.BadRequest,
             Detail = detail,
             Instance = instance,
         };

        // StatusCode = 401
        public static BaseException UnAuthorized()
        => new BaseException();

        // StatusCode = 403
        public static BaseException Forbidden()
        => new BaseException();

        // StatusCode = 404
        public static BaseException NotFound()
        => new BaseException();

        // StatusCode = 405
        public static BaseException MethodNotAllowed()
        => new BaseException();

        // StatusCode = 408
        public static BaseException RequestTimedOut()
        => new BaseException();
    }
}
