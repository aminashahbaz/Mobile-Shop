using System;
using System.Collections.Generic;

namespace ThetaMobileProject.Models
{
    public partial class Purchase
    {
        public int Id { get; set; }
        public int ItemCode { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
        public int VendorCode { get; set; }
    }
}
