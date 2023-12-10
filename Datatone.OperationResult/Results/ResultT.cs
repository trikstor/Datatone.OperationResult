namespace Datatone.OperationResult.Results;

public class ResultT<TContent, TException> : Result<TException> where TException : Exception
{
    public TContent? Content { get; }

    public ResultT(TContent content)
    {
        Content = content;
    }

    public ResultT(TException exception) : base(exception)
    {
    }

    public override string? ToString()
    {
        return IsSuccess ? $"Success: [{(Content is IEnumerable<object> collection ? string.Join(",\n", collection) : Content)}]" : $"Failure: [{ErrorMessage}]";
    }
}