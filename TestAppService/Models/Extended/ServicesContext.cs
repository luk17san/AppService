using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TestAppService.Models
{
    public partial class Services
    {
        public bool IsChecked { get; set; }
        public virtual ICollection<User> UserProfesions { get; set; }
    }
    public class ServicesContext :DBServiceEntities
    {
        public DbSet<Categories> Categories {get; set;}
        public DbSet<Services> Services { get; set; }

    }
}