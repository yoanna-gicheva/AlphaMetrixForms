using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AlphaMetrixForms.Web.Models.Question;
using System.Threading.Tasks;
using AlphaMetrixForms.Web.Models.Response;

namespace AlphaMetrixForms.Web.Models.Form
{
    public class FormViewModel
    {
        public FormViewModel()
        {
            Questions = new List<QuestionViewModel>();
        }

        public Guid Id { get; set; }
        public int Current { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public List<QuestionViewModel> Questions { get; set; }
        public ICollection<ResponseViewModel> Responses { get; set; }
        public bool EditMode { get; set; }
    }
}
