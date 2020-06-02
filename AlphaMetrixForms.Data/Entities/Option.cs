using AlphaMetrixForms.Data.Entities.Parent;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Data.Entities
{
    public class Option
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public OptionQuestion Question { get; set; }

        public string Text { get; set; }
    }
}
