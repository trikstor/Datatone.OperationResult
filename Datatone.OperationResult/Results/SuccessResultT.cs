namespace Datatone.OperationResult;

public record struct SuccessResultT<TContent>(TContent Content, string? Message) : IResult
{
    public bool IsSuccess => true;
    public bool IsError => false;

    public void EnsureSuccess()
    {
    }
}
