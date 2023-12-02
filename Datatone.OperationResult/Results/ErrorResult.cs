namespace Datatone.OperationResult;

public record struct ErrorResult<TException>(TException Exception) : IResult
    where TException : Exception
{
    public bool IsSuccess => false;
    public bool IsError => true;
    public string? Message => Exception.Message;

    public void EnsureSuccess()
    {
        throw Exception;
    }
}