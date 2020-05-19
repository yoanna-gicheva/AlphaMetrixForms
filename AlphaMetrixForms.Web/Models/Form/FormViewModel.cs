using AlphaMetrixForms.Web.Models.OptionsQuestion;
using AlphaMetrixForms.Web.Models.TextQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Web.Models.Form
{
    public class FormViewModel
    {
        public FormViewModel()
        {
            TextQuestions = new List<TextQuestionViewModel>();
            OptionsQuestions = new List<OptionsQuestionViewModel>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<TextQuestionViewModel> TextQuestions { get; set; }
        public List<OptionsQuestionViewModel> OptionsQuestions { get; set; }
        public int NumberOfTextQuestions
        {
            get => TextQuestions.Count;
        }
        public int NumberOfOptionsQuestions
        {
            get => OptionsQuestions.Count;
        }

    }
}
