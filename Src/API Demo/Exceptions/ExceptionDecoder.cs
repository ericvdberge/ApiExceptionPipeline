﻿using Microsoft.EntityFrameworkCore;
using System.Net;

namespace API_Demo.Exceptions
{
    public enum ExceptionType
    {
        LostConnectionToServer,
        UnauthorizedException
    }

    public static class ExceptionDecoder
    {
        public static Dictionary<Enum, (string, HttpStatusCode)> CustomExceptions { get; set; } = new Dictionary<Enum, (string, HttpStatusCode)>()
        {
            { ExceptionType.LostConnectionToServer , ("Hello user, you lost connection to the server", HttpStatusCode.InternalServerError) },
            { ExceptionType.UnauthorizedException, ("Hello user, you do not have access", HttpStatusCode.Unauthorized) }
        };

        public static Dictionary<Type, Func<Exception>> CustomExceptionMaps { get; set; } = new Dictionary<Type, Func<Exception>>()
        {
            { typeof(DbUpdateException), () => new LostConnectionException() },
        };
    }
}
