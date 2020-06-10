using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAppService.Models.Extended
{
    public class UserViewModel
    {
        public int User_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public List<CheckBoxViewModelProfesion> UserVM { get; set; }
    }
}