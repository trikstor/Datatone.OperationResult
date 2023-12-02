namespace Datatone.OperationResult;

public class UnifiedException<TErrorType> : Exception
    where TErrorType : Enum
{
    public TErrorType ErrorType { get; }

    public UnifiedException(TErrorType errorType, string Message) : base(Message)
    {
        ErrorType = errorType;
    }

    public UnifiedException(TErrorType errorType, Exception exception) : base(exception.Message)
    {
        ErrorType = errorType;
    }
}
