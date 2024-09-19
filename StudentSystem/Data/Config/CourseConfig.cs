using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSystem.Entities;
using System;

namespace StudentSystem.Data.Config
{
    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired()
                .ValueGeneratedNever();

            builder.Property(x => x.Name).HasColumnType("VARCHAR")
                .IsRequired().HasMaxLength(50);

            builder.Property(x => x.Description).HasColumnType("VARCHAR")
               .HasMaxLength(50).IsRequired(false);

            builder.Property(x => x.StartDate).HasColumnType("date")
               .IsRequired();
            builder.Property(x => x.EndDate).HasColumnType("date")
               .IsRequired();

            //builder.OwnsOne(x => x.DateRange, ts =>
            //{
            //    ts.Property(p => p.StartDate).HasColumnType("date").HasColumnName("Start Date").IsRequired();
            //    ts.Property(p => p.EndDate).HasColumnType("date").HasColumnName("End Date").IsRequired();
            //});

            builder.Property(x => x.Price)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.HasMany(c => c.Resources)
                .WithOne(r => r.Course)
                .HasForeignKey(r => r.CourseId);

            builder.HasMany(c => c.HomeWorks)
                .WithOne(h => h.Course)
                .HasForeignKey(h => h.CourseId);

            builder.ToTable("Courses");

            builder.HasData(
                new Course
                {
                    Id = 1,
                    Name = "Mathematics",
                    Description = "Basic Math Course",
                    Price = 200.00m,
                    
                        StartDate = new DateTime(2024, 8, 1),
                        EndDate = new DateTime(2025, 1, 31)
                    
                },
                new Course
                {
                    Id = 2,
                    Name = "Physics",
                    Description = "Fundamentals of Physics",
                    Price = 250.00m,
                    
                        StartDate = new DateTime(2024, 9, 5),
                        EndDate = new DateTime(2025, 2, 1)
                    
                },
                new Course
                {
                    Id = 3,
                    Name = "Computer Science",
                    Description = "Introduction to Programming",
                    Price = 300.00m,
                    
                        StartDate = new DateTime(2024, 10, 1),
                        EndDate = new DateTime(2025, 2, 28)
                    
                }
            );
        }
    }
}
