using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using WealthParkApi.Domain;
using WealthParkApi.ExtensionMethods;
using WealthParkApi.Repositories;
using WealthParkApi.Utils;

namespace WealthParkApi
{
    public class Startup
    {

        private readonly string _contentRootPath;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            _contentRootPath = env.ContentRootPath;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            string conn = Configuration.GetConnectionString("EmployeeDBConnection");
            if (conn.Contains("%CONTENTROOTPATH%"))
            {
                conn = conn.Replace("%CONTENTROOTPATH%", _contentRootPath);
            }
            services.AddDbContextPool<EmployeeDbContext>(options => options.UseSqlServer(conn));

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();


            services.AddMvc(o => { o.UseGeneralRoutePrefix($"{AppConstants.ApiRoot}/{AppConstants.ApiVersion}"); })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            // Register the Swagger generator
            services.AddSwaggerGen(c => {
                c.SwaggerDoc(AppConstants.ApiVersion, new Info
                {
                    Version = AppConstants.ApiVersion,
                    Title = AppConstants.ApiTitle,
                    Description = "Wealth Park Kintai (ASP.NET Core Web API)",
                    Contact = new Contact() { Name = "Hassan", Email = "console041@gmail.com", Url = "hovermind.com" }
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlPath = Path.Combine(AppContext.BaseDirectory, "WealthParkApiDoc.xml");
                c.IncludeXmlComments(xmlPath);
            });


        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios
                // see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // config. exception handling middleware before mvc middleware
            app.ConfigureAppMiddlewares();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"{AppConstants.ApiVersion}/swagger.json", AppConstants.ApiTitle);
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
