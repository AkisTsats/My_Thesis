using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Services;
using Google.Apis.Gmail.v1;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;

namespace AnnouncementAPI
{
    public class Startup
    {
        //private const string connectionString = "Server=localhost;User Id=root;Password='r00t;';Database=test";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*
            string clientId = "572524065265-617scagdltv2iglq1bt9239080d7shnp.apps.googleusercontent.com";
            string clientSecret = "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";

            string[] scopes = { "https://www.googleapis.com/auth/gmail.readonly" };

            var credentials = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret
                },
                scopes, "user", CancellationToken.None).Result;


            if (credentials.Token.IsExpired(SystemClock.Default))
                credentials.RefreshTokenAsync(CancellationToken.None).Wait();

            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credentials
            });
            


            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = IdentityConstants.ExternalScheme;
            })
            .AddCookie(IdentityConstants.ExternalScheme)
            .AddGoogle( options =>
            {
                options.ClientSecret = "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";
                options.ClientId = "572524065265-617scagdltv2iglq1bt9239080d7shnp.apps.googleusercontent.com";
                options.SignInScheme = IdentityConstants.ExternalScheme;
                
            });
            
            services.AddAuthentication();

            services.AddAuthorization();
            */

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AnnouncementAPI", Version = "v1" });
            });

            services.AddDbContext<EFDataAccessLibrary.Data.MyDbContext>(options => {
                options.UseMySql(new MySqlServerVersion(new Version(8, 0, 21)));
                //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });


            services.AddCors(setup => setup.AddPolicy("default", (options) =>
            options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));
        }

        //connectionString, MySqlServerVersion.AutoDetect(connectionString)

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AnnouncementAPI v1"));
            }

            app.UseCors("default");

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthentication();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });



        }
    }
}
