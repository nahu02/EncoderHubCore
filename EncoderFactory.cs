namespace EncoderHub;

/// <summary>
///     Base class for interacting with encoders.
/// </summary>
public class EncoderFactory
{
    private readonly IEncoderStore _encoderStore;

    /// <summary>
    ///     Constructor for EncoderFactory, with encoder store Constructor Injection.
    ///     This constructor is used for Dependency Injection.
    /// </summary>
    /// <param name="encoderStore">IEncoderStore instance to use</param>
    public EncoderFactory(IEncoderStore encoderStore)
    {
        _encoderStore = encoderStore;
    }

    /// <summary>
    ///     Constructor for EncoderFactory, with default EncoderStore.
    /// </summary>
    public EncoderFactory()
    {
        _encoderStore = new EncoderStore();
    }

    /// <summary>
    ///     Get the names of all available encoders.
    ///     These encoder names can be used to get an encoder by name (see <see cref="GetEncoder" />).
    ///     Calls <see cref="IEncoderStore.AllEncoders" />.
    /// </summary>
    /// <returns>All available encoder names</returns>
    public IEnumerable<string> ListAllEncoders()
    {
        return _encoderStore.AllEncoders();
    }

    /// <summary>
    ///     Get an encoder by its name.
    ///     Valid encoder names can be obtained by calling <see cref="ListAllEncoders" />
    ///     Calls <see cref="IEncoderStore.GetEncoder" />.
    /// </summary>
    /// <param name="encoderName">Name of an encoder</param>
    /// <returns>Instance of encoder</returns>
    public IEncoder GetEncoder(string encoderName)
    {
        return _encoderStore.GetEncoder(encoderName);
    }
}