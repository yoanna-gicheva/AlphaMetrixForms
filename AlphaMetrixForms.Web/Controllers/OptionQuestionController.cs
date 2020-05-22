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
        public IActionResult AddOption(FormViewModel form)
        {
            int orderNum = form.Current;
            QuestionViewModel question = form.Questions.FirstOrDefault(q => q.OrderNumber == orderNum);
            OptionViewModel option = new OptionViewModel();

            //string option = string.Empty;
            question.Options.Add(option);

            return View("CreateFormView", form);
        }
    }
}
