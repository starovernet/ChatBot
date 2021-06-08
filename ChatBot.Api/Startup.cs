using System;
using System.Collections.Generic;
using System.Linq;
using ChatBot.Api.Common;
using ChatBot.Api.Logic;
using ChatBot.DataAccess.MySql;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
using Microsoft.OpenApi.Models;

namespace ChatBot.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = Configuration.GetSection("AppSettings").Get<AppSettings>();
            services.AddAuthentication("").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(
                "", _ => { });
            services.AddAuthorization(x => x.AddPolicy("Admin", builder => builder.RequireAuthenticatedUser()));
            services.AddMemoryCache();
            services.AddSingleton(appSettings);
            services.AddControllers();
            services.AddHttpClient<IAiClient, AiClient>(client =>
            {
                client.BaseAddress = new Uri(appSettings.AiClientUrl);
                client.DefaultRequestHeaders.Add("authorization", appSettings.AiApiKey);
            });
            services.AddScoped<IResponseSelector, ResponseSelector>();
            Module.InitializeMySql(services, Configuration);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "ChatBot.Api", Version = "v1"});
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ChatBot.Api v1"));
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}