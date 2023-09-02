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

builder.Services.AddScoped<CategoriesRepository>();
builder.Services.AddMudServices();

builder.Services.AddTransient<CustomAuthorizationMessageHandler>();

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
        client => client.BaseAddress = new Uri("https://localhost:5001"))
            .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();




    services.AddScoped(
        sp => sp.GetRequiredService<IHttpClientFactory>()
            .CreateClient(httpClientName));
}

public class CustomAuthorizationMessageHandler : AuthorizationMessageHandler
{
    public CustomAuthorizationMessageHandler(IAccessTokenProvider provider,
        NavigationManager navigation)
        : base(provider, navigation)
    {
        ConfigureHandler(
            authorizedUrls: new[] { "https://localhost:5001" });
    }
}

//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components.Web;
//using Microsoft.AspNetCore.StaticFiles;
//using MudBlazor.Services;
//using Microsoft.AspNetCore.Authentication.OpenIdConnect;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc.Authorization;
//using System.Net.Http;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.IdentityModel.Protocols.OpenIdConnect;
//using Microsoft.IdentityModel.Logging;
//using System.Security.Claims;
//using Microsoft.AspNetCore.Authentication;
//using System.IdentityModel.Tokens.Jwt;
//using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
//using System.Runtime.CompilerServices;
//using Microsoft.AspNetCore.Components.Server.Circuits;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Options;
//using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
//using Microsoft.AspNetCore.Http;

//var builder = WebAssemblyHostBuilder.CreateDefault(args);

//// Add services to the container.
//builder.Services.AddScoped<Session>();
//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//builder.Services.AddMudServices();
//builder.Services.AddCors(x => x.AddPolicy("externalRequests", policy => policy.WithOrigins("https://jsonip.com")));
//builder.Services.AddTransient<ITicketStore, InMemoryTicketStore>();
//builder.Services.AddSingleton<IPostConfigureOptions<CookieAuthenticationOptions>, ConfigureCookieAuthenticationOptions>();


//builder.Logging.SetMinimumLevel(LogLevel.Debug);


////Session session = new Session();

//builder.Services.AddAuthentication(sharedOptions =>
//{
//    sharedOptions.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    sharedOptions.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    sharedOptions.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;

//})
//       .AddCookie(cookie =>
//       {

//           //Sets the cookie name and maxage, so the cookie is invalidated.
//           cookie.Cookie.Name = "keycloak.cookie";
//           cookie.Cookie.MaxAge = TimeSpan.FromMinutes(1);
//           cookie.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
//           cookie.SlidingExpiration = true;
//       })
//       .AddOpenIdConnect("oidc", options =>
//       {
//           options.Authority = "http://localhost:8080/realms/Test";
//           options.ClientId = "test-client";
//           options.ClientSecret = "KA7ktDNWv2iyRBtQL1sDU383D9jMEhY1";
//           options.MetadataAddress = "http://localhost:8080/realms/Test/.well-known/openid-configuration";
//           options.ResponseType = "id_token token";
//           options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//           //options.SignInScheme = "Identity.External";
//           options.RequireHttpsMetadata = false; //dev
//           //options.RequireHttpsMetadata = true; 
//           options.SaveTokens = true;
//           options.GetClaimsFromUserInfoEndpoint = true;
//           options.UseTokenLifetime = false;
//           options.Scope.Add("openid");
//           options.Scope.Add("profile");
//           options.ClaimActions.MapUniqueJsonKey("role", "role");
//           //SameSite is needed for Chrome/Firefox, as they will give http error 500 back, if not set to unspecified.
//           options.NonceCookie.SameSite = SameSiteMode.Unspecified;
//           options.CorrelationCookie.SameSite = SameSiteMode.Unspecified;


//           options.TokenValidationParameters = new TokenValidationParameters
//           {
//               NameClaimType = "name",
//               RoleClaimType = ClaimTypes.Role,
//               //ValidateIssuer = true
//           };



//           options.Events = new OpenIdConnectEvents
//           {
//               OnAccessDenied = context =>
//               {
//                   context.HandleResponse();
//                   context.Response.Redirect("/");
//                   return Task.CompletedTask;
//               }
//           };

//           options.Events.OnAuthenticationFailed = ctx =>
//           {

//               return Task.CompletedTask;
//           };

//           options.Events.OnTicketReceived = ctx =>
//           {
//               List<AuthenticationToken> tokens = ctx.Properties!.GetTokens().ToList();
//               ClaimsIdentity claimsIdentity = (ClaimsIdentity)ctx.Principal!.Identity!;

//               foreach (AuthenticationToken t in tokens)
//               {
//                   claimsIdentity.AddClaim(new Claim(t.Name, t.Value));
//               }

//               var access_token = claimsIdentity.FindFirst((claim) => claim.Type == "access_token")?.Value;
//               if (access_token == null)
//               {
//                   Console.WriteLine("Warning: Token received was null!");
//                   return Task.CompletedTask;
//               }

//               var handler = new JwtSecurityTokenHandler();
//               var jwtSecurityToken = handler.ReadJwtToken(access_token);

//               string name;

//               foreach (Claim item in jwtSecurityToken.Claims)
//               {
//                   if (item.Type == "name")
//                   {
//                       name = item.Value;

//                   }
//               }

//               return Task.CompletedTask;
//           };

//       });


//var app = builder.Build();
//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();
//app.UseAuthentication(); // <- Add this
//app.UseAuthorization();  // <- Add this

////----Added property
////app.UseSession();
//app.UseCors("externalRequests");//--added for JS request ip script
//app.MapBlazorHub();
//app.MapFallbackToPage("/_Host");

//app.Run();
