using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Services.DTOs
{
    public class ResponseDTO
    {
        public Guid Id { get; set; }

        public Guid FormId { get; set; }

        public DateTime CreatedOn { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<TextQuestionAnswerDTO> TextQuestionAnswers { get; set; }
        public ICollection<OptionQuestionAnswerDTO> OptionQuestionAnswers { get; set; }
        public ICollection<DocumentQuestionAnswerDTO> DocumentQuestionAnswers { get; set; }
    }
}
