# Creating a new encoder

There are two ways to extend the list encoders available for you.
You can of course create a new encoder local to your project, and use it there on a per-project basis.
Alternatively, you may want to extend this library with a new encoder. Then you can either use your fork for your
projects or submit a pull request to have your encoder added to the main library.

## Adding a new encoder locally

1. Create a new class that implements the `IEncoder` interface
2. After creating a new `EncoderStore` object, use the `AddEncoder` method to add your encoder and its initialization
   method
3. If you have many encoders, you may wish to extend the `EncoderStore` class to include your encoders in
   its `InitialEncoders` method
4. Create the `EncoderFactory` instance by supplying it your own `EncoderStore` instance; e.g. `var ef = new EncoderFactory(myEncoderStore)`.

## Adding a new encoder to the library

1. Fork this repository
2. Add your encoder to the `Encoders` directory, that implements the `IEncoder` interface
3. Modify the `EncoderStore` class so its `InitialEncoders` method includes your encoder
4. Use your fork in your project
