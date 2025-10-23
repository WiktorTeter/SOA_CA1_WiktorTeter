using System;
using System.Threading.Tasks;
using SOA_CA1.Services.Holidays;
using Xunit;

namespace SOA_CA1.Tests;

public class FakeHolidayService : IHolidayService
{
    public Task<bool> IsPublicHolidayAsync(DateOnly date, string countryCode)
        => Task.FromResult(date.Day == 25 && date.Month == 12);
}

public class FakeHolidayServiceTests
{
    [Fact]
    public async Task Should_Detect_Christmas_As_Holiday()
    {
        var service = new FakeHolidayService();
        var result = await service.IsPublicHolidayAsync(new DateOnly(2025, 12, 25), "IE");
        Assert.True(result);
    }

    [Fact]
    public async Task Should_Return_False_For_Normal_Day()
    {
        var service = new FakeHolidayService();
        var result = await service.IsPublicHolidayAsync(new DateOnly(2025, 10, 20), "IE");
        Assert.False(result);
    }
}
