using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudentSystem.Entities;
using StudentSystem.Data;

namespace StudentSystem.Data
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Course>Courses { get; set; }
        public virtual DbSet<StudentCourses>StudentCourses { get; set; }
        public virtual DbSet<Student>Students { get; set; }
        public virtual DbSet<HomeWork>HomeWorks { get; set; }
        public virtual DbSet<Resource>Resources { get; set; }
        public virtual DbSet<License> Licenses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetSection("constr").Value;

            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
