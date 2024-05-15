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
    public class PatientConfigure : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            
            builder.Property(p => p.UserName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Address).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(100);
            builder.Property(p=>p.DateOfBirth).IsRequired();
            builder.Property(p=>p.Gender).IsRequired();
           
            builder.HasOne(p => p.Room)
           .WithMany(r => r.Patients)
           .HasForeignKey(p => p.RoomId)
           .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(p => p.prescriptions)
                .WithOne(pr => pr.Patient)
                .HasForeignKey(pr => pr.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

        
                

            builder.HasOne(p => p.Department)
                .WithMany(d => d.Patients)
                .HasForeignKey(p => p.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            

           


        }
    }
}
