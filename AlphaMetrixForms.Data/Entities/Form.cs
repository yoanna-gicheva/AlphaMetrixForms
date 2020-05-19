using AlphaMetrixForms.Data.Entities.Parent;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Data.Entities
{
    public class Form : Entity
    {
        public Form()
        {
            this.TextQuestions = new List<TextQuestion>();
            this.OptionQuestions = new List<OptionQuestion>();
            this.DocumentQuestions = new List<DocumentQuestion>();
            this.Responses = new List<Response>();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid OwnerId { get; set; }
        public User Owner { get; set; }
        public ICollection<TextQuestion> TextQuestions { get; set; }
        public ICollection<OptionQuestion> OptionQuestions { get; set; }
        public ICollection<DocumentQuestion> DocumentQuestions { get; set; }
        public ICollection<Response> Responses { get; set; }
    }
}
