using System;
using System.Collections.Generic;

namespace Project_PRN211_SE1729.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Marks = new HashSet<Mark>();
        }

        public int SId { get; set; }
        public string? Name { get; set; }
        public int? TeacherId { get; set; }

        public virtual Teacher? Teacher { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
