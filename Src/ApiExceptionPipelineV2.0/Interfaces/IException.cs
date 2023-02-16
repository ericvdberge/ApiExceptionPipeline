using ApiExceptionPipelineV2._0.Entities;

namespace ApiExceptionPipelineV2._0.Interfaces
{
    public interface IException
    {
        public BaseException BadRequest(string title, string detail);
        public BaseException UnAuthorized(string title, string detail);
        public BaseException Forbidden(string title, string detail);
        public BaseException NotFound(string title, string detail);
        public BaseException MethodNotAllowed(string title, string detail);
        public BaseException RequestTimedOut(string title, string detail);
    }
}
