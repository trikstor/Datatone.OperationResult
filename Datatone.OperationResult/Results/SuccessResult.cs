using Datatone.OperationResult;

public record struct SuccessResult(string? Message) : IResult
{
    public bool IsSuccess => true;
    public bool IsError => false;

    public void EnsureSuccess()
    {
    }
}