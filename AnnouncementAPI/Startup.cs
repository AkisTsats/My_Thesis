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
using System.Threading.Channels;
using Google.Apis.Services;
using Google.Apis.Gmail.v1;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Keycloak.AuthServices.Authentication;
using static System.Net.WebRequestMethods;
using AnnouncementAPI.Helpers;
using AnnouncementAPI.Mail;
using DTOs.Data;
using Microsoft.Extensions.Options;
using AnnouncementAPI.Services;

namespace AnnouncementAPI
{
    public class Startup
    {
        //public KeycloakAuthenticationOptions configuration;

        //private const string connectionString = "Server=localhost;User Id=root;Password='r00t;';Database=test";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddKeycloakAuthentication(Configuration);

            var openIdConnectUrl = "http://localhost:8080/realms/Test/.well-known/openid-configuration";


            //TOADD
            services.AddSwaggerGen(c =>
            {
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Auth",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.OpenIdConnect,
                    OpenIdConnectUrl = new Uri(openIdConnectUrl),
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, Array.Empty<string>()}
                });
                c.CustomSchemaIds(type => type.FullName.Replace("+", "."));
            });

            services.AddHostedService<ConsumerSingletonProcessorSendEmail>();
            services.AddScoped<ProducerOfMyObjectsEndpoint>();
            services.AddSingleton(Channel.CreateUnbounded<AnnouncementDTO>());
            services.AddScoped<SendAnnouncement>();
            services.AddScoped<UserProvider>();
            services.AddScoped<AnnouncementService>();
            services.AddControllers();
            services.AddHttpContextAccessor();

            services.AddDbContext<EFDataAccessLibrary.Data.MyDbContext>(options =>
            {
                options.UseMySql(new MySqlServerVersion(new Version(8, 0, 21)));
                //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            
            services.AddCors(setup => setup.AddPolicy("default", (options) =>
            options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));
        }


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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
