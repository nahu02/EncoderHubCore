using System.Threading.Tasks;
using EncoderHub.Encoders;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace EncoderHub.Tests.EncoderTests;

[TestFixture]
public class MsTranslateToEnglishEncoderTest
{
    [SetUp]
    public void Setup()
    {
        var config = new ConfigurationBuilder()
            .AddUserSecrets<MsTranslateToEnglishEncoderTest>()
            .Build();
        var apiKey = config["MsTranslate:ApiKey"];
        // This works because the user secrets id is the same in the test project as in the main project,
        // so we can access the same API key from here too.

        _msTranslateToEnglishEncoder = new MsTranslateToEnglishEncoder(apiKey);
    }

    private MsTranslateToEnglishEncoder _msTranslateToEnglishEncoder;

    [Test]
    public async Task Encode_ShouldReturnEnglishTranslation_WhenInputIsHungarianHelloWorld()
    {
        var result = await _msTranslateToEnglishEncoder.Encode("Helló világ!");
        Assert.That(result.ToLower(), Is.EqualTo("Hello world!".ToLower()));
    }

    [Test]
    public async Task Encode_ShouldReturnEnglishTranslation_WhenInputIsGermanHelloWorld()
    {
        var result = await _msTranslateToEnglishEncoder.Encode("Hallo Welt!");
        Assert.That(result.ToLower(), Is.EqualTo("Hello world!".ToLower()));
    }
}