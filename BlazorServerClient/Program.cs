using Auth0.AspNetCore.Authentication;
using BlazorServerClient;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BlazorServerClient.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// 👇 new code
builder.Services.AddAuth0WebAppAuthentication(opts =>
{
    opts.Domain = builder.Configuration["Auth0:Domain"]!;
    opts.ClientId = builder.Configuration["Auth0:ClientId"]!;
    // 👇 new code for calling Protected downstream API
    // By default, Auth0 authentication SDK implements the "Implicit grant with form post" to get only the ID token.
    // To also get an access token, we need to use "Authorization code grant", which requires using client secret.
    // With these changes, when the user logs in the app receives both ID and Access tokens
    // App stores access token in the current HTTPContext object.
    opts.ClientSecret = builder.Configuration["Auth0:ClientSecret"];
    opts.Scope = "openid profile email"; // This will prompt the user to give this web app to access the user's profile and email.
    // 👆 new code
})
// 👇 new code for calling Protected downstream API
.WithAccessToken(opts =>
{
    opts.Audience = builder.Configuration["Auth0:Audience"]!; // The audience of the access token is the backend API, i.e. https://api.weatherforecast.com
});
// 👆 new code
// 👆 new code

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// 👇 new code for calling Protected downstream API
builder.Services.AddScoped<TokenHandler>();
builder.Services.AddHttpContextAccessor(); // Required in TokenHandler
// Configure the HttpClient for the forecast service
var protectedApiUrl = builder.Configuration["ProtectedWebAPI:BaseUrl"]!;
builder.Services.AddHttpClient<WeatherForecastService>(client =>
{
    client.BaseAddress = new Uri(protectedApiUrl);
}).AddHttpMessageHandler<TokenHandler>(); // This guy will add Token to the requests
// 👆 new code

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

// 👇 new code
app.UseAuthentication();
app.UseAuthorization();
// 👆 new code

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();