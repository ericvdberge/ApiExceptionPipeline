# ApiExceptionPipeline
## Introduction<br>
This package lets you  throw exceptions anywhere in your code. There is then a middleware that catches the exception and transforms the exception into a json response. 
> The response matches the [RFC7807 standard](https://www.rfc-editor.org/rfc/rfc7807)

> **Warning** : This package is created for .NET 6 WebApi projects **only**

## Requirements
Create a C# WebApi project using the  [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
```shell
dotnet new webapi --name <NAME_OF_PROJECT>
```

## Installation
You can add this nuget package by using the [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

```shell
dotnet add package ApiExceptionPipeline
```
## Configuration
In order to use the package, we need to configure the .NET 6 WebApi project first. You can do that by following these steps:
### Configure Middleware
The system needs to catch the exceptions that are thrown in the code. In order to do that, we need a middleware. You can add it by adding the line commented in the code block below.<br>
**Option 1**
```c#
var app = builder.Build();
app.UseCustomExceptionPipeline(); //add this line
```
**Option 2**<br>
There is an additional constructor overload for the `UseCustomExceptionPipeline` extension.
```c#
var app = builder.Build();
//get exception options from appsettings.json
ExceptionOptions options = new();
configuration.GetSection("ExceptionOptions")
    .Bind(options);
//use the exception options to pass into the exception pipeline
app.UseCustomExceptionPipeline(options);
```
The `TypeBaseUrl` is the base url to your website where you can list the exception descriptions / solutions. This is used to form the exception contract as the response later in this file.
```json
"ExceptionOptions": {
    "TypeBaseUrl": "https://baseurl.nl/exceptions"
}
```
### Configure Exceptions
You can already start throwing default exceptions, but to get more information out of your exceptions, you may want to add custom exceptions or default exceptions provided by our package.<br>

I created a way to keep your code abstract, so you can delete our package when you don't need it. You can simply make your own implementation and dependency inject it within the same interface.
**Create an interface for your exception speficication**, where you can specify custom exceptions. Please inherit from the IException interface, so you will have the default exceptions as well. An example can be found below:
```c#
// this interface specifies which custom exceptions you can throw in your code. You can remove our package and make your own implementation, while keeping this interface.
public interface IExceptionService: IException
{
    public BaseException CustomException(string detail);
}
```
You want to **inherit from the IException interface**, because it contains the default functions like:
- BadRequest
- UnAuthorized
- Forbidden
- NotFound
- MethodNotAllowed
- RequestTimedOut

Now, we need to create the implementation:
```c#
// inherit from the DefaultException class, so you can call the default functions. Also inherit from the IExceptionService interface to make the implementation loosly coupled.
public class ExceptionService : DefaultException, IExceptionService
{
    // add the implementation for the custom exception you specified in the IExceptionService interface
    public BaseException CustomException(string detail)
    {
        return new() // this baseException class is created from the RFC7807 standard
        {
            Type = "/customException",
            Title = nameof(CustomException),
            Status = (int)HttpStatusCode.BadRequest,
            Detail = detail,
        };
    }

    // if you don't like my implementation, you can override the default functions by creating an override function.
    public override BaseException BadRequest(string detail)
    {
        return new()
        {
            Type = "/badrequestcustom",
            Title = nameof(BadRequest),
            Status = (int)HttpStatusCode.BadRequest,
            Detail = detail,
        };
    }
}
```
### Use exceptions
By dependeny injecting the IExceptionService interface with the ExceptionService class,
we can now start using all exceptions in the code anywhere you want
```c#
services.AddSingleton<IExceptionService, ExceptionService>();
```
You can use the ExceptionService like the example below:
```c#
[ApiController]
[Route("[controller]")]
public class ExceptionController : ControllerBase
{
    //dependency inject it anywhere
    private readonly IExceptionService _exceptionService;
    public ExceptionController(IExceptionService exception)
    {
        _exceptionService = exception;
    }

    [HttpGet("TryForbiddenException")]
    public Task TryForbiddenException()
    {
        throw _exceptionService.Forbidden(
            "this is forbidden"
        );
    }

    [HttpGet("TryCustomException")]
    public Task TryCustomException()
    {
        throw _exceptionService.CustomException(
            "this is a custom problem"
        );
    }
}

```

## Result
**Curl**
```shell
curl -X 'GET' \
  'https://localhost:7226/Exception/TryBadRequestException' \
  -H 'accept: */*'
```
**Request Url**
```shell
https://localhost:7226/Exception/TryBadRequestException
```
**Response**
```json
{
  "Type": "https://baseurl.nl/exceptions/badrequestcustom",
  "Status": 400,
  "Title": "Bad Request",
  "Detail": "this is a bad request",
  "Instance": "/Exception/TryBadRequestException"
}
```