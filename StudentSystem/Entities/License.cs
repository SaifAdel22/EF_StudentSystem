using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Entities
{
    public class License
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Resource? Resource { get; set; }
        public virtual int ResourceId { get; set; }

    }
}
