using BusinessProject.Core.Classes;
using BusinessProject.Core.Interfaces;
using BusinessProject.Core.Services;
using BusinessProject.DataModelLayer.DbContext;
using BusinessProject.DataModelLayer.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessProject
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

            // Connect to database 
            services.AddDbContext<ApplicationContext>(option =>
            option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            // Services
            services.AddScoped<IUploadFile, UploadFile>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserJobRepository, UserJobRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILetterRepository, LetterRepository>();

            

            // AutoMapper
            services.AddAutoMapper(typeof(Startup));
            services.AddSignalR();

            services.AddControllersWithViews();

            //Identity Methods
            services.AddIdentity<SystemUsers, SystemRoles>(option =>
            {
                option.Password.RequireDigit = false;
                option.Password.RequireLowercase = false;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                // AdminArea
                endpoints.MapAreaControllerRoute(
                    "MyAdminArea",
                    "AdminArea",
                    "AdminArea/{controller=UserManager}/{action=Index}/{id?}"
                    );

                // UserArea
                endpoints.MapAreaControllerRoute(
                   "MyUserArea",
                   "UserArea",
                   "UserArea/{controller=UserHome}/{action=Index}/{id?}"
                   );

                // Default Routing 
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
