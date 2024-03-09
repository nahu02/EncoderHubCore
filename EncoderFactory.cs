namespace EncoderHub;

public class EncoderFactory()
{
    
    private IEncoderStore _encoderStore = new EncoderStore();
    
    public EncoderFactory(IEncoderStore encoderStore) : this()
    {
        _encoderStore = encoderStore;
    }

    public IEnumerable<string> ListAllEncoders()
    {
        return _encoderStore.AllEncoders();
    }

    public IEncoder GetEncoder(string encoderName)
    {
        return _encoderStore.GetEncoder(encoderName);
    }
}