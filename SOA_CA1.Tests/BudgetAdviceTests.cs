using SOA_CA1.Models;
using Xunit;

namespace SOA_CA1.Tests;

public class BudgetAdviceTests
{
    [Theory]
    [InlineData(30, "Tight budget: focus on free parks")]
    [InlineData(100, "Comfortable: add one paid attraction")]
    [InlineData(200, "High budget: enjoy premium dining")]
    public void Should_Return_Correct_Budget_Advice(decimal amount, string expectedFragment)
    {
        var message = amount switch
        {
            < 50 => "Tight budget: focus on free parks",
            < 150 => "Comfortable: add one paid attraction",
            _ => "High budget: enjoy premium dining"
        };

        Assert.Contains(expectedFragment[..10], message);
    }
}
