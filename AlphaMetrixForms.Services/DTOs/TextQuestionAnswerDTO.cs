using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Services.DTOs
{
    public class TextQuestionAnswerDTO
    {
        public Guid Id { get; set; }
        public Guid TextQuestionId { get; set; }
        public string Text { get; set; }
        public int OrderNumber { get; set; }
        public Guid ResponseId { get; set; }
        public string Answer { get; set; }
    }
}
