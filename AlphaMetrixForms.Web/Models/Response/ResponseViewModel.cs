using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Web.Models.Response
{
    public class ResponseViewModel
    {
        public Guid Id { get; set; }

        public Guid FormId { get; set; }

        public string Form { get; set; }

        //public ICollection<TextQuestionAnswerDTO> TextQuestionAnswers { get; set; }
        //public ICollection<OptionQuestionAnswerDTO> OptionQuestionAnswers { get; set; }
        //public ICollection<DocumentQuestionAnswerDTO> DocumentQuestionAnswers { get; set; }
    }
}
