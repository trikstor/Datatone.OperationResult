using System.Net;

namespace Datatone.OperationResult.Exceptions;

public class HttpException : UnifiedException<HttpStatusCode>
{
    public HttpException(HttpStatusCode errorType, string? Message) : base(errorType, Message ?? string.Empty)
    {
    }

    public HttpException(HttpStatusCode errorType, Exception exception) : base(errorType, exception)
    {
    }
}
