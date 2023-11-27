using Usp.App.Components;
using Usp.App.Logic.Services;
using Usp.App.Logic.Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("UspApi", (httpClient) =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration["UspApiPath"]);
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddTransient(typeof(ISellingPointService), typeof(SellingPointService));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
