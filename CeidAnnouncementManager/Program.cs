using CeidAnnouncementManager;
using CeidAnnouncementManager.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<CategoriesRepository>();
builder.Services.AddMudServices();


//builder.Services.AddOidcAuthentication(options =>
//{
//    builder.Configuration.Bind("Local", options.ProviderOptions);
//});

//builder.Services.AddScoped<CustomAuthenticationMessageHandler>();
//builder.Services.AddHttpClient("api", opt => opt.BaseAddress = new Uri("https://demo.identityserver.io"))
//    .AddHttpMessageHandler<CustomAuthenticationMessageHandler>();
//builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("api"));

//builder.Services.AddOidcAuthentication(opt =>
//{
//    opt.ProviderOptions.Authority = "https://demo.identityserver.io";
//    opt.ProviderOptions.ClientId = "interactive.public";
//    opt.ProviderOptions.ResponseType = "code";
//    opt.ProviderOptions.DefaultScopes.Add("api");
//    opt.ProviderOptions.DefaultScopes.Add("email");
//    opt.ProviderOptions.DefaultScopes.Add("profile");
//});

await builder.Build().RunAsync();

//public class CustomAuthenticationMessageHandler : AuthorizationMessageHandler
//{
//    public CustomAuthenticationMessageHandler(IAccessTokenProvider provder, NavigationManager nav) : base(provder, nav)
//    {
//        ConfigureHandler(new string[] { "https://demo.identityserver.io" });
//    }
//}

