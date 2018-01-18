using System;
using System.Collections.Generic;

namespace ThetaMobileProject.Models
{
    public partial class Item
    {
        public int ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Image { get; set; }
        public int? Quantity { get; set; }
        public string Description { get; set; }
        public int? Price { get; set; }
        public string ModelNo { get; set; }
        public string Color { get; set; }
        public int CatagoryCode { get; set; }
        public string SerialNo { get; set; }
        public DateTime? Tdate { get; set; }
    }
}
