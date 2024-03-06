namespace EncoderHub;

public class EncoderNotFoundException : Exception
{
    public EncoderNotFoundException() : base("Encoder could not be found.") { }

    public EncoderNotFoundException(string encoderName)
        : base($"Encoder with name {encoderName} not found.") { }
}