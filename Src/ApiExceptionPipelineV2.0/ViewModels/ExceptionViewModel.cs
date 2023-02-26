using ApiExceptionPipelineV2._0.Interfaces;
using ApiExceptionPipelineV2._0.Utils;

namespace ApiExceptionPipelineV2._0.ViewModels
{
    internal class ExceptionViewModel : IBaseException
    {
        public string Type { get; init; } = string.Empty;
        public int Status { get; init; }

        private string title = string.Empty;
        public string Title
        {
            get
            {
                return title;
            }
            init
            {
                title = TextFormatter.SeperateCapatalizationText(value);
            }
        }
        public string Detail { get; init; } = string.Empty; 
        public string Instance { get; init; } = string.Empty; 
    }
}
