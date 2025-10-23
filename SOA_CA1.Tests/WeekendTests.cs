using System;
using Xunit;

namespace SOA_CA1.Tests;

public class WeekendTests
{
    [Theory]
    [InlineData(2025, 10, 25, true)]  // Saturday
    [InlineData(2025, 10, 26, true)]  // Sunday
    [InlineData(2025, 10, 27, false)] // Monday
    public void IsWeekend_Should_Return_Correct_Value(int y, int m, int d, bool expected)
    {
        var date = new DateOnly(y, m, d);
        bool result = date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;
        Assert.Equal(expected, result);
    }
}