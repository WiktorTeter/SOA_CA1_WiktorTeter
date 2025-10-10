using System.Net.Http.Json;

namespace SOA_CA1.Services.Holidays;

public class NagerDateHolidayService : IHolidayService
{
    private readonly HttpClient _http;

    public NagerDateHolidayService(HttpClient http)
    {
        _http = http;
    }

    public async Task<bool> IsPublicHolidayAsync(DateOnly date, string countryCode)
    {
        var year = date.Year;
        var holidays = await _http.GetFromJsonAsync<List<NagerHoliday>>(
            $"api/v3/PublicHolidays/{year}/{countryCode}");
        return holidays?.Any(h => DateOnly.FromDateTime(h.Date) == date) == true;
    }

    private sealed class NagerHoliday
    {
        public DateTime Date { get; set; }
        public string LocalName { get; set; } = "";
        public string Name { get; set; } = "";
    }
}

