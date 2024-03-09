namespace EncoderHub;

/// <summary>
///     Interface for interacting with encoders.
/// </summary>
public interface IEncoder
{
    /// <summary>
    ///     A short description of what the encoder does,
    ///     what its expected input is, and what its output will be.
    /// </summary>
    string Description { get; }

    /// <summary>
    ///     The actual encoding step.
    ///     Concerts the message to a different format in a way that is specific to the encoder.
    ///     The <see cref="Description"/> property should contain information about the expected input and output.
    /// </summary>
    /// <param name="message">Message to be encoded</param>
    /// <returns>Task representing the encoding process</returns>
    Task<string> Encode(string message);
}