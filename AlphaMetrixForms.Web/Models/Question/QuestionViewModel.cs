using AlphaMetrixForms.Web.Models.Enums;
using AlphaMetrixForms.Web.Utils.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Web.Models.Question
{
    public class QuestionViewModel
    {
        public QuestionViewModel()
        {
            DocumentAnswer = new FormFileCollection();
            Options = new List<OptionViewModel>();
            OptionQuestionAnswerCheckbox = new List<bool>();
        }

        // MAIN
        public Guid Id { get; set; }
        public QuestionType Type { get; set; }
        public int OrderNumber { get; set; }
        [Required(ErrorMessage = "Question text is required.")]
        public string Text { get; set; }
        public bool IsRequired { get; set; }


        //OPTION
        public bool IsMultipleAnswerAllowed { get; set; }
        public List<OptionViewModel> Options { get; set; }
        public int ToRemove { get; set; }

        // TEXT
        public bool IsLongAnswer { get; set; }


        //DOCUMENT
        public int FileNumberLimit { get; set; }
        public int FileSizeLimit { get; set; }


        //ADDITIONAL
        public bool EditMode { get; set; }

        public string TextAnswer{get;set;}

        //[MinimumElements(2)]
        [MinimumElements(ErrorMessage = "At least a person is required")]
        public IFormFileCollection DocumentAnswer { get; set; }

        [Required]
        public List<bool> OptionQuestionAnswerCheckbox { get; set; }
        [Required]
        public string OptionQuestionAnswerRadio { get; set; }

    }
}
