using System;
using System.Collections.Generic;

namespace Project_PRN211_SE1729.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Accounts = new HashSet<Account>();
            Classes = new HashSet<Class>();
            Subjects = new HashSet<Subject>();
        }

        public int TeachId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
