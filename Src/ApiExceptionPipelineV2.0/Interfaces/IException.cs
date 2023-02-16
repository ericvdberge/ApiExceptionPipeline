using ApiExceptionPipelineV2._0.Entities;

namespace ApiExceptionPipelineV2._0.Interfaces
{
    public interface IException
    {
        public BaseException BadRequest(string detail);
        public BaseException UnAuthorized(string detail);
        public BaseException Forbidden(string detail);
        public BaseException NotFound(string detail);
        public BaseException MethodNotAllowed(string detail);
        public BaseException RequestTimedOut(string detail);
    }
}
