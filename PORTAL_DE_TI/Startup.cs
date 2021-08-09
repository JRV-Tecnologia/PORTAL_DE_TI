using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Server.IISIntegration;
using PORTAL_DE_TI.Services;
using Microsoft.AspNetCore.Server.HttpSys;
using System.Security.Principal;

using Microsoft.EntityFrameworkCore;
using PORTAL_DE_TI.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace PORTAL_DE_TI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.Configure<IISOptions>(o =>
            {
                o.ForwardClientCertificate = false;
            });

           
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddHttpContextAccessor();
            services.AddTransient<IUserResolverService, UserResolverService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<UserResolverService>();

            var connection = @"Data Source=Desenvolvimento\SQLEXPRESS;User ID=admin;Password=admin@jrv;Database=DB_Portal_TI;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //var connection = @"Data Source=10.129.179.247;User ID=usrCargaPBI;Password=kX0V3Q@k;Database=DB_PORTAL_TI;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            services.AddDbContext<PortalContext>(options => options.UseSqlServer(connection));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
           .AddCookie(opt =>
           {
               opt.LoginPath = new PathString("/Authentication/Login");
               opt.LogoutPath = new PathString("/Authentication/Logout");
               opt.AccessDeniedPath = new PathString("/Authentication/Error");
               opt.Cookie = new CookieBuilder()
               {
                   Name = ".AuthenticateUser",
                   Expiration = new System.TimeSpan(0, 120, 0),
                    //Se tiver um domínio...
                    //Domain = ".site.com.br",
                };
           });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            //app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                     "NewsList",
                     "news",
                     new { controller = "news", action = "Index" });
                routes.MapRoute(
                     "NewsDetail",
                     "news/{id}",
                     new { controller = "news", action = "Detail", id = "" });
                routes.MapRoute(
                     "Banner4Detail",
                     "highlight/{id}",
                     new { controller = "highlight", action = "Detail", id = "" });
                routes.MapRoute(
                     "BannerDetail",
                     "banner/{id}",
                     new { controller = "banner", action = "Detail", id = "" });
                routes.MapRoute(
                    name: "default",
                    template: "{controller=PortalDeTi}/{action=Index}/{id?}");
                

            });
            app.Run(async (context) =>
            {
                try
                {
                    //var user = (WindowsIdentity)context.User.Identity;

                    //await context.Response
                    //    .WriteAsync($"User: {user.Name}\tState: {user.ImpersonationLevel}\n");

                    //WindowsIdentity.RunImpersonated(user.AccessToken, () =>
                    //{
                    //    var impersonatedUser = WindowsIdentity.GetCurrent();
                    //    var message =
                    //        $"User: {impersonatedUser.Name}\t" +
                    //        $"State: {impersonatedUser.ImpersonationLevel}";

                    //    var bytes = System.Text.Encoding.UTF8.GetBytes(message);
                    //    context.Response.Body.Write(bytes, 0, bytes.Length);
                    //});
                }
                catch (Exception e)
                {
                    await context.Response.WriteAsync(e.ToString());
                }
            });
        }

    }
}
