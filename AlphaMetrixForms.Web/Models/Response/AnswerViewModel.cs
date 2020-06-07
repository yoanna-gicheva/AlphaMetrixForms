using AlphaMetrixForms.Web.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Web.Models.Response
{
    public class AnswerViewModel
    {
        public AnswerViewModel()
        {
            this.Answers = new List<string>();
        }
        public Guid Id { get; set; }
        public string Text { get; set; }
        public QuestionType Type { get; set; } 
        public string Answer { get; set; }

        // Options
        public ICollection<string> Answers { get; set; }
        public int OrderNumber { get; set; }
    }
}
