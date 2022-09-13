using Xunit;

namespace Assignment1.Tests;

public class IteratorsTests
{
    [Fact]
    public void Flatten_When_StreamsOfStreams_Returns_FlatStream()
    {
        
       IEnumerable<IEnumerable<string>> e =  new List<List<string>>() { new List<string>(){"a","b"}, new List<string>(){"c","d"}};
       Assert.Equal(4,Iterators.Flatten(e).Count());
       
    }
    
    [Fact]
    public void Flatten_When_StreamsOfStreams_Returns_OriginalElements()
    {
        IEnumerable<IEnumerable<string>> e =  new List<List<string>>() { new List<string>(){"a","b"}, new List<string>(){"c","d"} };
        var f = Iterators.Flatten(e);
        Assert.Contains("a", f);
        Assert.Contains("b", f);
        Assert.Contains("c", f);
        Assert.Contains("d", f);
    }
    [Fact]
    public void Filter_When_Stream_Returns_FilteredStream()
    {
        IEnumerable<string> e = new List<string>(){"a", "b"};
        Assert.Single(Iterators.Filter(e, s => s.Equals("a")));
    }
}