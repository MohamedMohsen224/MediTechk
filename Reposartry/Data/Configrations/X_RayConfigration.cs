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
    public class X_RayConfigration : IEntityTypeConfiguration<Digital_x_rays>
    {
        public void Configure(EntityTypeBuilder<Digital_x_rays> builder)
        {
            builder.HasKey(i=>i.Id);
            builder.Property(p => p.Name);
            builder.Property(p => p.Price);

          

    
              

        }
    }
}
