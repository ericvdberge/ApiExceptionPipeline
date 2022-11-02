# ApiExceptionPipeline
## Why?<br>
This package catches all system exceptions and creates a user friendly json response to the user. An example of the response can be seen below:
```json
{
  "StatusCode": 500,
  "Message": "Hello user, you lost connection to the server"
}
```

## How
Throwing an exception somewhere in your C# code will trigger the exception pipeline.
```c#
throw new LostConnectionException();
```

## What to configure?
### 1. Create a decoder file. I used the name `ExceptionDecoder.cs`. The file looks like:
```c#
namespace API_Demo.Exceptions
{
    public enum ExceptionType
    {
        LostConnectionToServer,
    }

    public static class ExceptionDecoder
    {
        public static Dictionary<Enum, (string, HttpStatusCode)> CustomExceptions { get; set; } = new Dictionary<Enum, (string, HttpStatusCode)>()
        {
            { ExceptionType.LostConnectionToServer , ("Hello user, you lost connection to the server", HttpStatusCode.InternalServerError) }
        };

        public static Dictionary<Type, Func<Exception>> CustomExceptionMaps { get; set; } = new Dictionary<Type, Func<Exception>>()
        {
            { typeof(DbUpdateException), () => new LostConnectionException() },
        };
    }
}
```
a) The `ExceptionType` is an enum that contains all of your exception types. Examples could be:
- LostConnectionException
- BadRequestException
- TooLargeFileException<br>

b) The `CustomExceptions` dictionary will connect multiple exception types to its message and http status. This is needed so that the exception pipeline knows what to send as a response to the user.

c) The `CustomExceptionMaps` dictionary maps an exception to another exception. This is meant if you want to map a default system exception to a custom exception. When the key exception will be thrown, we use the custom exception as response.

### 2. Create a custom Exception
An example of a custom exception could be a `LostConnectionException`
```c#
 public class LostConnectionException : BaseException
  {
        public LostConnectionException() : base(ExceptionType.LostConnectionToServer)
        {
        }
  }
```
> :warning: It is important that you inherit your exception class from the `BaseException` class.
You also need to pass the exception type from the `ExceptionDecoder.cs` to the constructor of the BaseException class. By doing this, the pipeline will now where to search in the dictionary with messages and http status codes.

### 3. Register the Exception Pipeline in `Program.cs`
The only thing you have to do in program.cs is adding the `app.UseCustomExceptionPipeline()` function with the 2 dictionaries
```c#
app.UseCustomExceptionPipeline(
    exceptionDecoder: ExceptionDecoder.CustomExceptions,
    exceptionMaps: ExceptionDecoder.CustomExceptionMaps
);
```
