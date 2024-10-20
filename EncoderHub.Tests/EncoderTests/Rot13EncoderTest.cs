using System.Threading.Tasks;
using EncoderHub.Encoders;
using NUnit.Framework;

namespace EncoderHub.Tests.EncoderTests;

[TestFixture]
public class Rot13EncoderTests
{
    [SetUp]
    public void Setup()
    {
        _rot13Encoder = new Rot13Encoder();
    }

    private Rot13Encoder _rot13Encoder;

    [Test]
    public async Task Encode_ShouldReturnRot13EncodedString_WhenInputIsLowercaseLetters()
    {
        var result = await _rot13Encoder.Encode("abc");
        Assert.That(result, Is.EqualTo("nop"));
    }

    [Test]
    public async Task Encode_ShouldReturnRot13EncodedString_WhenInputIsUppercaseLetters()
    {
        var result = await _rot13Encoder.Encode("ABC");
        Assert.That(result, Is.EqualTo("NOP"));
    }

    [Test]
    public async Task Encode_ShouldReturnSameString_WhenInputIsNonLatinCharacters()
    {
        var result = await _rot13Encoder.Encode("123");
        Assert.That(result, Is.EqualTo("123"));
    }

    [Test]
    public async Task Encode_ShouldReturnSemiEncodedString_WhenInputIsMixedLatinAndNonLatinCharacters()
    {
        var result = await _rot13Encoder.Encode("a1b2c3");
        Assert.That(result, Is.EqualTo("n1o2p3"));
    }

    [Test]
    public async Task Encode_ShouldReturnRot13EncodedString_WhenInputIsMixedCaseLetters()
    {
        var result = await _rot13Encoder.Encode("AbC");
        Assert.That(result, Is.EqualTo("NoP"));
    }

    [Test]
    public async Task Encode_ShouldReturnEmptyString_WhenInputIsEmpty()
    {
        var result = await _rot13Encoder.Encode("");
        Assert.That(result, Is.EqualTo(""));
    }

    [Test]
    public async Task Encode_ShouldReturnOriginalString_WhenEncodingLongStringTwice()
    {
        var input = """
                    A Wikipédiából, a szabad enciklopédiából

                    Az ezoterikus programozási nyelv olyan programnyelv, amelyet készítője nem mindennapi, gyakorlati programozási feladatok elvégzésére szán, hanem elkészítésével a programnyelvek tervezésével járó korlátokat feszegeti, művészeti célokat elégít ki, vagy akár viccel. Habár ezek a nyelvek általában nem alkalmasak gyakorlati szoftverfejlfesztési célokra, előfordulhatnak bennük olyan ötletek, amelyekből később az általános programnyelvek merítenek.

                    Az ilyen nyelveknek általában nem célja a használhatóság, gyakran épp az ellenkezője a cél, de mindemellett készítőik igyekeznek elérni, hogy a nyelv Turing-teljes legyen.
                    Történet
                    	Bővebben: INTERCAL programozási nyelv

                    Az egyik első ezoterikus nyelv az INTERCAL volt, amelyet 1972-ben készített Don Woods és James M. Lyon. Kimondott céljuk volt a megszokott módszerekkel való szakítás, a nyelvben parodizálták az akkoriban elterjedt Fortran, COBOL és assembly nyelveket. A nyelv sokáig csak papíron létezett. 1990-ben elkészült C alapú implementációja nagy érdeklődést keltett az ezoterikus programozási nyelvek iránt.
                    """; // Source: https://hu.wikipedia.org/wiki/Ezoterikus_programoz%C3%A1si_nyelv
        var encoded = await _rot13Encoder.Encode(input);
        var decoded = await _rot13Encoder.Encode(encoded);
        Assert.That(decoded, Is.EqualTo(input));
    }
}