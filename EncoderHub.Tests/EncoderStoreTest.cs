using NUnit.Framework;
using System;
using System.Linq;
using EncoderHub;
using EncoderHub.Exceptions;
using Moq;

namespace EncoderHub.Tests;

[TestFixture]
public class EncoderStoreTests
{
    private EncoderStore _encoderStore;
    private Mock<IEncoder> _mockEncoder;

    [SetUp]
    public void Setup()
    {
        _encoderStore = new EncoderStore();
        _mockEncoder = new Mock<IEncoder>();
    }

    [Test]
    public void AllEncoders_ReturnsCorrectKeys()
    {
        var testEncoderName = "testEncoder";

        _encoderStore.AddEncoder(testEncoderName, new Lazy<IEncoder>(() => _mockEncoder.Object));

        var allEncoders = _encoderStore.AllEncoders();

        Assert.That(allEncoders, Contains.Item(testEncoderName));
    }
    
    [Test]
    public void AllEncoders_WorksForMultipleEncoders()
    {
        var testEncoderName1 = "testEncoder1";
        var testEncoderName2 = "testEncoder2";

        _encoderStore.AddEncoder(testEncoderName1, new Lazy<IEncoder>(() => _mockEncoder.Object));
        _encoderStore.AddEncoder(testEncoderName2, new Lazy<IEncoder>(() => _mockEncoder.Object));

        var allEncoders =
            _encoderStore.AllEncoders() as string[] ?? _encoderStore.AllEncoders().ToArray();
        
        Assert.That(allEncoders, Contains.Item(testEncoderName1));
        Assert.That(allEncoders, Contains.Item(testEncoderName2));
    }
    
    [Test]
    public void GetEncoder_ReturnsCorrectEncoder()
    {
        var testEncoderName = "testEncoder2";

        _encoderStore.AddEncoder(testEncoderName, new Lazy<IEncoder>(() => _mockEncoder.Object));

        var result = _encoderStore.GetEncoder(testEncoderName);

        Assert.That(result, Is.EqualTo(_mockEncoder.Object));
    }
    
    [Test]
    public void GetEncoder_ThrowsEncoderNotFoundException()
    {
        var testEncoderName = "thisEncoderDoesNotExist";

        Assert.Throws<EncoderNotFoundException>(() => _encoderStore.GetEncoder(testEncoderName));
    }

}