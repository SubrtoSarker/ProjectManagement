using Blazored.SessionStorage;
using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.SignalR;
using ProjectManagement.Components;
using ProjectManagement.Data;
using ProjectManagement.Services;
using ProjectManagement.Services.Admin;
using ProjectManagement.Services.Auth;
using ProjectManagement.Services.Encription;
using ProjectManagement.Services.Project;
using ProjectManagement.Services.Session;
using ProjectManagement.Services.TaskM;
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
//var baseAddress = new Uri("https://localhost:5164/");
var baseAddress = new Uri("http://10.35.117.134:3422/");
builder.Services.AddHttpClient<IAuthServices, AuthServices>(client =>
{
    client.BaseAddress = baseAddress;
});

builder.Services.AddHttpClient<IProjectService, ProjectService>(client =>
{
    client.BaseAddress = baseAddress;
});

builder.Services.AddHttpClient<IAdminServices, AdminServices>(client =>
{
    client.BaseAddress = baseAddress;
});

builder.Services.AddHttpClient<ITaskServices, TaskServices>(client =>
{
    client.BaseAddress = baseAddress;
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
    options.IdleTimeout = TimeSpan.FromHours(8);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Configure authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "YourDefaultAuthenticationScheme";
    options.DefaultChallengeScheme = "YourDefaultChallengeScheme";
});
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
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
