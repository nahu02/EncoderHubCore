namespace EncoderHub;

public static class EncoderFactory
{
    public static IEnumerable<string> ListAllEncoders()
    {
        throw new NotImplementedException();
    }

    public static IEncoder GetEncoder(string encoderName)
    {
        GetEncoderByName(encoderName);
        throw new NotImplementedException();
    }

    private static IEncoder GetEncoderByName(string name)
    {
        throw new NotImplementedException();
    }
}