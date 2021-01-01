using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using SportsStore.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace SportsStore
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
            services.AddTransient<IProductRepository, FakeProductRepository>();
            services.AddControllersWithViews();
            services.AddDbContext<ApplicationDBContext>(options => options.UseMySQL(Configuration.GetConnectionString("SportsStore")));
            services.AddTransient<IProductRepository, EFProductRepository>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseStatusCodePages();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "{category}/Page{page:int}",
                    defaults: new { controller = "Product", action = "List" });
                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "Page{page:int}",
                    defaults: new { controller = "Product", action = "list", page = 1 }
                );
                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "{category}",
                    defaults: new { controller = "Product", action = "List", page = 1 }
                );
                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "",
                    defaults: new { controller = "Product", action = "List", page = 1 }
                );
                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "{controller}/{action}/{id?}"
                );
            });

            // SeedData.EnsurePopulated(app);
        }
    }
}
