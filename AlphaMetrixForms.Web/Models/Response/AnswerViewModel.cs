using AlphaMetrixForms.Web.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Web.Models.Response
{
    public class AnswerViewModel
    {
        public string Text { get; set; }
        public QuestionType Type { get; set; } 
        public string Answer { get; set; }

        // Options
        public ICollection<string> Answers { get; set; }
    }
}
