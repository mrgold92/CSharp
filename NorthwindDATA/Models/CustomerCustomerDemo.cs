using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NorthwindDATA.Models
{
    public partial class CustomerCustomerDemo
    {
        public string CustomerID { get; set; }
        public string CustomerTypeID { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual CustomerDemographics CustomerType { get; set; }
    }
}
