using ApiExceptionPipelineV2._0.Entities;

namespace API_Demo.Exceptions
{
    public class UnAuthorizedException: BaseException
    {
        public UnAuthorizedException(): base(ExceptionType.UnauthorizedException)
        {

        }
    }
}
