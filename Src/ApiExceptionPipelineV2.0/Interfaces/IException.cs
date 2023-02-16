using System.Net;

namespace ApiExceptionPipelineV2._0.Interfaces
{
    internal interface IException
    {
        public string Type { get; init; }
        public string Title { get; init; }
        public int Status { get; init; }
        public string Detail { get; init; }
        public string Instance { get; init; }
    }
}
