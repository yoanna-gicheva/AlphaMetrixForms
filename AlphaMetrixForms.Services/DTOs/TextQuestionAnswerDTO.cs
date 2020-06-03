using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Services.DTOs
{
    public class TextQuestionAnswerDTO
    {
        public Guid Id { get; set; }
        public Guid TextQuestionId { get; set; }

        public Guid ResponseId { get; set; }

        public string Answer { get; set; }
    }
}
