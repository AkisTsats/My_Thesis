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

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<CategoriesRepository>();
builder.Services.AddMudServices();

var services = builder.Services;

RegisterHttpClient(builder, services);

builder.Services.AddOidcAuthentication(options =>
{
    options.ProviderOptions.MetadataUrl = "http://localhost:8080/realms/Test/.well-known/openid-configuration";
    options.ProviderOptions.Authority = "http://localhost:8080/realms/Test";
    options.ProviderOptions.ClientId = "test-client";
    options.ProviderOptions.ResponseType = "id_token token";

    options.UserOptions.NameClaim = "preferred_username";
    options.UserOptions.RoleClaim = "roles";
    options.UserOptions.ScopeClaim = "scope";
});


await builder.Build().RunAsync();

static void RegisterHttpClient(
    WebAssemblyHostBuilder builder,
    IServiceCollection services)
{
    var httpClientName = "Default";

    services.AddHttpClient(httpClientName,
        client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
            .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

    services.AddScoped(
        sp => sp.GetRequiredService<IHttpClientFactory>()
            .CreateClient(httpClientName));
}
//public class CustomAuthenticationMessageHandler : AuthorizationMessageHandler
//{
//    public CustomAuthenticationMessageHandler(IAccessTokenProvider provder, NavigationManager nav) : base(provder, nav)
//    {
//        ConfigureHandler(new string[] { "https://demo.identityserver.io" });
//    }
//}

