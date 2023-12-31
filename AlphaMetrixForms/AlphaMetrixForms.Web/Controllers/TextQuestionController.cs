﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaMetrixForms.Web.Models.Enums;
using AlphaMetrixForms.Web.Models.Form;
using AlphaMetrixForms.Web.Models.Question;
using Microsoft.AspNetCore.Mvc;

namespace AlphaMetrixForms.Web.Controllers
{
    public class TextQuestionController : Controller
    {

        [HttpPost]
        public IActionResult CreateTextQuestion(FormViewModel form)
        {
            QuestionViewModel model = new QuestionViewModel();
            model.OrderNumber = form.Questions.Count;
            model.Type = QuestionType.Text;
            form.Questions.Add(model);

            return PartialView("_QuestionPartial", form);
        }
    }
}