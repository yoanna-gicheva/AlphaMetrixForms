﻿using AlphaMetrixForms.Web.Models.DocumentQuestion;
using AlphaMetrixForms.Web.Models.OptionsQuestion;
using AlphaMetrixForms.Web.Models.TextQuestion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Web.Models.Form
{
    public class FormViewModel
    {
        public FormViewModel()
        {
            TextQuestions = new List<TextQuestionViewModel>();
            OptionQuestions = new List<OptionsQuestionViewModel>();
            DocumentQuestions = new List<DocumentQuestionViewModel>();
        }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public List<TextQuestionViewModel> TextQuestions { get; set; }
        public List<OptionsQuestionViewModel> OptionQuestions { get; set; }
        public List<DocumentQuestionViewModel> DocumentQuestions { get; set; }

        public int NumberOfTextQuestions
        {
            get => TextQuestions.Count;
        }
        public int NumberOfOptionsQuestions
        {
            get => OptionQuestions.Count;
        }

    }
}
