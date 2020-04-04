using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestAppService.Models
{
        public partial class Questions
    {
        public bool IsAvailable { get; set; }
    }
    public class QuestionModel
    {
        public List<Questions> Questions { get; set; }
    }
}