using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ManageAssets.Models
{
    [MetadataType(typeof(PaymentMetadata))]
    public partial class PAYMENT
    {
        internal sealed class PaymentMetadata
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
            [DisplayFormat(DataFormatString = "{0:C0}")]
            public Nullable<int> Price { get; set; }
            [DisplayFormat(DataFormatString = "{0:C0}")]
            public Nullable<int> VAT { get; set; }
            [DisplayFormat(DataFormatString = "{0:C0}")]
            public Nullable<int> Amount { get; set; }
            public string Currency { get; set; }
            public string Users_Create { get; set; }
            public string Payment_Brand { get; set; }
        }
    }
}