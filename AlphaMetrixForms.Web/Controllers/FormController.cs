using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaMetrixForms.Services.Contracts;
using AlphaMetrixForms.Web.Models.Form;
using AlphaMetrixForms.Web.Models.OptionsQuestion;
using AlphaMetrixForms.Web.Models.TextQuestion;
using Microsoft.AspNetCore.Mvc;

namespace AlphaMetrixForms.Web.Controllers
{
    public class FormController : Controller
    {

        public FormController(IFormService formService, ITextQuestionService textQuestionService, IOptionQuestionService optionQuestionService,
            IDocumentQuestionService documentQuestionService)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var model = new FormViewModel();
            return View("CreateFormView", model);
        }

        [HttpPost]
        public IActionResult AddTextQuestion([Bind("Title, Description, TextQuestions, OptionsQuestions")] FormViewModel form)
        {
            form.TextQuestions.Add(new TextQuestionViewModel());
            return PartialView("_TextQuestionsPartialView", form);
        }

        [HttpPost]
        public IActionResult AddOptionsQuestion([Bind("Title, Description, TextQuestions, OptionsQuestions")] FormViewModel form)
        {
            form.OptionsQuestions.Add(new OptionsQuestionViewModel());
            return PartialView("_OptionsQuestionsPartialView", form);
        }
        [HttpPost]
        public IActionResult SubmitForm([Bind("Title, Description, TextQuestions, OptionsQuestions")] FormViewModel form)
        {
            return null;
            //form.OptionsQuestions.Add(new OptionsQuestion());
            //return PartialView("OptionsQuestions", form);
        }
    }
}