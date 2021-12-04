using Cinema.Web.Models;
using Cinema.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Web
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
            DbType dbType = Configuration.GetValue<DbType>("DbType");

            switch (dbType)
            {
                case DbType.SqlServer:
                    // Need Microsoft.EntityFrameworkCore.SqlServer package for this
                    services.AddDbContext<CinemaDbContext>(options =>
                    {
                        options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection"));
                        options.UseLazyLoadingProxies();
                    });
                    break;

                case DbType.Sqlite:
                    // Need Microsoft.EntityFrameworkCore.Sqlite package for this
                    services.AddDbContext<CinemaDbContext>(options =>
                    {
                        options.UseSqlite(Configuration.GetConnectionString("SqlServerConnection"));
                        options.UseLazyLoadingProxies();
                    });
                    break;
            }

            // Use lazy loading (don't forget the virtual keyword on the navigational properties also)

            services.AddTransient<ICinemaService, CinemaService>(); //Ah�nyszor megh�vj�k, annyi CinemaService lesz

            services.AddControllersWithViews(); //Controllereket �s a viewkat ezzel lehet felkonfigur�lni
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
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
                    pattern: "{controller=Home}/{action=Index}/{id?}"); //HomeController az alap
            });

            //Elk�rj�k a kor�bban felkonfigur�lt serviceket

            var context = services.GetRequiredService<CinemaDbContext>();

            var directory = Configuration["ImageStore"]; //appsettings.jsonben van ez
            DbInitializer.Initialize(context, directory);


        }
    }
}
