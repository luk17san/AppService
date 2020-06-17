using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAppService.Models.ViewModel
{
    public class CategoriesViewModel
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Categories> Categories { get; set; }
    }
}