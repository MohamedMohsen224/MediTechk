using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Reposatry.Data.Configrations
{
    public class DoctorConfigure : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            //builder.HasKey(d => d.Id);
           builder.Property(d => d.DisplayName).HasMaxLength(40).IsRequired();
            builder.Property(d => d.Address).HasMaxLength(50).IsRequired();
            builder.Property(d => d.PhoneNumber).HasMaxLength(11);
            builder.Property(d => d.Email).HasMaxLength(50).IsRequired();
            builder.Property(d => d.DateOfBirth).IsRequired();
            builder.Property(d => d.Speachlization).HasMaxLength(20).IsRequired();
            builder.Property(d => d.Profile_Picture).IsRequired();

           

            builder.HasOne(d => d.Clinic)
                .WithMany(clinic => clinic.Doctors)
                .HasForeignKey(d => d.ClinicId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(d => d.Appointments)
                .WithOne(a => a.Doctor)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);
            

        }
    }
}
