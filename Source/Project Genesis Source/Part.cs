//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_Genesis_Source
{
    using System;
    using System.Collections.Generic;
    
    public partial class Part
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Part()
        {
            this.Invoice_Item = new HashSet<Invoice_Item>();
        }
    
        public int Part_ID { get; set; }
        public string Part_Name { get; set; }
        public string Part_SerialNum { get; set; }
        public string Part_PartNum { get; set; }
        public decimal Part_Price { get; set; }
        public string Part_Desc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice_Item> Invoice_Item { get; set; }
    }
}
