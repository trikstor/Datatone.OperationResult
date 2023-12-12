using Datatone.OperationResult.Exceptions;
using NUnit.Framework;
using System;

namespace Datatone.OperationResult.Tests;

[TestFixture]
internal sealed class PassResultTests
{
    [Test]
    public void PassResult_PassedResultIsCorrect()
    {
        var expectedDateTime = new DateTime(2023, 12, 12);
        var expectedResult = Result.Success<DateTime, ProviderException>(expectedDateTime);

        var result = Result.Success<string, HttpException>(expectedDateTime.ToString());
        var actualResult = Result.Pass(
            result,
            c => DateTime.Parse(c),
            e => new ProviderException(ProviderErrorTypes.NotFound, e.Message));

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
