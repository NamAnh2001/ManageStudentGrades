using System;
using System.Collections.Generic;

namespace Project_PRN211_SE1729.Models
{
    public partial class Mark
    {
        public string StudentId { get; set; } = null!;
        public int TypeId { get; set; }
        public int SubId { get; set; }
        public double? Point { get; set; }

        public virtual Student Student { get; set; } = null!;
        public virtual Subject Sub { get; set; } = null!;
        public virtual TypePoint Type { get; set; } = null!;
    }
}
