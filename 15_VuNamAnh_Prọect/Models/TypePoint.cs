using System;
using System.Collections.Generic;

namespace Project_PRN211_SE1729.Models
{
    public partial class TypePoint
    {
        public TypePoint()
        {
            Marks = new HashSet<Mark>();
        }

        public int TId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }
    }
}
