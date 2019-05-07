using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ForLimestone.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using ForLimestone.Filters;
using Microsoft.AspNetCore.HttpOverrides;

namespace ForLimestone
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
               
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(
               Configuration.GetConnectionString("CompaniesIPDatabase")));
            services.AddScoped<ClientIPCheckFilter>();

            services.AddMvc(options =>
            {
                options.Filters.Add
                   (new ClientIPCheckFilter());
            }).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);


            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            services.AddMemoryCache();
            services.AddTransient<ICompanyUsersIPRepository, EFCompanyIPRepository>();
            services.AddScoped<ICompanyUsersIPRepository, EFCompanyIPRepository>();
            services.AddMemoryCache();
            services.AddSession();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var ldapService = scope.ServiceProvider.GetRequiredService<ICompanyUsersIPRepository>();
            }


            
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=ListIP}/{action=List}/{id?}");
            });

            SeeData.EnsurePopulated(app);
        }
    }
}

