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
    
    public partial class Contract
    {
        public long ID { get; set; }
        public long PartnerID { get; set; }
        public string TaxCode { get; set; }
        public string Representative { get; set; }
        public Nullable<int> NumBranch { get; set; }
        public Nullable<decimal> Fee { get; set; }
        public Nullable<decimal> FeePerMonth { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
    
        public virtual User User { get; set; }
    }
}
