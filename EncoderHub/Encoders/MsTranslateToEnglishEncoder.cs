using System.Text;
using EncoderHub.Exceptions;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace EncoderHub.Encoders;

/// <summary>
///     This class is responsible for translating a message to English using the Microsoft Translator Text API.
/// </summary>
public class MsTranslateToEnglishEncoder : IEncoder
{
    private readonly string _apiKey;

    private readonly Uri _apiUri;

    public MsTranslateToEnglishEncoder(string apiKey)
    {
        _apiKey = apiKey;
        _apiUri = new Uri("https://deep-translate1.p.rapidapi.com/language/translate/v2");
    }

    public string Description =>
        """
        This encoder uses the Microsoft Translator Text API to translate a message to English.
        The original message can be in any language.
        """;


    public async Task<string> Encode(string message)
    {
        var client = new HttpClient();

        var jsonContent = JsonSerializer.Serialize(new
        {
            q = message,
            target = "en" 
        });

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = _apiUri,
            Headers =
            {
                { "X-RapidAPI-Key", _apiKey },
                { "X-RapidAPI-Host", "deep-translate1.p.rapidapi.com" }
            },
            Content = new StringContent(
                jsonContent,
                Encoding.UTF8,
                "application/json")
        };
        using var response = await client.SendAsync(request);

        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            throw new EncodingException("Failed to send request to API.", e);
        }

        var responseBody = await response.Content.ReadAsStringAsync();

        var translationResponse =
            JsonConvert.DeserializeObject<TranslationResponse>(responseBody)
            ?? throw new EncodingException("Failed to deserialize response from API.");

        var translatedMessage = translationResponse.data.translations.translatedText;
        return translatedMessage;
    }

    internal record TranslationResponse
    {
        public Data data { get; set; }
    }

    internal record Data
    {
        public Translation translations { get; set; }
    }

    internal record Translation
    {
        public string translatedText { get; set; }

    }
}