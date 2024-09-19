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
    public class StudentCoursesConfig : IEntityTypeConfiguration<StudentCourses>
    {
        public void Configure(EntityTypeBuilder<StudentCourses> builder)
        {
            builder.HasKey(x => new { x.CourseId, x.StudentId });


            builder.HasOne(x => x.Student).WithMany(x => x.StudentCourses).HasForeignKey(x=>x.StudentId);
            builder.HasOne(x => x.Course).WithMany(x => x.StudentCourses).HasForeignKey(x=>x.CourseId);
           


            builder.ToTable("StudentCourses");



            builder.HasData(
           new StudentCourses { StudentId = 1, CourseId = 1 },  // John Doe -> Mathematics
           new StudentCourses { StudentId = 1, CourseId = 3 },  // John Doe -> Computer Science
           new StudentCourses { StudentId = 2, CourseId = 2 },  // Jane Smith -> Physics
           new StudentCourses { StudentId = 3, CourseId = 3 }   // Alex Johnson -> Computer Science
       );

        }
    }
    
    
}
