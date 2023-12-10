namespace Datatone.OperationResult;

public interface IResult
{
    bool IsSuccess { get; }
    bool IsError { get; }
    string? ErrorMessage { get; }

    void EnsureSuccess();
}
