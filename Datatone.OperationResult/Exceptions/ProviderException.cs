
namespace Datatone.OperationResult.Exceptions;

public class ProviderException : UnifiedException<ProviderErrorTypes>
{
    public ProviderException(ProviderErrorTypes errorType, string Message) : base(errorType, Message)
    {
    }

    public ProviderException(ProviderErrorTypes errorType, Exception exception) : base(errorType, exception)
    {
    }
}
