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
    
    public partial class QuestionToAdvertisment
    {
        public int ID { get; set; }
        public int AdertismentID { get; set; }
        public int QuestionID { get; set; }
    
        public virtual Advertisment Advertisment { get; set; }
        public virtual Questions Questions { get; set; }
    }
}
