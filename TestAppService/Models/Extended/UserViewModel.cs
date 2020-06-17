using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAppService.Models.Extended
{
    public class UserViewModel
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<CheckBoxViewModelProfesion> UserVM { get; set; }
    }
}