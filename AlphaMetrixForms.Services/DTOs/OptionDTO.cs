using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Services.DTOs
{
    public class OptionDTO
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }

        public string Text { get; set; }
    }
}
