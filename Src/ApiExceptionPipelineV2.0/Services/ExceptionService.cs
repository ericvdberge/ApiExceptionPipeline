using ApiExceptionPipelineV2._0.Entities;
using ApiExceptionPipelineV2._0.Interfaces;
using ApiExceptionPipelineV2._0.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace ApiExceptionPipelineV2._0.Services
{
    internal class ExceptionService
    {
        public readonly Dictionary<Enum, (string, HttpStatusCode)> ExceptionDecoder;
        internal ExceptionService(Dictionary<Enum, (string, HttpStatusCode)> exceptionDecoder)
        {
            ExceptionDecoder = exceptionDecoder;
        }

        internal IBaseException CreateResponseObject(Exception exception, string instance)
        {
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
                        Title = exception.GetType().Name.Replace("Exception", ""),
                        Status = (int)HttpStatusCode.InternalServerError,
                        Detail = exception.Message,
                        Instance = instance
                    };
            }

        }
    }
}
