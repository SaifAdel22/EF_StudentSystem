using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StudentSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Data.Config
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired()
                .ValueGeneratedNever();

            builder.Property(x => x.Name).HasColumnType("VARCHAR")
                .IsRequired().HasMaxLength(50);

            builder.Property(x => x.PhoneNumber);

            builder.Property(x => x.Regeistration);
            builder.Property(x => x.BirthDay);

   
            builder.ToTable("Students");

            builder.HasData(
           new Student { Id = 1, Name = "John Doe", PhoneNumber = "123-456-7890", Regeistration = new DateTime(2024, 9, 15), BirthDay = new DateTime(2000, 2, 15) },
           new Student { Id = 2, Name = "Jane Smith", PhoneNumber = "987-654-3210", Regeistration = new DateTime(2024, 9, 15), BirthDay = new DateTime(1999, 3, 10) },
           new Student { Id = 3, Name = "Alex Johnson", PhoneNumber = null, Regeistration = new DateTime(2024, 9, 15), BirthDay = null }
       );


        }
    }
    
    }

