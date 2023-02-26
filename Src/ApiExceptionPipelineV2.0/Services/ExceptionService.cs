using ApiExceptionPipelineV2._0.Entities;
using ApiExceptionPipelineV2._0.Interfaces;
using ApiExceptionPipelineV2._0.ViewModels;
using System.Net;

namespace ApiExceptionPipelineV2._0.Services
{
    internal class ExceptionService
    {
        internal IBaseException CreateResponseObject(Exception exception, string instance, string typeBaseUrl)
        {
            IBaseException? defaultException = exception as BaseException;

            switch(defaultException)
            {
                case not null:
                    return new ExceptionViewModel()
                    {
                        Type = $"{typeBaseUrl}{defaultException.Type}",
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
