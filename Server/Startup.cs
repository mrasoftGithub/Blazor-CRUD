using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using CRUD.Server.Model;
using CRUD.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();

            // DBContext
            services.AddDbContextPool<DbContextClass>(
                options => options.UseSqlServer(Configuration.GetConnectionString("VOORBEELDConnection")));

            // Registreer de DBModel-implementatie van interface IModel
            // Voor een database de AddScoped gebruiken:
            // services.AddScoped<IModel, DBModel>();

            // Register de MemoryModel-implementatie van interface IModel
            // Voor de Memory model wil je niet dat de List 
            // elke keer weer wordt geïnitialiseerd naar de beginsituatie 
            // bij elke HTTP-request, dus daarom een SingleTon:
            services.AddSingleton<IModel, MemoryModel>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
