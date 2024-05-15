using Core.Models;
using Core.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Reposatry.DAta
{
    public class HospitalContext : IdentityDbContext<AppUser>
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(ut => new { ut.UserId, ut.LoginProvider, ut.Name });

        }

        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Tests> Tests { get; set; }
        public DbSet<warehouse> Warehouses { get; set; }
        public DbSet<Digital_x_rays> Digital_X_Rays { get; set; }
        public DbSet<PresciptionTests> PrescriptionTests { get; set; }
        public DbSet<PreciptionDigitalxrays> PreciptionDigitalxrays { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Booking> Bookings { get; set; }



      
      
    }
}
