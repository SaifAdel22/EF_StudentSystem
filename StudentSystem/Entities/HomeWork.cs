using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Entities
{
    public class HomeWork
    {
        public virtual int Id { get; set; }
        public virtual string Content { get; set; }
        public virtual ContentType ContentType { get; set; }
        public virtual DateTime SubmissionDate { get; set; }
        public virtual Student? Student { get; set; }
        public virtual int StudentId { get; set; }
        public virtual Course? Course { get; set; }
        public virtual int CourseId { get; set; }




    }
    public enum ContentType
    {
    application,
    pdf,
    zip
    }

}
