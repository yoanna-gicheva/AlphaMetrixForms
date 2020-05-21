using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AlphaMetrixForms.Services.Contracts;
using AlphaMetrixForms.Services.DTOs;
using AlphaMetrixForms.Web.AutoMapper;
using AlphaMetrixForms.Web.Models.Form;
using AlphaMetrixForms.Web.Models.OptionsQuestion;
using AlphaMetrixForms.Web.Models.TextQuestion;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlphaMetrixForms.Web.Controllers
{
    public class FormController : Controller
    {
        private readonly IFormService _formService;
        private readonly ITextQuestionService _textQuestionService;
        private readonly IOptionQuestionService _optionQuestionService;
        private readonly IDocumentQuestionService _documentQuestionService;
        private readonly IMapper _mapper;


        public FormController(IFormService formService, ITextQuestionService textQuestionService, IOptionQuestionService optionQuestionService,
            IDocumentQuestionService documentQuestionService, IMapper mapper)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _textQuestionService = textQuestionService ?? throw new ArgumentNullException(nameof(textQuestionService));
            _optionQuestionService = optionQuestionService ?? throw new ArgumentNullException(nameof(optionQuestionService));
            _documentQuestionService = documentQuestionService ?? throw new ArgumentNullException(nameof(documentQuestionService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

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
        public IActionResult AddTextQuestion([Bind("Current, Title, Description, TextQuestions, OptionQuestions")] FormViewModel form)
        {
            TextQuestionViewModel model = new TextQuestionViewModel();
            model.OrderNumber = form.Current;
            form.TextQuestions.Add(model);

            form.Questions.Add(model);
            return PartialView("_QuestionPartial", form);
        }

        [HttpPost]
        public IActionResult AddOptionsQuestion([Bind("Current, Title, Description, TextQuestions, OptionQuestions")] FormViewModel form)
        {
            OptionsQuestionViewModel model = new OptionsQuestionViewModel();
            model.OrderNumber = form.Current;
            form.OptionQuestions.Add(model);
            form.Questions.Add(model);

            return PartialView("_QuestionPartial", form);
        }
        [HttpPost]
        public async Task<IActionResult> SubmitForm([Bind("Title, Description, TextQuestions, OptionsQuestions")] FormViewModel form)
        {
            FormDTO formDTO = _mapper.Map<FormDTO>(form);
            Guid userId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            FormDTO newForm = await _formService.CreateFormAsync(formDTO, userId);
            Guid formId = newForm.Id;
            if(form.TextQuestions.Count > 0)
            {
                var result = await _textQuestionService.CreateTextQuestionAsync(_mapper.Map<ICollection<TextQuestionDTO>>(form.TextQuestions), formId);
                if(!result)
                {
                    throw new ArgumentException();
                }
            }
            if (form.OptionQuestions.Count > 0)
            {
                var result = await _optionQuestionService.CreateOptionQuestionAsync(_mapper.Map<ICollection<OptionQuestionDTO>>(form.OptionQuestions), formId);
                if (!result)
                {
                    throw new ArgumentException();
                }
            }
            if (form.DocumentQuestions.Count > 0)
            {
                var result = await _documentQuestionService.CreateDocumentQuestionAsync(_mapper.Map<ICollection<DocumentQuestionDTO>>(form.DocumentQuestions), formId);
                if (!result)
                {
                    throw new ArgumentException();
                }
            }
            return View("SubmissionSuccessfulView");
        }
    }
}