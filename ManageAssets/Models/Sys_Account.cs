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
    
    public partial class Sys_Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sys_Account()
        {
            this.PAYMENTS = new HashSet<PAYMENT>();
        }
    
        public string Username { get; set; }
        public string Password { get; set; }
        public string GroupID { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Id_No { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public Nullable<bool> Use_Status { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAYMENT> PAYMENTS { get; set; }
        public virtual Sys_UserGroup Sys_UserGroup { get; set; }
    }
}
