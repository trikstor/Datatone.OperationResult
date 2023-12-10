using Datatone.OperationResult.Results;
namespace Datatone.OperationResult
{
    public static class Result
    {
        public static Result<TExException> Success<TExException>() where TExException : Exception
        {
            return new Result<TExException>();
        }

        public static Result<TExException> Fault<TExException>(TExException exception) where TExException : Exception
        {
            return new Result<TExException>(exception);
        }

        public static Result<Exception> Fault(string errorMessage)
        {
            return new Result<Exception>(new Exception(errorMessage));
        }

        public static Result<UnifiedException<TErrorType>> Fault<TErrorType>(TErrorType errorType, string errorMessage)
            where TErrorType : Enum
        {
            return new Result<UnifiedException<TErrorType>>(new UnifiedException<TErrorType>(errorType, errorMessage));
        }

        public static ResultT<TExContent, TExException> Success<TExContent, TExException>(TExContent content) where TExException : Exception
        {
            return new ResultT<TExContent, TExException>(content);
        }

        public static ResultT<TExContent, TExException> Fault<TExContent, TExException>(TExException exception) where TExException : Exception
        {
            return new ResultT<TExContent, TExException>(exception);
        }

        public static ResultT<TExContent, Exception> Fault<TExContent>(string errorMessage)
        {
            return new ResultT<TExContent, Exception>(new Exception(errorMessage));
        }

        public static ResultT<TExContent, UnifiedException<TErrorType>> Fault<TExContent, TErrorType>(TErrorType errorType, string errorMessage)
            where TErrorType : Enum
        {
            return new ResultT<TExContent, UnifiedException<TErrorType>>(new UnifiedException<TErrorType>(errorType, errorMessage));
        }

        public static ResultT<TOutContent, TOutException> Pass<TOutContent, TOutException, TInContent, TInException>(
            ResultT<TInContent, TInException> inResult, 
            Func<TInContent, TOutContent> contentConvertFunc,
            Func<TInException, TOutException> exceptionConvertFunc)
            where TInException : Exception
            where TOutException : Exception
        {
            return inResult.IsSuccess ?
                new ResultT<TOutContent, TOutException>(contentConvertFunc(inResult.Content!)) :
                new ResultT<TOutContent, TOutException>(exceptionConvertFunc(inResult.Exception!));
        }
    }
}
