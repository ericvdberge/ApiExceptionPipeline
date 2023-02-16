using ApiExceptionPipelineV2._0.Interfaces;

namespace ApiExceptionPipelineV2._0.ViewModels
{
    internal class ExceptionViewModel : IBaseException
    {
        public string Type { get; init; } = string.Empty;
        public int Status { get; init; }
        public string Title { get; init; } = string.Empty;
        public string Detail { get; init; } = string.Empty; 
        public string Instance { get; init; } = string.Empty; 
    }
}
