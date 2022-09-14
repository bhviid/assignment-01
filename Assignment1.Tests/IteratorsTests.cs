using Xunit;

namespace Assignment1.Tests;

public class IteratorsTests
{
    [Fact]
    public void Flatten_When_StreamsOfStreams_Returns_FlatStream()
    {
        // Arrange 
        IEnumerable<IEnumerable<string>> e = new List<List<string>>() { new List<string>() { "a", "b" }, new List<string>() { "c", "d" } };

        // Act 
        var flatten = Iterators.Flatten(e).Count();

        // Assert
        Assert.Equal(4, flatten);
    }

    [Fact]
    public void Flatten_When_StreamsOfStreams_Returns_OriginalElements()
    {
        // Arrange 
        IEnumerable<IEnumerable<string>> e = new List<List<string>>() { new List<string>() { "a", "b" }, new List<string>() { "c", "d" } };

        // Act 
        var flatten = Iterators.Flatten(e);

        // Assert
        Assert.Contains("a", flatten);
        Assert.Contains("b", flatten);
        Assert.Contains("c", flatten);
        Assert.Contains("d", flatten);
    }

    [Fact]
    public void Filter_When_Stream_Returns_FilteredStream()
    {
        // Arrange
        IEnumerable<string> e = new List<string>() { "a", "b" };

        // Act
        var filter = Iterators.Filter(e, s => s.Equals("a"));

        // Assert 
        Assert.Single(filter);
    }
}