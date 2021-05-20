using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NorthwindDATA.Models
{
    public partial class Summary_of_Sales_by_Quarter
    {
        public DateTime? ShippedDate { get; set; }
        public int OrderID { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
