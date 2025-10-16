using System.Net.Http.Json;

namespace SOA_CA1.Services.Holidays;

public class NagerDateHolidayService : IHolidayService
{
    private readonly HttpClient _http;
    public NagerDateHolidayService(HttpClient http) => _http = http;

    public async Task<bool> IsPublicHolidayAsync(DateOnly date, string countryCode)
    {
        var items = await _http.GetFromJsonAsync<List<NagerHolidayDto>>(
            $"api/v3/PublicHolidays/{date.Year}/{countryCode}");
        return items?.Any(h => DateOnly.FromDateTime(h.Date) == date) == true;
    }

    private sealed class NagerHolidayDto
    {
        public DateTime Date { get; set; }
        public string Name { get; set; } = "";
        public string LocalName { get; set; } = "";
    }
}
