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
        public async Task<IActionResult> CreateOptionQuestion(FormViewModel form)
        {
            QuestionViewModel model = new QuestionViewModel();
            model.OrderNumber = form.Questions.Count;
            model.Type = QuestionType.Option;
            form.Questions.Add(model);


            OptionViewModel option1 = new OptionViewModel();
            model.Options.Add(option1);
            OptionViewModel option2 = new OptionViewModel();
            //string option2 = "option2";
            model.Options.Add(option2);

            return PartialView("_QuestionPartial", form);

        }

        [HttpPost]
        public async Task<IActionResult> CreateOption(FormViewModel form)
        {
            int orderNum = form.Current;
            QuestionViewModel question = form.Questions.FirstOrDefault(q => q.OrderNumber == orderNum);
            //OptionViewModel option = new OptionViewModel();

            //string option = "option";
            OptionViewModel option = new OptionViewModel();


            question.Options.Add(option);

            return PartialView("_QuestionPartial", form);
        }
        [HttpPost]
        [Route("/OptionQuestion/DeleteOption/{option}")]
        public async Task<IActionResult> DeleteOption(FormViewModel form, int option)
        {
            int orderNum = form.Current;
            QuestionViewModel question = form.Questions.FirstOrDefault(q => q.OrderNumber == orderNum);
            question.Options.RemoveAt(option);

            return PartialView("_QuestionPartial", form);

        }
    }
}
