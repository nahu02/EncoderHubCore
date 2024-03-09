namespace EncoderHub;

/// <summary>
///     Interface for classes that stores and provides access to encoders.
///     These take care of the <b>creation</b> and <b>storage</b> of encoder instances.
/// </summary>
public interface IEncoderStore
{
    /// <summary>
    ///     Get the names of all available encoders.
    ///     These encoder names can be used to get an encoder by name (see <see cref="GetEncoder" />).
    /// </summary>
    /// <returns>IEnumerable of all encoder names</returns>
    IEnumerable<string> AllEncoders();


    /// <summary>
    ///     Get an encoder by its name.
    /// </summary>
    /// <param name="encoderName">Name of an encoder as listed by <see cref="AllEncoders" /></param>
    /// <exception cref="EncoderHub.Exceptions.EncoderNotFoundException">When the encoder with the given name could not be found</exception>
    /// <returns>IEncoder instance of encoder</returns>
    IEncoder GetEncoder(string encoderName);
}