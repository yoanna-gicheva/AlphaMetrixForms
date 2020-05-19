using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Services.DTOs
{
    public class FormDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid OwnerId { get; set; }
        public string Owner { get; set; }
        public ICollection<TextQuestionDTO> TextQuestions { get; set; }
        public ICollection<OptionQuestionDTO> OptionQuestions { get; set; }
        public ICollection<DocumentQuestionDTO> DocumentQuestions { get; set; }

        public ICollection<ResponseDTO> Responses { get; set; }

    }
}
