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
    public class NurcesConfigure : IEntityTypeConfiguration<Nurse>
    {
        public void Configure(EntityTypeBuilder<Nurse> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Nurse_Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Nurse_Address).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Nurse_Phone).IsRequired().HasMaxLength(50);
            builder.HasOne(e => e.Department).WithMany(e => e.Nurses).HasForeignKey(e => e.DepartmentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
