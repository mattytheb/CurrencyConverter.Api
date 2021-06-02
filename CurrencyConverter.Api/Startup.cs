using AutoMapper;
using CurrencyConverter.Api.Data;
using CurrencyConverter.Api.Repository;
using CurrencyConverter.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter.Api
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CurrencyContext>(cfg =>
            {
                cfg.UseSqlServer(_configuration.GetConnectionString("CurrencyContextDb"));
            });

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CurrencyMappingProfile());
            });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<CurrencyContext>();
            services.AddTransient<CurrencySeeder>();
            services.AddTransient<ConverterService>();
            services.AddScoped<IAppRepository, AppRepository>();


            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();

            services.AddRazorPages();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=App}/{action=Index}/{id?}");
            });

        }
    }
}
