using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestAppService.Models;

namespace TestAppService.Models.Extended
{
    public class ViewModel_Ad
    {
        public IEnumerable<Q_Answers> Q_Answers { get; set; }
        public IEnumerable<Questions> Questions { get; set; }
    }
}