using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Tests;

[TestClass]
public class UtmTests 
{
    private const string _result = "https://balta.io/?utm_source=src&utm_medium=med&utm_campaign=name&utm_id=id&utm_term=term&utm_content=ctn";
    private readonly Url _url = new("https://balta.io/");
    private readonly Campaign _campaign = new(
            "src"
            ,"med"
            ,"name"
            ,"id"
            ,"term"
            ,"ctn");

    [TestMethod]
    public void ShouldReturnUrlFromUtm()
    {
        var utm = new Utm(_url, _campaign);

        Assert.AreEqual(_result, utm.ToString());
        Assert.AreEqual(_result, (string)utm);
    }

    [TestMethod]
    public void ShouldReturnUtmFromUrl()
    {
        Utm utm = _result;

        Assert.AreEqual("https://balta.io/", utm.Url.Address);
        Assert.AreEqual("src", utm.Campaign.Source);
        Assert.AreEqual("med", utm.Campaign.Medium);
        Assert.AreEqual("name", utm.Campaign.Name);
        Assert.AreEqual("id", utm.Campaign.Id);
        Assert.AreEqual("term", utm.Campaign.Term);
        Assert.AreEqual("ctn", utm.Campaign.Content);
    }
}