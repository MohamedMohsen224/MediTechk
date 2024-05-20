
using Core;
using Core.IdentityServices;
using Core.Models;
using Core.Models.Identity;
using Core.Reposatries;
using Core.Services;
using MediTech.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Reposatry;
using Reposatry.Data;
using Reposatry.DAta;

using Srevices;
using System.Text;

namespace MediTech
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<HospitalContext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("MyApi"));
            });

            builder.Services.AddIdentity<AppUser,IdentityRole>(option =>
            {
                option.Password.RequiredLength = 6;
                option.Password.RequireDigit = true;
                option.Password.RequireLowercase = true;
                option.Password.RequireNonAlphanumeric = true;
                option.Password.RequireUppercase = true;

            })
           .AddEntityFrameworkStores<HospitalContext>()
           .AddDefaultTokenProviders();


            #region Services
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<Patient>();
            builder.Services.AddScoped(typeof(IGenaricReposatry<>), typeof(GenaricReposatry<>));
            builder.Services.AddAutoMapper(cfg => cfg.AddProfile(new MappingProfile(builder.Services.BuildServiceProvider().GetService<HospitalContext>())));
            builder.Services.AddScoped(typeof(IUnitOfwork), typeof(UnitOfwork));
            builder.Services.AddScoped(typeof(IPatientService), typeof(PatientServices));
            builder.Services.AddScoped(typeof(IPreceptionServices), typeof(PreciptionServices));
            builder.Services.AddScoped(typeof(IDoctorServises), typeof(DoctorServises));
            builder.Services.AddScoped(typeof(IClinicServises), typeof(ClinicServises));
            builder.Services.AddScoped(typeof(IDigitalXraySrevices), typeof(DigitalXrayServices));
            builder.Services.AddScoped(typeof(IAppointmentServices), typeof(AppointmentService));
            builder.Services.AddScoped(typeof(ITestServices),typeof(TestServices));
            builder.Services.AddScoped(typeof(IAuthServices), typeof(AuthServices));
            builder.Services.AddScoped(typeof(IMedicationService), typeof(MedicaionService));
            builder.Services.AddScoped<UserManager<AppUser>>();
            builder.Services.AddScoped<RoleManager<IdentityRole>>();
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(option =>
              {
                  option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = builder.Configuration["Jwt:ValidIssuer"],
                      ValidAudience = builder.Configuration["Jwt:ValidAudience"],
                      IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
                  };
              });
            
            #endregion

            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                                     builder =>
                                                     {
                                      builder.WithOrigins("http://localhost:3000");
                                                         builder.AllowAnyHeader();
                                                         builder.AllowAnyMethod();
                                                         builder.AllowAnyOrigin();

                                  });
            });


            var app = builder.Build();


            var Scope = app.Services.CreateScope();
            var services = Scope.ServiceProvider;
            var logger = services.GetRequiredService<ILoggerFactory>();
            try
            {
                var dbcontext = services.GetRequiredService<HospitalContext>();
                await dbcontext.Database.MigrateAsync();


                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                await roleManager.CreateAsync(new IdentityRole("Admin"));
                await roleManager.CreateAsync(new IdentityRole("Doctor"));
                await roleManager.CreateAsync(new IdentityRole("Patient"));

                await SeedData.SeedAsync(dbcontext);
                var userManager = services.GetRequiredService<UserManager<AppUser>>();
                await SeedIdentityData.SeedUsersAsync(userManager, roleManager);
            }
            catch (Exception ex)
            {

                var Logger = logger.CreateLogger<Program>();
                Logger.LogError(ex, "Error while Update Database");

            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseCors(MyAllowSpecificOrigins);

            app.MapControllers();

            app.Run();
        }
    }
}
