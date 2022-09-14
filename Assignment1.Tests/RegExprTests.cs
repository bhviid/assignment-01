using Xunit;

namespace Assignment1.Tests;

public class RegExprTests
{
    [Fact]
    public void SplitLine_When_Given_Lines_Returns_StreamOfWords()
    {
        // Arrange 
        IEnumerable<string> l = new List<string>() { "hello world", "hej med dig" };

        // Act 
        var splitLine = RegExpr.SplitLine(l).Count();

        // Assert
        Assert.Equal(5, splitLine);
    }

    [Fact]
    public void Resolutions_When_Given_String_Returns_StreamOfResolutionTuples()
    {
        // Arrange
        var s = "1920x1080,600x800";

        // Act
        var resolution1 = RegExpr.Resolution(s);
        var resolution2 = RegExpr.Resolution(s);

        // Assert
        Assert.Contains((1920, 1080), resolution1);
        Assert.Contains((600, 800), resolution2);
    }

    [Fact]
    public void Innertext_When_Given_HTML_Returns_InnerString()
    {
        // Arrange 
        var html =
            "<div>\n    <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"https://en.wikipedia.org/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"https://en.wikipedia.org/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p>\n</div>";
        var tag = "b";

        // Act
        var innerText = RegExpr.InnerText(html, tag);

        // Assert
        Assert.Contains("regular expression", innerText);
    }

    [Fact]
    public void Urls_When_Given_HTML_Returns_URL_From_Index0()
    {
        // Arrange 
        var html =
        "<div>\n    <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"https://en.wikipedia.org/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"https://en.wikipedia.org/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p>\n</div>";

        // Act 
        var urls = RegExpr.Urls(html).ToList();

        // Assert
        Assert.True(urls[0].url.ToString() == "https://en.wikipedia.org/wiki/Theoretical_computer_science");
    }
}