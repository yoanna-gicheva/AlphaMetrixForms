using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Data.Entities
{
    public class Response
    {
        public Guid Id { get; set; }

        public Guid FormId { get; set; }

        public Form Form { get; set; }

        public ICollection<TextQuestionAnswer> TextQuestionAnswers {get;set;}
        public ICollection<OptionQuestionAnswer> OptionQuestionAnswers {get;set;}
        public ICollection<DocumentQuestionAnswer> DocumentQuestionAnswers {get;set;}
    }
}
