using System;
using System.Collections.Generic;

namespace Project_PRN211_SE1729.Models
{
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }

        public int ClassId { get; set; }
        public string? Name { get; set; }
        public int? TeacherId { get; set; }

        public virtual Teacher? Teacher { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
