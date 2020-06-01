using AlphaMetrixForms.Data.Entities.Parent;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Data.Entities
{
    public class OptionQuestion
    {

        public Guid Id { get; set; }

        public Guid FormId { get; set; }

        public Form Form { get; set; }

        public string Text { get; set; }

        public bool IsRequired { get; set; }
        public bool IsMultipleAnswerAllowed { get; set; }

        public int OrderNumber { get; set; }

        public ICollection<Option> Options { get; set; }

        public ICollection<OptionQuestionAnswer> Answers { get; set; }
    }
}
