using Datatone.OperationResult.Extensions;

namespace Datatone.OperationResult.Results;

public class ResultT<TContent, TException> : Result<TException> 
    where TException : Exception
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
        return IsSuccess ? $"Success: [{Content.ToHumanReadableString()}]" : $"Failure: [{ErrorMessage}]";
    }

    public override bool Equals(object? obj)
    {
        return obj is ResultT<TContent, TException> t &&
               base.Equals(obj) &&
               EqualityComparer<TContent?>.Default.Equals(Content, t.Content);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Content);
    }
}