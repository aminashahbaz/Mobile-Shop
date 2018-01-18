using System;
using System.Collections.Generic;

namespace ThetaMobileProject.Models
{
    public partial class Vendor
    {
        public int VendorCode { get; set; }
        public string VendorName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Mobile { get; set; }
        public string Cnic { get; set; }
        public DateTime? Tdate { get; set; }
    }
}
