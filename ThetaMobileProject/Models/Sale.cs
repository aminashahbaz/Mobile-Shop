using System;
using System.Collections.Generic;

namespace ThetaMobileProject.Models
{
    public partial class Sale
    {
        public int Id { get; set; }
        public int CustomerCode { get; set; }
        public int? Price { get; set; }
        public int? Total { get; set; }
        public int? Quantity { get; set; }
        public int ItemCode { get; set; }
        public DateTime? Tdate { get; set; }
    }
}
