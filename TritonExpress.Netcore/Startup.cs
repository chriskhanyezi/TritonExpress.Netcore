using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TritonExpress.DAL;
using TritonExpress.DAL.Entities;
using TritonExpress.Logic.Branches;
using TritonExpress.Logic.Http;
using TritonExpress.Logic.Vehicles;
using TritonExpress.Logic.WayBills;

namespace TritonExpress.Netcore
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
            services.AddScoped<IData, Data>();

            services.AddScoped<IBranchLogic, BranchLogic>();

            services.AddScoped<IVehicleLogic, VehicleLogic>();

            services.AddScoped<IWayBillLogic, WayBillLogic>();
            
            services.AddHttpClient<IDataHttpClient, DataHttpClient>();

            services.AddDbContext<TritonExpressDevContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TritonExpressConnection")));
            
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddCors(options =>
            {
                options.AddPolicy("APICorsPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("APICorsPolicy");

            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                 name: "apiroutes",
                 pattern: "api/{controller}/{action}/{id?}");
            });
        }
    }
}
