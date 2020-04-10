using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TestAppService.Models
{
    public class AdContext : DBServiceEntities
    {
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Q_Answers> Q_Answers { get; set; }

    }

}