using ApiExceptionPipelineV2._0.Entities;
using ApiExceptionPipelineV2._0.Interfaces;
using ApiExceptionPipelineV2._0.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace ApiExceptionPipelineV2._0.Middleware
{
    public class ExceptionPipelineMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ExceptionService? _exceptionService;
        private readonly ExceptionOptions? _options;

        public ExceptionPipelineMiddleware(RequestDelegate next)
        {
            _next = next;
            _exceptionService = new ExceptionService();
        }

        public ExceptionPipelineMiddleware(RequestDelegate next, ExceptionOptions options)
        {
            _next = next;
            _options = options;
            _exceptionService = new ExceptionService();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Call the next delegate/middleware in the pipeline.
                await _next.Invoke(context);
            }
            catch (Exception exception)
            {
                if (_exceptionService is null) return;
                
                string typeBaseUrl = _options?.TypeBaseUrl ?? string.Empty;
                string exceptionInstance = context.Request.Path.Value;
                IBaseException response = _exceptionService.CreateResponseObject(exception, exceptionInstance, typeBaseUrl);
                
                context!.Response.ContentType = "application/json";
                context.Response.StatusCode = Convert.ToInt32(response.Status);

                await context.Response.WriteAsync(
                    // write the base exception as json
                    JsonConvert.SerializeObject(response) 
                );
            }
        }
    }
}