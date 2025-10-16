namespace SOA_CA1.Services.Currency;

public interface IExchangeService
{
    Task<decimal?> ConvertAsync(decimal amount, string fromCurrency, string toCurrency);
}
