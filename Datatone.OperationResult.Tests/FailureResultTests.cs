using Datatone.OperationResult.Exceptions;
using NUnit.Framework;
using System;
using System.Net;

namespace Datatone.OperationResult.Tests;

[TestFixture]
internal sealed class FailureResultTests
{
    [Test]
    public void Failure_ContainCorrectAttributes()
    {
        const string expectedMessage = "Somthing is wrong!";

        var result = Result.Fault(expectedMessage);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.IsError, Is.True);
        Assert.That(result.ErrorMessage, Is.EqualTo(expectedMessage));
    }

    [Test]
    public void Failure_ThrowsException()
    {
        const string expectedMessage = "Somthing is wrong!";

        var result = Result.Fault(expectedMessage);

        Assert.Throws<Exception>(result.EnsureSuccess, expectedMessage);
    }

    [Test]
    public void FailureWithType_ContainsTypeInException()
    {
        const string expectedMessage = "Somthing is wrong!";
        const ConsoleColor expectedType = ConsoleColor.Red;

        var result = Result.Fault(expectedType, expectedMessage);

        Assert.That(result.Exception, Is.Not.Null);
        Assert.That(result.Exception?.ErrorType, Is.EqualTo(expectedType));
    }

    [Test]
    public void Failure_ContainsSpecificException()
    {
        const string expectedMessage = "Somthing is wrong!";
        var expectedException = new HttpException(HttpStatusCode.InternalServerError, expectedMessage);

        var result = Result.Fault(expectedException);

        Assert.That(result.Exception, Is.Not.Null);
        Assert.That(result.Exception, Is.EqualTo(expectedException));
    }
}
