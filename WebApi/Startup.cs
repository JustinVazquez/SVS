using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebApi.Hubs;

namespace WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly IHostingEnvironment _env;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });



            services.AddCors(options => options.AddPolicy("CorsPolicy",
           builder =>
           {
               builder.AllowAnyMethod().AllowAnyHeader()
                      .WithOrigins("https://localhost:1841/")
                      .AllowCredentials();
           }));

            // SignalR mit JSON
            services.AddSignalR(hubOptions =>
            {
                hubOptions.EnableDetailedErrors = true;
            });

            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status403Forbidden;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {

            // Make sure the CORS middleware is ahead of SignalR.
            app.UseCors(builder =>
            {
                builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowCredentials();
            });

            app.UseAuthentication();

            app.UseSignalR(routes =>
            {
                routes.MapHub<MainHub>("/Main");
            });

            app.UseMvc();
        }
    }

}
