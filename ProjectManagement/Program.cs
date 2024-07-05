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


Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddBootstrapBlazor();

builder.Services.AddSingleton<WeatherForecastService>();

// Register Table demo data service
builder.Services.AddTableDemoDataService();

// Configure SignalR options
builder.Services.Configure<HubOptions>(options => options.MaximumReceiveMessageSize = null);

// Register services
builder.Services.AddSingleton<AuthServices>();
builder.Services.AddHttpClient<IAuthServices, AuthServices>(client =>
{
    client.BaseAddress = new Uri("https://localhost:5164/");
});

builder.Services.AddHttpClient<IProjectService, ProjectService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:5164/");
});

builder.Services.AddScoped<IEncription, Encription>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IUrlHelperFactory, UrlHelperFactory>();
builder.Services.AddScoped<SessionServices>();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(2);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "YourDefaultAuthenticationScheme";
    options.DefaultChallengeScheme = "YourDefaultChallengeScheme";
    // Add more authentication configurations as needed
});


var app = builder.Build();

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

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
