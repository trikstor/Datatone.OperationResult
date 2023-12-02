using NUnit.Framework;
using System;

namespace Datatone.OperationResult.Tests
{
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
            Assert.That(result.Message, Is.EqualTo(expectedMessage));
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
            Assert.That(result.Exception.ErrorType, Is.EqualTo(expectedType));
        }
    }
}
