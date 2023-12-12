using NUnit.Framework;
using System;

namespace Datatone.OperationResult.Tests;

[TestFixture]
internal sealed class SuccessResultTests
{
    [Test]
    public void Success_ContainCorrectAttributes()
    {
        var result = Result.Success<Exception>();

        Assert.That(result, Is.Not.Null);
        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.IsError, Is.False);
        Assert.That(result.ErrorMessage, Is.Null);
    }

    [Test]
    public void Success_EnsureDoesntThrow()
    {
        var result = Result.Success<Exception>();

        Assert.DoesNotThrow(result.EnsureSuccess);
    }

    [Test]
    public void SuccessTWithContent_ContainContent()
    {
        var expectedContent = new byte[] { 1, 2, 3 };

        var result = Result.Success<byte[], Exception>(expectedContent);

        Assert.That(result.Content, Is.EqualTo(expectedContent));
    }
}