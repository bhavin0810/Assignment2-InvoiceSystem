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
    
    public partial class category_information
    {
        public category_information()
        {
            this.product_information = new HashSet<product_information>();
            this.order_master = new HashSet<order_master>();
        }
    
        public decimal ID { get; set; }
        public string DESCRIPTION { get; set; }
        public string CATEGORY_NAME { get; set; }
    
        public virtual ICollection<product_information> product_information { get; set; }
        public virtual ICollection<order_master> order_master { get; set; }
    }
}
