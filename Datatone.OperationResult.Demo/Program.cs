using Datatone.OperationResult;
using Datatone.OperationResult.Exceptions;
using Datatone.OperationResult.Extensions;
using Datatone.OperationResult.Results;
using System.Net;
using System.Text.Json.Serialization;

var cp = new ColorProvider();
var successResult = await cp.GetColorByIdAsync(2);
Console.WriteLine(successResult);

var successResultList = await cp.GetAllColorsAsync();
Console.WriteLine(successResultList);

var errorResult = await cp.GetColorByIdAsync(23);
Console.WriteLine(errorResult);

public class Color
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("year")]
    public int Year { get; set; }

    [JsonPropertyName("color")]
    public string HexValue { get; set; }

    [JsonPropertyName("pantone_value")]
    public string PantoneValue { get; set; }

    public override string? ToString()
    {
        return $"{nameof(Id)}: {Id}, " +
               $"{nameof(Name)}: {Name}, " +
               $"{nameof(Year)}: {Year}, " +
               $"{nameof(HexValue)}: {HexValue}, " +
               $"{nameof(PantoneValue)}: {PantoneValue}";
    }
}

public class ColorWrap
{
    [JsonPropertyName("data")]
    public Color Color { get; set; }

    public override string? ToString()
    {
        return Color.ToString();
    }
}

public class ColorsWrap
{
    [JsonPropertyName("data")]
    public List<Color> Colors { get; set; }

    public override string? ToString()
    {
        return string.Join(";", Colors.Select(c => c.ToString()));
    }
}

public class ColorProvider
{
    public async Task<ResultT<List<Color>, ProviderException>> GetAllColorsAsync()
    {
        var url = new Uri($"https://reqres.in/api/unknown");
        using var httpClient = new HttpClient();
        using var response = await httpClient.GetAsync(url).ConfigureAwait(false);
        var result = await response.ToResultAsync<ColorsWrap>().ConfigureAwait(false);
        var convertedResult = Result.Pass(result, c => c.Colors, e =>
        {
            var errorType = ProviderErrorTypes.NotFound;
            if (e.ErrorType == HttpStatusCode.BadRequest)
                errorType = ProviderErrorTypes.IncorrectIdentifier;

            return new ProviderException(errorType, e);
        });

        return convertedResult;
    }

    public async Task<ResultT<Color, ProviderException>> GetColorByIdAsync(int id)
    {
        var url = new Uri($"https://reqres.in/api/unknown/{id}");
        using var httpClient = new HttpClient();
        using var response = await httpClient.GetAsync(url).ConfigureAwait(false);
        var result = await response.ToResultAsync<ColorWrap>().ConfigureAwait(false);
        var convertedResult = Result.Pass(result, c => c.Color, e => 
        {
            var errorType = ProviderErrorTypes.NotFound;
            if (e.ErrorType == HttpStatusCode.BadRequest)
                errorType = ProviderErrorTypes.IncorrectIdentifier;

            return new ProviderException(errorType, e);
        });

        return convertedResult;
    }
}