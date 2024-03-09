namespace EncoderHub;

public interface IEncoderStore
{
    IEnumerable<string> AllEncoders();
    IEncoder GetEncoder(string encoderName);
}