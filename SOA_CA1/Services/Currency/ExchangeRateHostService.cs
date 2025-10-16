using System.Text.Json;
using Microsoft.Extensions.Options;

namespace SOA_CA1.Services.Currency;

public class ExchangeRateHostService : IExchangeService
{
    private readonly HttpClient _http;
    private readonly string? _apiKey;

    public ExchangeRateHostService(HttpClient http, IOptions<ExchangeRateOptions> opts)
    {
        _http = http;
        _apiKey = opts.Value.ApiKey;
    }

    public async Task<decimal?> ConvertAsync(decimal amount, string fromCurrency, string toCurrency)
    {
        var baseUrl = $"https://api.exchangerate.host/convert?from={fromCurrency}&to={toCurrency}&amount={amount}";
        var url = string.IsNullOrWhiteSpace(_apiKey) ? baseUrl : $"{baseUrl}&access_key={_apiKey}";

        using var resp = await _http.GetAsync(url);
        if (!resp.IsSuccessStatusCode) return null;

        using var s = await resp.Content.ReadAsStreamAsync();
        using var doc = await JsonDocument.ParseAsync(s);
        return doc.RootElement.TryGetProperty("result", out var v) ? v.GetDecimal() : (decimal?)null;
    }
}
