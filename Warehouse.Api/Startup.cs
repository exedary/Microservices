using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using Warehouse.Api.Domain.Repositories;
using Warehouse.Api.Infrastructure.Database;
using Warehouse.Api.Infrastructure.Database.Repositories;
using Warehouse.Api.Infrastructure.ExternalServices;

namespace Warehouse.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddScoped<IItemsRepository, ItemsRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddHttpClient<IWarrantyService, WarrantyService>(client =>
                client.BaseAddress = new Uri(_configuration.GetSection("WarrantyApi").Value))
                .ConfigurePrimaryHttpMessageHandler( (IServiceProvider) => 
                new HttpClientHandler 
                {
                    ServerCertificateCustomValidationCallback = (a, b, c, d) => true
                });
            services.AddDbContext<WarehouseDbContext>(options =>
                options.UseNpgsql(_configuration.GetSection("WAREHOUSE_DB").Value));
            services.AddMediatR(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Warehouse API");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
