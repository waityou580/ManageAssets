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
    
    public partial class Sys_Controller
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sys_Controller()
        {
            this.Sys_Action = new HashSet<Sys_Action>();
        }
    
        public string Controller_ID { get; set; }
        public string Controller_Name_Vi { get; set; }
        public string Controller_Name_En { get; set; }
        public string Controller_Name_Cn { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sys_Action> Sys_Action { get; set; }
    }
}
