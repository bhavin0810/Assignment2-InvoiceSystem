//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InoviceProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class order_master
    {
        public order_master()
        {
            this.order_detail = new HashSet<order_detail>();
        }
    
        public decimal ORDER_ID { get; set; }
        public Nullable<decimal> CUSTOMER_ID { get; set; }
        public Nullable<System.DateTime> ORDER_DATE { get; set; }
        public string SHIPPING_FIRSTNAME { get; set; }
        public string SHIPPING_LASTNAME { get; set; }
        public string SHIPPING_ADDRESS { get; set; }
        public string SHIPPING_CITY { get; set; }
        public string SHIPPING_STATE { get; set; }
        public string SHIPPING_POSTAL_CODE { get; set; }
        public string USER_ID { get; set; }
        public Nullable<decimal> PRODUCT_ID { get; set; }
        public Nullable<int> QUANTITY { get; set; }
        public Nullable<decimal> UNIT_PRICE { get; set; }
        public Nullable<decimal> CATEGORY_ID { get; set; }
    
        public virtual customer_information customer_information { get; set; }
        public virtual ICollection<order_detail> order_detail { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual product_information product_information { get; set; }
        public virtual category_information category_information { get; set; }
    }
}
