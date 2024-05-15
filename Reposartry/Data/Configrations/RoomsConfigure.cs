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
    public class RoomsConfigure : IEntityTypeConfiguration<Rooms>
    {
        public void Configure(EntityTypeBuilder<Rooms> builder)
        {

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.RoomNumber).IsRequired().HasMaxLength(50);
            builder.Property(p => p.RoomType).IsRequired().HasMaxLength(50);
            builder.Property(p => p.RoomStatus).IsRequired().HasMaxLength(50);
            builder.Property(p => p.RoomPrice).IsRequired().HasColumnType("decimal(18, 2)").HasPrecision(18, 2);
            builder.Property(p => p.Room_Location).IsRequired().HasMaxLength(50);
            builder.Property(p => p.RoomCapacity).IsRequired().HasMaxLength(50);
            builder.HasOne(p => p.Department).WithMany(p => p.Rooms).HasForeignKey(p => p.DepartmentId).OnDelete(DeleteBehavior.Restrict);
            builder.ToTable("Rooms");
            
        }
    }
}
