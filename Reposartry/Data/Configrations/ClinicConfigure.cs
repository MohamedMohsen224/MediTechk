using Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposatry.Data.Configrations
{
    internal class clinicConfigrations : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Clinic_Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Clinic_Location).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Clinic_Phone).IsRequired().HasMaxLength(50);
            builder.Property(e => e.AmoutForBook).IsRequired().HasColumnType("decimal(18, 2)").HasPrecision(18, 2);


            builder.HasMany(c => c.Doctors)
             .WithOne(d => d.Clinic)
             .HasForeignKey(d => d.ClinicId)
             .OnDelete(DeleteBehavior.Restrict);

             

          
        }
    }
}

