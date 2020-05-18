using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestAppService.Models
{
    public class HomeModel
    {
        public IList<string> SelectedFruits { get; set; }
        public IList<SelectListItem> AvailableFruits { get; set; }

        public HomeModel()
        {
            SelectedFruits = new List<string>();
            AvailableFruits = new List<SelectListItem>();
        }
    }
}