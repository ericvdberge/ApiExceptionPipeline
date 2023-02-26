using ApiExceptionPipelineV2._0.Entities;
using ApiExceptionPipelineV2._0.Middleware;
using Microsoft.AspNetCore.Builder;

namespace ApiExceptionPipelineV2._0.Extensions
{
    public static class ExceptionPipelineExtensions
    {
        // a constructor without options
        public static IApplicationBuilder UseCustomExceptionPipeline(
            this IApplicationBuilder builder
        )
        {
            return builder.UseMiddleware<ExceptionPipelineMiddleware>();
        }

        // a constructor with options
        public static IApplicationBuilder UseCustomExceptionPipeline(
            this IApplicationBuilder builder,
            ExceptionOptions? options
        )
        {
            return builder.UseMiddleware<ExceptionPipelineMiddleware>(options);
        } 
    }
}
