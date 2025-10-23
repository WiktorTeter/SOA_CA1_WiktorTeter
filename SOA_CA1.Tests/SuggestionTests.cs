using SOA_CA1.Models;
using Xunit;

namespace SOA_CA1.Tests;

public class SuggestionTests
{
    [Fact]
    public void Suggestions_Should_Sort_By_Priority()
    {
        var list = new List<Suggestion>
        {
            new() { Priority = 5, Message = "High" },
            new() { Priority = 1, Message = "Low" },
            new() { Priority = 3, Message = "Medium" }
        };

        list.Sort();

        Assert.Equal("Low", list[0].Message);
        Assert.Equal("Medium", list[1].Message);
        Assert.Equal("High", list[2].Message);
    }
}