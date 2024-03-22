using System;
using System.Collections.Generic;

namespace Project_PRN211_SE1729.Models
{
    public partial class Account
    {
        public int AccountId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int? TearcherId { get; set; }

        public virtual Teacher? Tearcher { get; set; }
    }
}
