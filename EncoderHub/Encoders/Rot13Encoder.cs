namespace EncoderHub.Encoders;

/// <summary>
///     An encoder that uses the ROT13 algorithm to encode/decode messages.
///     This algorithm is about shifting characters by 13 positions in the Latin alphabet.
///     Non Latin characters are returned unchanged.
/// </summary>
public class Rot13Encoder : IEncoder
{
    public string Description =>
        """
        The ROT13 algorithm is about shifting characters by 13 
        positions in the Latin alphabet (which contains 26 letters in total), therefore ROT13(ROT13(x)) = x.
        For example, the letter A is encrypted as N, B is encrypted as O, 
        and N and O are encrypted as A and B, respectively.
        Non Latin characters are returned unchanged. 
        """;

    public Task<string> Encode(string message)
    {
        return Task.FromResult(new string(message.Select(c =>
        {
            if (!char.IsAsciiLetter(c))
            {
                return c;
            }

            var offset = char.IsUpper(c) ? 'A' : 'a';
            return (char)((c + 13 - offset) % 26 + offset);
        }).ToArray()));
    }
}