using System;
using System.Collections.Generic;

namespace Project_PRN211_SE1729.Models
{
    public partial class Student
    {
        public Student()
        {
            Marks = new HashSet<Mark>();
        }

        public string StudentId { get; set; } = null!;
        public string? Name { get; set; }
        public DateTime? Dob { get; set; }
        public string? Address { get; set; }
        public int? ClassId { get; set; }

        public virtual Class? Class { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
