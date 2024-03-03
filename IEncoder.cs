namespace EncoderHub;

public interface IEncoder
{
    string Description { get; }
    Task<string> Encode(string message);
}