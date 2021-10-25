using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductService.Data.Repository;
using ProductService.Business.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ProductService.Business;
using ProductService.Data;
using ProductService.Business.Services.Interfaces;
using ProductService.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ProductService
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
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ProductService")));
            services.AddSingleton(new MapperConfiguration(conf => conf.AddProfile(new AutoMapperProfile())).CreateMapper());
            services.AddControllersWithViews();
            services.AddTransient<IProductService, Business.Services.ProductService>();
            services.AddTransient<IApplicationService, ApplicationService>();
            services.AddTransient<IApplicationCreator, ApplicationCreator>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ILoginService, LoginService>();

            services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 4;
                //opt.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationContext>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
