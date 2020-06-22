using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAppService.Models.ViewModel
{
    public class AdViewModel
    {
        public IEnumerable<Answers> AnswersIE { get; set; }
        public IEnumerable<Questions> QuestionsIE { get; set; }
        public IEnumerable<Advertisment> AdvertismentsIE { get; set; }
        public Advertisment Advertisments { get; set; }
        public User Users { get; set; }
        public Answers Answers { get; set; }
        public Questions Questions { get; set; }

    }
}