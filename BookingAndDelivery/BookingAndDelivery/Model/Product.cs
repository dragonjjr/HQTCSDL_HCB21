//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookingAndDelivery.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public Product()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
            this.ProductBranches = new HashSet<ProductBranch>();
        }
    
        public long ID { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Price { get; set; }
        public long IsActive { get; set; }
    
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductBranch> ProductBranches { get; set; }
    }
}
