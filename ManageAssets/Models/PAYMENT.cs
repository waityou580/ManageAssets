//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManageAssets.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PAYMENT
    {
        public string Payment_ID { get; set; }
        public Nullable<System.DateTime> Payment_Date { get; set; }
        public string DEPT_ID { get; set; }
        public string Supplier_ID { get; set; }
        public Nullable<System.DateTime> Invoice_Date { get; set; }
        public Nullable<System.DateTime> Billing_period { get; set; }
        public string Payment_method { get; set; }
        public string Units_used { get; set; }
        public string Title_VN { get; set; }
        public string Title_CN { get; set; }
        public string Content_VN { get; set; }
        public string Content_CN { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> VAT { get; set; }
        public Nullable<int> Amount { get; set; }
        public string Currency { get; set; }
    
        public virtual DEPARTMENT DEPARTMENT { get; set; }
        public virtual SUPPLIER SUPPLIER { get; set; }
    }
}
