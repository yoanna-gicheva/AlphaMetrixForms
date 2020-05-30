using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Services.DTOs
{
    public class TextQuestionDTO
    {
        public Guid Id { get; set; }

        public Guid FormId { get; set; }

        public string Form { get; set; }

        public string Text { get; set; }

        public bool IsRequired { get; set; }
        public bool IsLongAnswer { get; set; }

        public int OrderNumber { get; set; }

        public ICollection<TextQuestionAnswerDTO> Answers { get; set; }
    }
}
