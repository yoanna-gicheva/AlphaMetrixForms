using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Services.DTOs
{
    public class ResponseDTO
    {
        public Guid Id { get; set; }

        public Guid FormId { get; set; }

        public string Form { get; set; }

        public ICollection<TextQuestionAnswerDTO> TextQuestionAnswers { get; set; }
        public ICollection<OptionQuestionAnswerDTO> OptionQuestionAnswers { get; set; }
        public ICollection<DocumentQuestionAnswerDTO> DocumentQuestionAnswers { get; set; }
    }
}
