namespace EncoderHub;

public class EncoderStore : IEncoderStore
{
    private readonly Dictionary<string, Lazy<IEncoder>> _encoders = new()
    {
        // {"encoder_name", new Lazy<IEncoder>(() => new EncoderClass())},
    };
    
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
    
    /*
    private EncoderClass CreateEncoderClass()
    {
        EncoderClass encoder = new();
        // Set properties, initialize, etc.
        return encoder;
    }
     */
}