using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RestWithASP_Net5Udemy.Repositories;
using RestWithASP_Net5Udemy.Services;
using RestWithAspNetUdemy.Contexts;
using RestWithAspNetUdemy.Repositories.Implementations;
using RestWithAspNetUdemy.Services.Implementations;
using Serilog;

namespace RestWithASP_Net5Udemy
{
    public class Startup
    {

        public IWebHostEnvironment Environment { get; }

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment envinroment)
        {
            Configuration = configuration;
            Environment = envinroment;

            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            var connection = Configuration["MySqlConnection:MySqlConnectionString"];

            services.AddDbContext<MysqlContext>(options => options.UseMySql(connection));

            if (Environment.IsDevelopment())
            {
                MigrateDatabase(connection);
            }

            PrepareDependencyInjection(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RestWithASP_Net5Udemy", Version = "v1" });
            });
        }

        private static void PrepareDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IPersonRepository, PersonRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestWithASP_Net5Udemy v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // O Evolve é similar ao Flyway
        private void MigrateDatabase(string connection)
        {
            try
            {
                var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connection);
                var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> {"Scripts/Migrations", "Scripts/Dataset"},
                    IsEraseDisabled = true
                };

                evolve.Migrate();
            }
            catch (Exception exception)
            {
                Log.Error("Database migration failed", exception);
                throw;
            }
        }
    }
}
