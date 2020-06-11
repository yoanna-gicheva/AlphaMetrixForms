using System;

namespace AlphaMetrixForms.Data.Entities
{
    public class OptionQuestionAnswer
    {
        public Guid Id { get; set; }
        public Guid OptionQuestionId { get; set; }

        public OptionQuestion OptionQuestion { get; set; }
        public Guid ResponseId { get; set; }
        public Response Response { get; set; }

        public string Answer { get; set; }
    }
}