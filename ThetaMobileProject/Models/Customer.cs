using System;
using System.Collections.Generic;

namespace ThetaMobileProject.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Cnic { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Country { get; set; }
        public DateTime? Tdate { get; set; }
    }
}
