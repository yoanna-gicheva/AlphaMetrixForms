﻿using AlphaMetrixForms.Web.Models.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Web.Models.Response
{
    public class ResponseViewModel
    {
        public ResponseViewModel()
        {
            Questions = new List<QuestionViewModel>();
        }
        public Guid Id { get; set; }
        public Guid FormId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<QuestionViewModel> Questions { get; set; }
    }
}
