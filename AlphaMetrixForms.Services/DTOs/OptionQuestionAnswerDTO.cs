using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Services.DTOs
{
    public class OptionQuestionAnswerDTO
    {
        public OptionQuestionAnswerDTO()
        {
            Answers = new List<string>();
        }
        public Guid Id { get; set; }
        public Guid OptionQuestionId { get; set; }
        public string Text { get; set; }
        public int OrderNumber { get; set; }
        public Guid ResponseId { get; set; }
        public ICollection<string> Answers { get; set; }
    }
}
