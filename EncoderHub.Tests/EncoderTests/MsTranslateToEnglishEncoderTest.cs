using System.Collections.Generic;
using System.Linq;
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
        Assert.That(result, Is.EqualTo("Hello world!"));
    }

    [Test]
    public async Task Encode_ShouldReturnEnglishTranslation_WhenInputIsGermanHelloWorld()
    {
        var result = await _msTranslateToEnglishEncoder.Encode("Hallo Welt!");
        Assert.That(result, Is.EqualTo("Hello world!"));
    }

    [Test]
    public async Task Encode_ShouldBeDeterministic()
    {
        var longTestMessage = """
                              A Wikipédia többnyelvű, nyílt tartalmú, a nyílt közösség által fejlesztett online világenciklopédia, amelyet a floridai központú nonprofit Wikimédia Alapítvány üzemeltet, szerkesztését pedig önkéntes közösség végzi. Az Alexa rangsorolása szerint a világ 13. leglátogatottabb weboldala.[3]

                              A Wikipédia magában foglalja a különböző nyelvi változatait is, köztük a magyar Wikipédiát. Az angol változat 2020 januárjában elérte a 6 milliós szócikkszámot;[4] ez a világ legnagyobb enciklopédikus műve. A 333 különböző nyelvű változatban[1] összesen (az angollal együtt) több mint 61 millió szócikk olvasható és szerkeszthető, és több mint 108 millió felhasználó szerkeszti őket világszerte.[5] Az egyedi látogatók száma meghaladja az 1,7 milliárdot havonta.[6] Az internet tíz népszerű szolgáltatása közül az Index-olvasók a Wikipédiát 2010-ben a harmadik leginkább pótolhatatlannak választották (a Google-t és a YouTube-ot követően).[7]

                              A Wikipédia név a wiki és az enciklopédia szavakból ered. Bár gyakori, hogy a Wikipédiára „Wiki”-ként hivatkoznak (lévén ez a legnagyobb wiki rendszer), azonban ez az elnevezés helytelen, mert több tízezer független, „wiki-rendszerű” oldal üzemel az interneten, melyek jelentős része nem enciklopédia.

                              Jellemzők

                              A Wikipédia projekt három alapvonása:
                              
                                  A Wikipédia elsődlegesen enciklopédia, vagy célja azzá válni (kalendárium és napi hírek adatokkal bővítve);
                                  a Wikipédia egy wiki, és így (néhány kivételtől eltekintve) bárki által szerkeszthető;
                                  a Wikipédia nyílt tartalmú, és a Creative Commons Nevezd meg! Így add tovább! 3.0 szabályai vonatkoznak rá.

                              A Wikipédiát a Nupediához (a Wikipédia elődjéhez) hasonlóan támogatja Richard Stallman, a szabadszoftver-mozgalom és a Free Software Foundation (Szabad Szoftver Alapítvány, FSF) alapítója; Stallman többször említette a „szabad, univerzális enciklopédia” hasznosságát még a Nupedia és a Wikipédia alapítása előtt.

                              A Wikipédia széles körű nyitottságának van néhány hátránya. Például azon cikkek esetén, melyek a legtöbb résztvevő számára ismeretlenek, a pontosság és a pártatlanság sokszor megkérdőjelezhető. A résztvevők egy része ezzel vitába szállva úgy gondolja, hogy idővel ezek a hibák csökkennek, és az egyes cikkek minősége javulni fog.

                              Egy másik hátrány az, hogy sok szerkesztést olyan emberek végeznek, akiknek nem céljuk az, hogy hasznosan vegyenek részt a munkában, hanem mindenféle értelmetlenséget („fghfhgf”) vagy elfogadhatatlan tartalmat („hüje aki ólvasa”) adnak a cikkekhez. Ezt a Wikipédia „vandalizmusnak” nevezi. A projekt nyílt természete ezt ugyan lehetővé teszi, de egyben ellene is dolgozik. Minden résztvevőnek megvan a lehetősége az ilyen firkák eltüntetésére, a megelőző állapot visszaállítására. Ha ez egy lapnál túl sokszor, túl gyakran fordul elő, akkor ez a lap „levédhető”, ilyenkor csak adminisztrátorok vagy járőrök tudják a tartalmát módosítani.
                              """; // source: https://hu.wikipedia.org/wiki/Wikip%C3%A9dia

        List<string> results = new();
        for (var i = 0; i < 10; i++)
        {
            results.Add(await _msTranslateToEnglishEncoder.Encode(longTestMessage));
            await Task.Delay(5000);
        }

        Assert.That(results.Distinct().Count(), Is.EqualTo(1));
    }
}