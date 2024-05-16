using AdminPanel.services;
using Core.Models.Enums;
using Core.Models.Identity;
using MediTech.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Reposatry.DAta;
using System.Text;

namespace AdminPanel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<HospitalContext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("MyApi"));
            });

            builder.Services.AddIdentity<AppUser,IdentityRole>(option =>
            {
                //option.Password.RequiredLength = 6;
                //option.Password.RequireDigit = true;
                //option.Password.RequireLowercase = true;
                //option.Password.RequireNonAlphanumeric = true;
                //option.Password.RequireUppercase = true;

            })
         .AddEntityFrameworkStores<HospitalContext>()
         .AddDefaultTokenProviders();
            builder.Services.AddAutoMapper(cfg => cfg.AddProfile(new MappingProfile(builder.Services.BuildServiceProvider().GetService<HospitalContext>())));
            builder.Services.AddScoped<services.SeedImgeService>();

            var app = builder.Build();





            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Admin}/{action=login}/{id?}");

            app.Run();
        }
    }
}
