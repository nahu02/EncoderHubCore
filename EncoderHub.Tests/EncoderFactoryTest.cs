using System;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;

namespace EncoderHub.Tests;

[TestFixture]
public class EncoderFactoryTests
{
    private Mock<IEncoderStore> _mockEncoderStore;
    private EncoderFactory _encoderFactory;

    [SetUp]
    public void SetUp()
    {
        _mockEncoderStore = new Mock<IEncoderStore>();
        _encoderFactory = new EncoderFactory(_mockEncoderStore.Object);
    }

    [Test]
    public void ListAllEncoders_ReturnsCorrectEncoderNames()
    {
        var expectedEncoders = new List<string> { "encoder1", "encoder2" };
        _mockEncoderStore.Setup(x =>
            x.AllEncoders()).Returns(expectedEncoders);

        var result = _encoderFactory.ListAllEncoders();

        Assert.That(result, Is.EqualTo(expectedEncoders));
    }

    [Test]
    public void GetEncoder_ReturnsCorrectEncoder()
    {
        var expectedEncoder = new Mock<IEncoder>().Object;
        _mockEncoderStore.Setup(x =>
            x.GetEncoder(It.IsAny<string>())).Returns(expectedEncoder);

        var result = _encoderFactory.GetEncoder("encoder1");

        Assert.That(result, Is.EqualTo(expectedEncoder));
    }
}