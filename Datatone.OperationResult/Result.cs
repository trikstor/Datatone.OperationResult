namespace Datatone.OperationResult
{
    public static class Result
    {
        public static SuccessResultT<TContent> Success<TContent>(TContent content, string message)
        {
            return new SuccessResultT<TContent>(content, message);
        }

        public static SuccessResultT<TContent> Success<TContent>(TContent content)
        {
            return new SuccessResultT<TContent>(content, null);
        }

        public static SuccessResult Success()
        {
            return new SuccessResult();
        }

        public static SuccessResult Success(string message)
        {
            return new SuccessResult(message);
        }

        public static ErrorResult<TException> Fault<TException>(TException exception)
            where TException : Exception
        {
            return new ErrorResult<TException>(exception);
        }

        public static ErrorResult<Exception> Fault(string errorMessage)
        {
            return new ErrorResult<Exception>(new Exception(errorMessage));
        }

        public static ErrorResult<UnifiedException<TErrorType>> Fault<TErrorType>(TErrorType errorType, string errorMessage)
            where TErrorType : Enum
        {
            return new ErrorResult<UnifiedException<TErrorType>>(new UnifiedException<TErrorType>(errorType, errorMessage));
        }
    }
}
