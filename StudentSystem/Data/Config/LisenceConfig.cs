using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Data.Config
{
    public class LisenceConfig : IEntityTypeConfiguration<License>
    {
        public void Configure(EntityTypeBuilder<License> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired()
                .ValueGeneratedNever();

            builder.Property(x => x.Name).HasColumnType("VARCHAR")
                .IsRequired().HasMaxLength(50);

            builder.HasOne(x => x.Resource).WithMany(x => x.Licenses)
                .HasForeignKey(x => x.ResourceId);

            builder.ToTable("Licenses");


            builder.HasData(
                 new License { Id = 1, Name = "Basic License", ResourceId = 1 },
                new License { Id = 2, Name = "Pro License", ResourceId = 1 },
                new License { Id = 3, Name = "Student License", ResourceId = 1 },
                new License { Id = 4, Name = "Enterprise License", ResourceId = 2 },
                new License { Id = 5, Name = "Basic License", ResourceId = 2 },
                new License { Id = 6, Name = "Student License", ResourceId = 3 }
             );

        }
    }
}
