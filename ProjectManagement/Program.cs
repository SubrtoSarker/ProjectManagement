using Blazored.SessionStorage;
using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.SignalR;
using ProjectManagement.Components;
using ProjectManagement.Data;
using ProjectManagement.Services;
using ProjectManagement.Services.Auth;
using ProjectManagement.Services.Encription;
using ProjectManagement.Services.Project;
using ProjectManagement.Services.Session;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Register code pages encoding provider
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

// Add Razor components with interactive server components
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

// Add Bootstrap Blazor
builder.Services.AddBootstrapBlazor();
builder.Services.AddSingleton<ToastService>();
// Register services
builder.Services.AddSingleton<WeatherForecastService>();

// Register Table demo data service
builder.Services.AddTableDemoDataService();

// Configure SignalR options
builder.Services.Configure<HubOptions>(options => options.MaximumReceiveMessageSize = null);

// Register HttpClient services
builder.Services.AddHttpClient<IAuthServices, AuthServices>(client =>
{
    client.BaseAddress = new Uri("https://localhost:5164/");
});

builder.Services.AddHttpClient<IProjectService, ProjectService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:5164/");
});

// Register scoped services
builder.Services.AddScoped<IEncription, Encription>();

// Register session storage
builder.Services.AddBlazoredSessionStorage();

// Register HTTP context accessor
builder.Services.AddHttpContextAccessor();

// Register URL helper factory
builder.Services.AddSingleton<IUrlHelperFactory, UrlHelperFactory>();

// Configure session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(2);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Configure authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "YourDefaultAuthenticationScheme";
    options.DefaultChallengeScheme = "YourDefaultChallengeScheme";
});

var app = builder.Build();

// Configure middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseResponseCompression();
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();
app.UseSession();

// Map Razor components
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
