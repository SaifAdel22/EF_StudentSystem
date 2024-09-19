using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Entities
{
    public class Student
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string? PhoneNumber { get; set; }
        public virtual DateTime Regeistration { get; set; }
        public virtual DateTime? BirthDay { get; set; }
        public virtual List<StudentCourses> StudentCourses { get; set; } = new List<StudentCourses>();
        public virtual List<HomeWork> HomeWorks { get; set; } = new List<HomeWork>();

    }

}
