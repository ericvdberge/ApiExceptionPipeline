using System.Net;

namespace ApiExceptionPipelineV2._0.Interfaces
{
    public interface IBaseException
    {
        public string Type { get; init; }
        public string Title { get; init; }
        public int Status { get; init; }
        public string Detail { get; init; }
        public string Instance { get; init; }
    }
}
