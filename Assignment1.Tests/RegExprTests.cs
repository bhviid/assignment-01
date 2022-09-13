using Xunit;

namespace Assignment1.Tests;

public class RegExprTests
{
    [Fact]
    public void SplitLine_When_Given_Lines_Returns_StreamOfWords()
    {
        var l = new List<string>() { "hello world", "hej med dig" };
        Assert.Equal(5,RegExpr.SplitLine(l).Count());
    }
    [Fact]
    public void Resolutions_When_Given_String_Returns_StreamOfResolutionTuples()
    {
        var s = "1920x1080,600x800";
        Assert.Contains((1920, 1080), RegExpr.Resolution(s));
        Assert.Contains((600, 800), RegExpr.Resolution(s));
    }
    [Fact]
    public void Innertext_When_Given_HTML_Returns_InnerString()
    {
        var html =
            "<div>\n    <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"https://en.wikipedia.org/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"https://en.wikipedia.org/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p>\n</div>";
        var tag = "b";
        Assert.Contains("regular expression", RegExpr.InnerText(html, tag));
    }

    [Fact]
    public void Urls_When_Given_HTML_Returns_URL_From_Index0()
    {
        var html =
        "<div>\n    <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"https://en.wikipedia.org/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"https://en.wikipedia.org/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p>\n</div>";
        var urls = RegExpr.Urls(html).ToList();
        Assert.True(urls[0].url.ToString() == "https://en.wikipedia.org/wiki/Theoretical_computer_science");

    }
    
}