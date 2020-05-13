using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Services.DTOs
{
    public class DocumentQuestionDTO
    {
        public Guid Id { get; set; }

        public Guid FormId { get; set; }

        public string Form { get; set; }

        public string Text { get; set; }

        public bool IsRequired { get; set; }
        public int FileNumberLimit { get; set; }
        public int FileSizeLimit { get; set; }

        public ICollection<DocumentQuestionAnswerDTO> Answers { get; set; }
    }
}
