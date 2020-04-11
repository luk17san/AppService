using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestAppService.Models;

namespace TestAppService.Models
{
    public class Model_QA
    {
        public IEnumerable<Q_Answers> Q_Answers { get; set; }
        public IEnumerable<Questions> Questions { get; set; }
        public Models.Advertisment Advertisment { get; set; }
}
}