using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Web.Models.Response
{
    public class ResponseDisplayModel
    {
        public ResponseDisplayModel()
        {
            Answers = new List<AnswerViewModel>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<AnswerViewModel> Answers { get; set; }
    }
}
