namespace SOA_CA1.Services.Holidays;

public interface IHolidayService
{
    Task<bool> IsPublicHolidayAsync(DateOnly date, string countryCode);
}
