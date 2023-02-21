﻿using ApiExceptionPipelineV2._0.Middleware;
using Microsoft.AspNetCore.Builder;
using System.Net;

namespace ApiExceptionPipelineV2._0.Extensions
{
    public static class ExceptionPipelineExtensions
    {
        public static IApplicationBuilder UseCustomExceptionPipeline(
            this IApplicationBuilder builder
        ) => 
            builder.UseMiddleware<ExceptionPipelineMiddleware>();
    }
}
