using SOA_CA1.Components;
using SOA_CA1.Services.Holidays;
using SOA_CA1.Services.Currency;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient<IHolidayService, NagerDateHolidayService>(c =>
    c.BaseAddress = new Uri("https://date.nager.at/"));

builder.Services.Configure<ExchangeRateOptions>(
    builder.Configuration.GetSection("ExchangeRateHost"));

builder.Services.AddHttpClient<IExchangeService, ExchangeRateHostService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();
