using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters.Json;

using Microsoft.IdentityModel.Tokens;
using IdentityServerHost.Quickstart.UI;

namespace DoctorHouse.IdentityServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IWebHostEnvironment Environment { get; }

        public Startup(IWebHostEnvironment environment)
        {
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // configure identity server with in-memory stores, keys, clients and resources
            var builder = services.AddIdentityServer()
                  .AddInMemoryIdentityResources(Config.IdentityResources)
                  .AddInMemoryApiScopes(Config.ApiScopes)
                  .AddInMemoryClients(Config.Clients)
                  //.AddInMemoryClients(ConfigGlobal.Clients)
                  .AddTestUsers(TestUsers.Users);

            builder.AddDeveloperSigningCredential();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseIdentityServer();
            
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
            //
            //   app.UseEndpoints(endpoints =>
            //   {
            //       endpoints.MapGet("/", async context =>
            //       {
            //           await context.Response.WriteAsync("Hello World!");
            //       });
            //   });
        }
    }
}
