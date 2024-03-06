namespace EncoderHub;

public static class EncoderFactory
{
    public static IEnumerable<string> ListAllEncoders()
    {
        return EncoderStore.Encoders.Keys;
    }

    public static IEncoder GetEncoder(string encoderName)
    {
        try
        {
            return EncoderStore.Encoders[encoderName];
        }
        catch (KeyNotFoundException)
        {
            throw new EncoderNotFoundException(encoderName);
        }
    }
}