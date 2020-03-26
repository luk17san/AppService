using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestAppService.Models.Extended
{
        public class ExQuestions
    {
        public int Question_ID { get; set; }
        public string Q_Name { get; set; }
        public bool IsAvailable { get; set; }

    }
}