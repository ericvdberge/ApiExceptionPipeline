﻿using ApiExceptionPipelineV2._0.Entities;
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

        private ExceptionService? _exceptionService;

        public ExceptionPipelineMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _exceptionService = new ExceptionService();

            try
            {
                // Call the next delegate/middleware in the pipeline.
                await _next.Invoke(context);
            }
            catch (Exception exception)
            {
                string exceptionInstance = context.Request.Path.Value;
                IBaseException response = _exceptionService.CreateResponseObject(exception, exceptionInstance);
                
                context!.Response.ContentType = "application/json";
                context.Response.StatusCode = Convert.ToInt16(response.Status);

                await context.Response.WriteAsync(
                    // write the base exception as json
                    JsonConvert.SerializeObject(response) 
                );
            }
        }
    }
}