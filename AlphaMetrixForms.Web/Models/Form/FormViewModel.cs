using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AlphaMetrixForms.Web.Models.Question;
using System.Threading.Tasks;

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
        [Required( ErrorMessage = "Title is required.")]
        [MaxLength(150, ErrorMessage = "Title length cannot consist of more than 150 symbols.")]
        public string Title { get; set; }
        public string Description { get; set; }
        public List<QuestionViewModel> Questions { get; set; }

       
    }
}
