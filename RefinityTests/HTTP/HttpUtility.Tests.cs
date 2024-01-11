using System.Net;

// Assuming your class is in a namespace called Refinity.HTTP
using Refinity.Http;

[TestFixture]
public class HttpUtilityTests
{
    [Test]
    public void TestUrlEncode()
    {
        string str = "Hello World!";
        string result = HttpUtility.UrlEncode(str);
        Assert.That(result, Is.EqualTo(WebUtility.UrlEncode(str)));
    }

    [Test]
    public void TestUrlDecode()
    {
        string str = "Hello%20World%21";
        string result = HttpUtility.UrlDecode(str);
        Assert.That(result, Is.EqualTo(WebUtility.UrlDecode(str)));
    }

    [Test]
    public void TestHtmlEncode()
    {
        string str = "<Hello World!>";
        string result = HttpUtility.HtmlEncode(str);
        Assert.That(result, Is.EqualTo(WebUtility.HtmlEncode(str)));
    }

    [Test]
    public void TestHtmlDecode()
    {
        string str = "&lt;Hello World!&gt;";
        string result = HttpUtility.HtmlDecode(str);
        Assert.That(result, Is.EqualTo(WebUtility.HtmlDecode(str)));
    }
}