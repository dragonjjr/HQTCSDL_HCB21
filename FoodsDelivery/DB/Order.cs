//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FoodsDelivery.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public long ID { get; set; }
        public long BranchID { get; set; }
        public Nullable<int> Payment { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public int CustomerCityID { get; set; }
        public int CustomerDistrictID { get; set; }
        public Nullable<decimal> ProductFee { get; set; }
        public Nullable<decimal> TransferFee { get; set; }
        public string CustomerAddress { get; set; }
        public int Status { get; set; }
        public Nullable<long> DriverID { get; set; }
        public long CustomerID { get; set; }
    
        public virtual Branch Branch { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
