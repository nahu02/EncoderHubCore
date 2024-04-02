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
        _apiUri = new Uri("https://microsoft-translator-text.p.rapidapi.com/translate?api-version=3.0&to=en");
    }

    public string Description =>
        """
        This encoder uses the Microsoft Translator Text API to translate a message to English.
        The original message can be in any language.
        """;


    public async Task<string> Encode(string message)
    {
        var client = new HttpClient();

        var jsonContent = JsonSerializer.Serialize(new[]
        {
            new { Text = message }
        });

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = _apiUri,
            Headers =
            {
                { "X-RapidAPI-Key", _apiKey },
                { "X-RapidAPI-Host", "microsoft-translator-text.p.rapidapi.com" }
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

        var translationResponses =
            JsonConvert.DeserializeObject<TranslationResponse[]>(responseBody)
            ?? throw new EncodingException("Failed to deserialize response from API.");

        var translatedMessage = translationResponses[0].translations[0].text;
        return translatedMessage;
    }

    internal record TranslationResponse
    {
        public DetectedLanguage detectedLanguage { get; set; }

        public Translations[] translations { get; set; }
    }

    internal record DetectedLanguage
    {
        public string language { get; set; }

        public double score { get; set; }
    }

    internal record Translations
    {
        public string text { get; set; }

        public string to { get; set; }
    }
}