# How to use the library

This library is designed to be easy to use. The main class is `EncoderFactory`, which is a factory class that creates
encoders. This class is initialized with an `IEncoderStore` object, which is a collection of all the encoders available.
The base implementation of this interface is `EncoderStore`, which includes all the encoders that come with the library.
You may also add your own encoders to this store.

## Example usage

### Using a built-in encoder

```csharp
var store = new EncoderStore();
var factory = new EncoderFactory(store);

string chosenEncoderName = userChooseFromStringList(factory.ListAllEncoders());

IEncoder encoder = factory.GetEncoder(chosenEncoderName);

Console.WriteLine($"The chosen {chosenEncoderName} encoder has the following description:\n {encoder.Description}");

string encoded = await encoder.Encode("Hello, world!");
```

### Using a custom encoder

```csharp
var store = new EncoderStore();
store.AddEncoder("MyCustomEncoder", new Lazy<IEncoder>(() => new MyCustomEncoder(string someParameter)));

var factory = new EncoderFactory(store);

IEncoder encoder = factory.GetEncoder("MyCustomEncoder");
// ...
```