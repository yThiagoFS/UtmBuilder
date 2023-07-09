using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests;

[TestClass]
public class UrlTests
{
    // private const string InvalidUrl = "invalidUrl";
    // private const string ValidUrl = "https://www.chess.com";

    // [TestMethod("Should return a exception when the URL is invalid.")]
    // [TestCategory("URL Tests")]
    // [ExpectedException(typeof(InvalidUrlException))]
    // public void UrlInvalidShouldReturnException()
    // {
    //     new Url(InvalidUrl);
    // }

    // [TestMethod("Should not return a exception when the URL is valid.")]
    // [TestCategory("URL Tests")]
    // public void UrlInvalidShouldNotReturnException()
    // {
    //     new Url(ValidUrl);

    //     Assert.IsTrue(true);
    // }

    [TestMethod]
    [DataRow(" ", true)]
    [DataRow("http", true)]
    [DataRow("invalidurl", true)]
    [DataRow("https://www.chess.com", false)]
    public void TestUrl(
            string link
            ,bool expectException)
    {
        if(expectException)
        {
            try
            {
                new Url(link);
                Assert.Fail();
            }
            catch(InvalidUrlException)
            {
                Assert.IsTrue(true);
            }
        }
        else
        {
            new Url(link);
            Assert.IsTrue(true);
        }
    }

}