using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaMetrixForms.Web.Models.Form;
using AlphaMetrixForms.Web.Models.OptionsQuestion;
using AlphaMetrixForms.Web.Models.TextQuestion;
using Microsoft.AspNetCore.Mvc;

namespace AlphaMetrixForms.Web.Controllers
{
    public class FormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            var model = new FormViewModel();
            return View("CreateFormView", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddTextQuestion([Bind("Title, Description, TextQuestions, OptionsQuestions")] FormViewModel form)
        {
            form.TextQuestions.Add(new TextQuestionViewModel());
            return PartialView("_TextQuestionsPartialView", form);
        }

        [HttpPost]
        public async Task<IActionResult> AddOptionsQuestion([Bind("Title, Description, TextQuestions, OptionsQuestions")] FormViewModel form)
        {
            form.OptionsQuestions.Add(new OptionsQuestionViewModel());
            return PartialView("_OptionsQuestionsPartialView", form);
        }
        [HttpPost]
        public async Task<IActionResult> SubmitForm([Bind("Title, Description, TextQuestions, OptionsQuestions")] FormViewModel form)
        {
            return null;
            //form.OptionsQuestions.Add(new OptionsQuestion());
            //return PartialView("OptionsQuestions", form);
        }



    }
}