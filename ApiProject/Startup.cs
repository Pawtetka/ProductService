using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProject.Business;
using ApiProject.Business.Services;
using ApiProject.Business.Services.Interfaces;
using ApiProject.Data;
using ApiProject.Data.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ApiProject
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

            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ProductService")));
            services.AddSingleton(new MapperConfiguration(conf => conf.AddProfile(new AutoMapperProfile())).CreateMapper());
            services.AddTransient<IProductService, Business.Services.ProductService>();
            services.AddTransient<IShopService, ShopService>();
            services.AddTransient<IStorageService, StorageService>();
            /*services.AddTransient<IProductInShopService, ProductInShopService>();
            services.AddTransient<IProductInStorageService, ProductInStorageService>();
            services.AddTransient<IDeliveryApplicationService, DeliveryApplicationService>();
            services.AddTransient<IDeliveryObjectService, DeliveryObjectService>();*/
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
