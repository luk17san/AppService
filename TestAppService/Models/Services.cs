//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestAppService.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Services
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Services()
        {
            this.ServiceToAdvertisment = new HashSet<ServiceToAdvertisment>();
            this.UserProfesion = new HashSet<UserProfesion>();
        }
    
        public int ServiceID { get; set; }
        public string Name { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<double> Price { get; set; }
    
        public virtual Categories Categories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceToAdvertisment> ServiceToAdvertisment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserProfesion> UserProfesion { get; set; }
    }
}
