using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Entities
{
    public class Resource
    {
        public virtual int Id {  get; set; }
        public virtual string Name { get; set; }
        public virtual ResourceType ResourceType { get; set; }  // Using the enum here

        public virtual string URL { get; set; }
        public virtual int CourseId {get; set; }
        public virtual Course? Course { get; set; }

    }
    public enum ResourceType
    {
        Video,
        Presentation,
        Document,
        Other
    }

}
