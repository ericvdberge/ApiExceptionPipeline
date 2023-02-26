using System.Text.RegularExpressions;

namespace ApiExceptionPipelineV2._0.Utils
{
    internal static class TextFormatter
    {
        public static string SeperateCapatalizationText(string input)
        {
            var textParts = Regex.Split(input, @"(?<!^)(?=[A-Z])");
            return string.Join(" ", textParts);
        }
    }
}
