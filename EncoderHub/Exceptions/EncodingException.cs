namespace EncoderHub.Exceptions;

public class EncodingException : Exception
{
    public EncodingException()
    {
    }

    public EncodingException(string message) : base(message)
    {
    }
}