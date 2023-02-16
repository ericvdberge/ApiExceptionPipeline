using ApiExceptionPipelineV2._0.Entities;
using ApiExceptionPipelineV2._0.Interfaces;
using ApiExceptionPipelineV2._0.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace ApiExceptionPipelineV2._0.Services
{
    internal class ExceptionService
    {
        private readonly HttpContext _context;

        public readonly Dictionary<Enum, (string, HttpStatusCode)> ExceptionDecoder;
        internal ExceptionService(HttpContext context, Dictionary<Enum, (string, HttpStatusCode)> exceptionDecoder)
        {
            _context = context;
            ExceptionDecoder = exceptionDecoder;
        }

        internal IException CreateResponseObject(Exception exception, string instance)
        {
            _context!.Response.ContentType = "application/json";
            
            BaseException? defaultException = exception as BaseException;

            switch(defaultException)
            {
                case not null:
                    return new ExceptionViewModel()
                    {
                        Type = defaultException.Type,
                        Title = defaultException.Title,
                        Status = defaultException.Status,
                        Detail = defaultException.Detail,
                        Instance = instance,
                    };
                case null:
                    return new ExceptionViewModel()
                    {
                        Type = "__blank__",
                        Title = "Unknown",
                        Status = (int)HttpStatusCode.InternalServerError,
                        Detail = "Unknown",
                        Instance = instance
                    };
            }

        }
    }
}
