using System.Net.Http.Json;

namespace SOA_CA1.Services.Holidays;

public class NagerDateHolidayService : IHolidayService
{
    private readonly HttpClient _http;

    public NagerDateHolidayService(HttpClient http)
    {
        _http = http;
        if (_http.BaseAddress is null)
            _http.BaseAddress = new Uri("https://date.nager.at/");
    }

    public async Task<bool> IsPublicHolidayAsync(DateOnly date, string countryCode)
    {
        var year = date.Year;
        // GET /api/v3/PublicHolidays/{year}/{countryCode}
        var items = await _http.GetFromJsonAsync<List<NagerHolidayDto>>(
            $"api/v3/PublicHolidays/{year}/{countryCode}");

        if (items is null || items.Count == 0) return false;

        return items.Any(h => DateOnly.FromDateTime(h.Date) == date);
    }

    private sealed class NagerHolidayDto
    {
        public DateTime Date { get; set; }
        public string LocalName { get; set; } = "";
        public string Name { get; set; } = "";
    }

}

