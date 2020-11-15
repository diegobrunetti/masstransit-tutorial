using System;
using AutoMapper;
using MassTransitTutorial.Domain;
using MassTransitTutorial.Mappings;
using MassTransitTutorial.Persistence;
using MassTransiTutorial.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace MassTransiTutorial.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            #region AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(config.CreateMapper());
            #endregion

            #region MySQL
            services.AddDbContextPool<CustomerContext>(options => options
                .UseMySql(Configuration.GetConnectionString("MySql"))
                .UseLoggerFactory(
                    LoggerFactory.Create(
                        logging => logging
                            .AddConsole()
                            .AddFilter(level => level >= LogLevel.Information)))
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
            );
            #endregion

            #region Repos e Services
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICreateCustomerService, CreateCustomerService>();
            services.AddScoped<IUpdateBirthDateService, UpdateBirthDateService>();
            services.AddScoped<IGetCustomerByIdService, GetCustomerByIdService>();
            #endregion

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MassTransit Tutorial API",
                    Description = "API básica e sem nenhum propósito interessante para demonstrar a utilização do MassTransit",
                    TermsOfService = new Uri("https://aresistencia.dev"),
                    Contact = new OpenApiContact
                    {
                        Name = "Diego Brunetti Teixeira",
                        Email = "diegoonsoftware@gmail.com",
                        Url = new Uri("https://aresistencia.dev"),
                    }
                });
            });
            #endregion

            #region MassTransit

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer API");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.ApplyDatabaseMigrations();
        }
    }
}
