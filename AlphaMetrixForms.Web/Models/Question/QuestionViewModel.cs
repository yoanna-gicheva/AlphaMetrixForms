using AlphaMetrixForms.Web.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Web.Models.Question
{
    //[Bind("Type, OrderNumber")]
    public class QuestionViewModel
    {
        bool EditMode { get; set; }
        public QuestionType Type { get; set; }
        public int OrderNumber { get; set; }
        [Required]
        public string Text { get; set; }


        //OPTION
        public ICollection<string> Options { get; set; }

    }
}
