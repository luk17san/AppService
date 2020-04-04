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
    
    public partial class Advertisment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Advertisment()
        {
            this.Ad_Services = new HashSet<Ad_Services>();
            this.Questions = new HashSet<Questions>();
        }
    
        public int Ad_ID { get; set; }
        public string Ad_Name { get; set; }
        public string Ad_Description { get; set; }
        public System.DateTime Ad_AddDataTime { get; set; }
        public Nullable<double> Ad_Budget { get; set; }
        public Nullable<int> Ad_Status { get; set; }
        public Nullable<int> Ad_Location { get; set; }
        public Nullable<int> Ad_User_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ad_Services> Ad_Services { get; set; }
        public virtual Location Location { get; set; }
        public virtual Status Status { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Questions> Questions { get; set; }
    }
}
