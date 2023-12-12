namespace Datatone.OperationResult;

public interface IResult<TException> where TException : Exception
{
    bool IsSuccess { get; }
    bool IsError { get; }
    string? ErrorMessage { get; }
    public TException? Exception { get; }

    void EnsureSuccess();
}
