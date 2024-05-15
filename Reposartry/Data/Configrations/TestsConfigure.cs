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
    public class TestsConfigure : IEntityTypeConfiguration<Tests>
    {
        public void Configure(EntityTypeBuilder<Tests> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.TestName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.TestPrice).IsRequired();
           

            


        }
    }
}
