using System.Text.RegularExpressions;

namespace Assignment1;

public static class RegExpr
{

    public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
    {
        var regex = new Regex("[a-zA-Z0-9]{1,}");
        foreach (var line in lines)
        {
            foreach (Match match in regex.Matches(line))
            {
                yield return match.Value;

            }
        }
    }

    public static IEnumerable<(int width, int height)> Resolution(string resolutions)
    {
        var regex = new Regex("(?<width>[0-9]{3,4})x(?<height>[0-9]{3,4})");
        {
            foreach (Match match in regex.Matches(resolutions))
            {
                yield return (int.Parse(match.Groups["width"].Value), int.Parse(match.Groups["height"].Value));
            }
        }
    }

    public static IEnumerable<string> InnerText(string html, string tag)
    {
        var regex = new Regex($"<(?<tag>{tag}).*?>(?<inner>.*?)</\\1>");
        foreach (Match match in regex.Matches(html))
        {
            yield return match.Groups["inner"].Value;
        }
    }

    public static IEnumerable<(Uri url, string title)> Urls(string html)
    {
        
        var regex = new Regex(
            "<a href=\"(?<link>[a-zA-Z0-9:\\.\\/()_]*)\" *(title=\"(?<title>[a-zA-Z0-9:\\.\\/()_ ]*)\")*>(?<inner>[a-zA-Z0-9 .,]*)<\\/a>");
        foreach (Match match in regex.Matches(html))
        {
            yield return (new Uri(match.Groups["link"].Value), match.Groups["title"].Value);
        }
    }
    
}