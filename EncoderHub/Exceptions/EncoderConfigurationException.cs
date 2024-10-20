namespace EncoderHub.Exceptions;

public class EncoderConfigurationException : Exception
{
    public EncoderConfigurationException() : base("Encoder could not be configured.")
    {
    }

    public EncoderConfigurationException(string message) : base(message)
    {
    }
    
    public EncoderConfigurationException(string message, Exception innerException) : base(message, innerException)
    {
    }
}