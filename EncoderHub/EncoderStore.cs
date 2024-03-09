using EncoderHub.Exceptions;

namespace EncoderHub;

public class EncoderStore : IEncoderStore
{
    private readonly Dictionary<string, Lazy<IEncoder>> _encoders = new()
    {
        // {"encoder_name", new Lazy<IEncoder>(() => CreateEncoderClass())},
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
    
    public void AddEncoder(string encoderName, Lazy<IEncoder> encoder)
    {
        _encoders.Add(encoderName, encoder);
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
