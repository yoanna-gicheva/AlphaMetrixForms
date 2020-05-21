﻿using AlphaMetrixForms.Web.Models.Enums;
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
   
        // MAIN
        public QuestionType Type { get; set; }
        public int OrderNumber { get; set; }
        [Required]
        public string Text { get; set; }
        public bool IsRequired { get; set; }


        //OPTION
        public ICollection<string> Options { get; set; }
        public bool IsMultipleAnswerAllowed { get; set; }
        //public ICollection<Option> Options { get; set; }


        // TEXT
        public bool IsLongAnswer { get; set; }


        //DOCUMENT
        public int FileNumberLimit { get; set; }
        public int FileSizeLimit { get; set; }


        //ADDITIONAL
        public bool EditMode { get; set; }

    }
}