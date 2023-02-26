using ApiExceptionPipelineV2._0.Entities;
using ApiExceptionPipelineV2._0.Interfaces;

namespace API_Demo.Interfaces
{
    public interface IExceptionService: IException
    {
        public BaseException CustomException(string detail);
    }
}
