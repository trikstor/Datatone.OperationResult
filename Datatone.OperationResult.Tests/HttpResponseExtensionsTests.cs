using Datatone.OperationResult.Extensions;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Datatone.OperationResult.Tests;

[TestFixture]
internal sealed class HttpResponseExtensionsTests
{
    [Test]
    public async Task ConvertResponse_CorrectResult()
    {
        var url = new Uri("https://reqres.in/api/users/2");
        using var httpClient = new HttpClient();
        using var response = await httpClient.GetAsync(url).ConfigureAwait(false);

        var result = await response.ToResultAsync<object>().ConfigureAwait(false);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Content, Is.Not.Null);
    }
}
