namespace Datatone.OperationResult.Results;

public class Result<TException> : IResult where TException : Exception
{
    public TException? Exception { get; }
    public bool IsSuccess => Exception == null;
    public bool IsError => Exception != null;
    public string? ErrorMessage => Exception?.Message;

    public Result()
    {
    }

    public Result(TException exception)
    {
        Exception = exception;
    }

    public void EnsureSuccess()
    {
        if (Exception == null) return;
        throw Exception;
    }

    public override string? ToString()
    {
        return IsSuccess ? $"Success" : $"Failure: [{ErrorMessage}]";
    }
}
