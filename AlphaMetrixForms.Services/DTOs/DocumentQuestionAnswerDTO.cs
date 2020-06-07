using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Services.DTOs
{
    public class DocumentQuestionAnswerDTO
    {
        public Guid Id { get; set; }
        public Guid DocumentQuestionId { get; set; }
        public string Text { get; set; }
        public int OrderNumber { get; set; }
        public Guid ResponseId { get; set; }
        public string Answer { get; set; }
    }
}
