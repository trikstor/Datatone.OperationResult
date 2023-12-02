using NUnit.Framework;

namespace Datatone.OperationResult.Tests
{
    [TestFixture]
    internal sealed class SuccessResultTests
    {
        [Test]
        public void Success_ContainCorrectAttributes()
        {
            var result = Result.Success();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.IsError, Is.False);
            Assert.That(result.Message, Is.Null);
        }

        [Test]
        public void Success_EnsureDoesntThrow()
        {
            var result = Result.Success();

            Assert.DoesNotThrow(result.EnsureSuccess);
        }

        [Test]
        public void SuccessWithMessage_ContainMessage()
        {
            const string expectedMessage = "Everything works fine!";

            var result = Result.Success(expectedMessage);

            Assert.That(result.Message, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void SuccessTWithContent_ContainContent()
        {
            var expectedContent = new byte[] { 1, 2, 3 };

            var result = Result.Success(expectedContent);

            Assert.That(result.Content, Is.EqualTo(expectedContent));
        }
    }
}