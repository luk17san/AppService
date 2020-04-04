using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestAppService.Models
{
    public partial class Q_Answers
    {
        public bool IsAvailable { get; set; }
    }
    public class AnswersModel
    {
        public List<Q_Answers> Q_Answers { get; set; }
    }
}