using System;

namespace AlphaMetrixForms.Data.Entities
{
    public class DocumentQuestionAnswer
    {
        public Guid DocumentQuestionId { get; set; }

        public DocumentQuestion DocumentQuestion { get; set; }
        public Guid ResponseId { get; set; }
        public Response Response { get; set; }

        public string Answer { get; set; }
    }
}