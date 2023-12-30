# Operation result boilerplate in C#
This is an operation result pattern boilerplate tailored for use in different scenarios.
## Stats
![build status](https://github.com/trikstor/Datatone.OperationResult/actions/workflows/dotnet.yml/badge.svg)
## What is the operation result pattern?
The operation result pattern gives you an opportunity to indicate unsuccessful outcomes within your code without throwing exception. This pattern is useful when you need to handle unsuccessful outcomes within your code in any other way than throwing an exception and catching it in one place. If you want to have some logic around tackling errors at different levels of your architecture or you build a library which may me used in different kinds of architectures the operation result pattern is probably the best versatile way for interfacing with your library. Also exceptions handilng is an operation system level responsibility thus operations with it are costly. On the other hand, this pattern complicates the code with the result operations.
## How to use it
When you want to return an expected failure from your method like not found or not authorized use operation result but when you need to indicate an unexpected failure throw an exception.
### Successful result
If your method resulted with success return `Result.Success()` or `Result.Success(content)` if you want to return some content. These methods return `Result<Exception>` or `ResultT<YourContentType, Exception>`.
If you use some custom exception use methods `Result.Success<YourExceptionType>()` or `Result.Success<YourContentType, YourExceptionType>(content)`.
### Failure result
If your method resulted unsuccessfully but it is an expected error like the bad request in HTTP then return `Result.Failure()` or `Result.Failure("error message") or `Result.Failure<YourExceptionType>()` in order to return a custom exception.
### Passing result
Use `Result.Pass(currentResult, funcToConvertResultContent, funcToConvertResultException)` in order to pass a different result returned from another method from your method.
```
var newResult = Result.Pass(
    result,
    c => DateTime.Parse(c),
    e => new ProviderException(ProviderErrorTypes.NotFound, e.Message));
```
For more information have a look to a [demo](https://github.com/trikstor/Datatone.OperationResult/tree/master/Datatone.OperationResult.Demo) and [tests](https://github.com/trikstor/Datatone.OperationResult/tree/master/Datatone.OperationResult.Tests).
