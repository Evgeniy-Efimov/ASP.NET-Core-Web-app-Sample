using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApp.ActionFilters;
using WebApp.BLL;
using WebApp.DAL;
using WebApp.Helpers;
using WebApp.Interfaces;
using WebApp.Models;
using WebApp.Settings;

namespace WebApp
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
            var sessionTimeout = Configuration.GetSection(AuthSetting.SectionName).Get<AuthSetting>().SessionTimeoutInMinutes;
            services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(sessionTimeout));
            services.AddControllersWithViews();
            services.Configure<ConnectionString>(Configuration.GetSection(ConnectionString.SectionName));
            services.Configure<AuthSetting>(Configuration.GetSection(AuthSetting.SectionName));
            services.Configure<PaginationSetting>(Configuration.GetSection(PaginationSetting.SectionName));
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<DB1DataContext>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDocumentService, DocumentService>();
            services.AddControllersWithViews(x => { x.Filters.Add<AuthFilterAttribute>(); });
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
                app.UseExceptionHandler("/error/500");
                app.UseStatusCodePagesWithRedirects("~/error/{0}");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Document}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "error",
                    pattern: "error/{statusCode}",
                    defaults: new { controller = "Error", action = "Index" });
            });

            SettingHelper.Initialize(
                Configuration.GetSection(AuthSetting.SectionName).Get<AuthSetting>(),
                Configuration.GetSection(PaginationSetting.SectionName).Get<PaginationSetting>());

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }
    }
}
