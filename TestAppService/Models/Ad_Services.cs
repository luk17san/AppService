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
    
    public partial class Ad_Services
    {
        public int AdS_ID { get; set; }
        public Nullable<int> AdS_Ad_ID { get; set; }
    
        public virtual Advertisment Advertisment { get; set; }
        public virtual Services Services { get; set; }
    }
}
