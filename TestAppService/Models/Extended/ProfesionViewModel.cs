using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAppService.Models.Extended
{
    public class ProfesionViewModel
    {
        public int UserID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Services> Services { get; set; }

        public virtual ICollection<UserProfesion> UserProfesions { get; set; }

    }
}