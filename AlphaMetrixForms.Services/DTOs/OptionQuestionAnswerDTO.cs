using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Services.DTOs
{
    public class OptionQuestionAnswerDTO
    {
        public Guid OptionQuestionId { get; set; }

        public Guid ResponseId { get; set; }

        public string Answer { get; set; }
    }
}
