using Datatone.OperationResult.Exceptions;
using Datatone.OperationResult.Results;
using System.Net;
using System.Text.Json;

namespace Datatone.OperationResult.Extensions
{
    public static class HttpResponseExtensions
    {
        public static async Task<ResultT<TContent, HttpException>> ToResultAsync<TContent>(this HttpResponseMessage httpResponse)
        {
            if(httpResponse.IsSuccessStatusCode)
            {
                var stringContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                var content = JsonSerializer.Deserialize<TContent>(stringContent);

                return Result.Success<TContent, HttpException>(content);
            }

            if(Is500sCode(httpResponse.StatusCode))
            {
                httpResponse.EnsureSuccessStatusCode();
            }

            var exception = new HttpException(httpResponse.StatusCode, httpResponse.ReasonPhrase);
            return Result.Fault<TContent, HttpException>(exception);
        }

        private static bool Is500sCode(HttpStatusCode statusCode)
        {
            var intStatusCode = (int)statusCode;
            return intStatusCode >= 500 && intStatusCode <= 599;
        }
    }
}
