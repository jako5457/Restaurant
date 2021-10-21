using DataLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceLayer;
using System;
using System.Linq;

namespace WebApp
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
            string? ConnectionString = Environment.GetEnvironmentVariable("CONNECTIONSTRING");

            if (ConnectionString == null)
            {
                //Bruger Lokal database til debugging
                services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            }
            else
            {
                //Bruges til at sætte databasen op til docker
                services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnectionString));

                DbContextOptionsBuilder<AppDbContext> contextOptionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                contextOptionsBuilder.UseSqlServer(ConnectionString);

                using (AppDbContext context = new AppDbContext(contextOptionsBuilder.Options))
                {
                    //Checker om databasen eksisterer
                    context.Database.EnsureCreated();
                }
            }

            services.AddScoped<IRestaurantService, RestaurantService>();

            services.AddRazorPages()
               .AddRazorRuntimeCompilation()
               .AddRazorPagesOptions(options =>
               {
                   options.Conventions.AddPageRoute("/Restaurants/List", "");
               });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}