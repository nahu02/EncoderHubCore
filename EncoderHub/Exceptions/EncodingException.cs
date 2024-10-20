namespace EncoderHub.Exceptions;

public class EncodingException : Exception
{
    public EncodingException() : base("An error occurred during encoding.")
    {
    }

    public EncodingException(string message) : base(message)
    {
    }
    
    public EncodingException(string message, Exception innerException) : base(message, innerException)
    {
    }
}