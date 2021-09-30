using DesignPatterASP.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toolss.Earn;
using DesignPatterns.Models;
using DesignPatterns.Repository;
using DesignPatterns.Models.Data;
using Microsoft.EntityFrameworkCore;
using Toolss.Generator;

namespace DesignPatterASP
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
            services.AddControllersWithViews();
            services.Configure<MyConfig>(Configuration.GetSection("MyConfig"));


            //transitorio
            services.AddTransient((factory) =>
            {
                return new LocalEarnFactory(Configuration.GetSection("MyConfig").GetValue<decimal>("LocalPercentage"));
            });

            services.AddTransient((factory) =>
            {
                return new ForeignEarnFactory(Configuration.GetSection("MyConfig").GetValue<decimal>("ForeignPercentage"),Configuration.GetSection("MyConfig").GetValue<decimal>("Extra"));
            });

            services.AddDbContext<DesignPatternsContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Connection"));
            });
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<GeneratorConcreteBuilder>();
            //scope
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
