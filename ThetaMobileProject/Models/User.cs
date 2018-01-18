using System;
using System.Collections.Generic;

namespace ThetaMobileProject.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public string UserName { get; set; }
        public DateTime? Tdate { get; set; }
    }
}
