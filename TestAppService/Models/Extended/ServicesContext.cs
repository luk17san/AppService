using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TestAppService.Models
{
    public class ServicesContext :DBServiceEntities
    {
        public DbSet<Categories> Categories {get; set;}
        public DbSet<Services> Services { get; set; }

    }
}