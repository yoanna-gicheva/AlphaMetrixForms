using AlphaMetrixForms.Web.Models.Enums;
using AlphaMetrixForms.Web.Models.Form;
using AlphaMetrixForms.Web.Models.Question;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Web.Controllers
{
    public class OptionQuestionController : Controller
    {

        [HttpPost]
        public IActionResult CreateOptionQuestion(FormViewModel form)
        {
            QuestionViewModel model = new QuestionViewModel();
            model.OrderNumber = form.Current;
            model.Type = QuestionType.Option;
            form.Questions.Add(model);

            string option1 = "option1";
            model.Options.Add(option1);
            string option2 = "option2";
            model.Options.Add(option2);

            return PartialView("_QuestionPartial", form);

        }

        [HttpPost]
        public IActionResult CreateOption(FormViewModel form)
        {
            int orderNum = form.Current;
            QuestionViewModel question = form.Questions.FirstOrDefault(q => q.OrderNumber == orderNum);
            //OptionViewModel option = new OptionViewModel();

            string option = "option";
            question.Options.Add(option);

            return PartialView("_QuestionPartial", form);
        }
    }
}
