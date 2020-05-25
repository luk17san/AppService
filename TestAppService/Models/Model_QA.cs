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
        public IEnumerable<Advertisment> Advertisments { get; set; }

        public Advertisment Advertisment { get; set; }
        public IList<string> SelectedAnswers { get; set; }
        public IList<Q_Answers> AvailableAnswers { get; set; }

        public User User { get; set; }


        public Model_QA()
        {
            SelectedAnswers = new List<string>();

            AvailableAnswers = new List<Q_Answers>();
        }
    }

}