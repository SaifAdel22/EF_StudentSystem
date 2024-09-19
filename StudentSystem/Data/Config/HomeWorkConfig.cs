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
    public class HomeWorkConfig : IEntityTypeConfiguration<HomeWork>
    {
        public void Configure(EntityTypeBuilder<HomeWork> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired()
                .ValueGeneratedNever();

            builder.Property(x => x.Content).HasColumnType("VARCHAR")
                .IsRequired().HasMaxLength(50);

            builder.Property(x => x.ContentType)
               .HasMaxLength(50).IsRequired();

            builder.Property(x => x.SubmissionDate);




            builder.HasOne(x => x.Student).WithMany(x => x.HomeWorks)
                .HasForeignKey(x => x.StudentId);


            builder.ToTable("HomeWorks");

            builder.HasData(
           new HomeWork { Id = 1, Content = "Math Homework 1", ContentType = ContentType.pdf, SubmissionDate = new DateTime(2024, 10, 15), StudentId = 1, CourseId = 1 },
           new HomeWork { Id = 2, Content = "Physics Homework 1", ContentType = ContentType.pdf, SubmissionDate = new DateTime(2024, 10, 20), StudentId = 2, CourseId = 2 },
           new HomeWork { Id = 3, Content = "Programming Homework 1", ContentType = ContentType.zip, SubmissionDate = new DateTime(2024, 10, 25), StudentId = 3, CourseId = 3 }
       );

        }
    }
    
    
}
