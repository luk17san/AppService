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
        public IEnumerable<Advertisment> Advertisments { get; set; }
        public User User { get; set; }
        public Answers Answers { get; set; }
        public Answers Questions { get; set; }
    }
}