using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TestAppService.Models.Extended
{
    public class AdContext: DBServiceEntities
    {
        public DbSet<Advertisment> Advertisments { get; set; }
    }
}
