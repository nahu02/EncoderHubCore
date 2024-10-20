using EncoderHub.Encoders;
using EncoderHub.Exceptions;
using Microsoft.Extensions.Configuration;

namespace EncoderHub;

public class EncoderStore : IEncoderStore
{
    private readonly IConfigurationRoot _configRoot;

    private readonly Dictionary<string, Lazy<IEncoder>> _encoders;

    public EncoderStore()
    {
        _configRoot = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .AddUserSecrets<EncoderStore>()
            .Build();

        _encoders = InitialEncoders();
    }

    public IEnumerable<string> AllEncoders()
    {
        return _encoders.Keys;
    }

    public IEncoder GetEncoder(string encoderName)
    {
        try
        {
            return _encoders[encoderName].Value;
        }
        catch (KeyNotFoundException)
        {
            throw new EncoderNotFoundException(encoderName);
        }
    }

    public void AddEncoder(string encoderName, Lazy<IEncoder> encoder)
    {
        _encoders.Add(encoderName, encoder);
    }

    private Dictionary<string, Lazy<IEncoder>> InitialEncoders()
    {
        var dict = new Dictionary<string, Lazy<IEncoder>>();
        dict.Add("ROT13", new Lazy<IEncoder>(() => new Rot13Encoder()));

        try
        {
            dict.Add("MsTranslateToEnglish", new Lazy<IEncoder>(CreateMsTranslateToEnglishEncoder));
        }
        catch (EncoderConfigurationException e)
        {
            Console.WriteLine(e);
            Console.WriteLine("MsTranslateToEnglish encoder will not be available.");
        }

        return dict;
    }

    private MsTranslateToEnglishEncoder CreateMsTranslateToEnglishEncoder()
    {
        var apiKey = _configRoot["MsTranslate:ApiKey"];

        if (string.IsNullOrWhiteSpace(apiKey))
            throw new EncoderConfigurationException(
                "MsTranslate:ApiKey is missing from the configuration."
            );

        return new MsTranslateToEnglishEncoder(apiKey);
    }

    /*
    private EncoderClass CreateEncoderClass()
    {
        EncoderClass encoder = new();
        // Set properties, initialize, etc.
        return encoder;
    }
     */
}
