namespace EncoderHub;

public static class EncoderStore
{
    public static readonly Dictionary<string, IEncoder> Encoders = new()
    {
        // {"encoder_name", class instance},
    };
}