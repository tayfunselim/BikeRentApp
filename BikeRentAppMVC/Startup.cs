using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentApp.BusinessLayer;
using BikeRentApp.Data;
using BikeRentApp.Data.InSqlData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BikeRentAppMVC
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
            services.AddMvc();
            services.AddDbContextPool<BikeDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BikeDb")));
            services.AddScoped<ICustomerData, CustomerDataSql>();
            services.AddScoped<IMembershipData, MembershipDataSql>();
            services.AddScoped<IPurchaseData, PurchaseDataSql>();
            services.AddScoped<PurchaseBL>();
            //services.AddControllers().AddNewtonsoftJson
            //    (options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
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
