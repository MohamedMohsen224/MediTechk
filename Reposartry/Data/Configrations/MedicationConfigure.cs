using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposatry.Data.Configrations
{
    public class MedicationConfigure : IEntityTypeConfiguration<Medication>
    {
        public void Configure(EntityTypeBuilder<Medication> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Medication_Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.medication_Description).HasMaxLength(50);
            builder.Property(e => e.medication_Price).IsRequired().HasColumnType("decimal(18, 2)").HasPrecision(18, 2);
            builder.Property(e => e.Medication_Quantity).HasMaxLength(50);
            builder.Property(e => e.Medication_Type).HasMaxLength(50);
            builder.Property(e => e.Expiration_Date).IsRequired().HasMaxLength(50);
         
            

        }
    }
}
