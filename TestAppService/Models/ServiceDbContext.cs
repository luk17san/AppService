using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestAppService.Models;

namespace TestAppService.Models
{
    public class ServiceDbContext
    {
        public IEnumerable<Answers> Answers { get; set; }
        public IEnumerable<Questions> Questions { get; set; }
        public IEnumerable<Advertisment> Advertisments { get; set; }

        public Advertisment Advertisment { get; set; }
        public IList<string> SelectedAnswers { get; set; }
        public IList<Answers> AvailableAnswers { get; set; }

        public User User { get; set; }


        public ServiceDbContext()
        {
            SelectedAnswers = new List<string>();

            AvailableAnswers = new List<Answers>();
        }
    }

}