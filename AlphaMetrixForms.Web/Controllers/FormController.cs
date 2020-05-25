using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AlphaMetrixForms.Services.Contracts;
using AlphaMetrixForms.Services.DTOs;
using AlphaMetrixForms.Web.AutoMapper;
using AlphaMetrixForms.Web.Models;
using AlphaMetrixForms.Web.Models.Enums;
using AlphaMetrixForms.Web.Models.Form;
using AlphaMetrixForms.Web.Models.Question;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

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
        public async Task<IActionResult> Index()
        {
            var forms = await this._formService.GetAllFormsAsync();
            var formsVM = _mapper.Map<ICollection<FormViewModel>>(forms);

            return View(formsVM);
        }
        [Route("Answer/{formId}")]
        public async Task<IActionResult> DisplayForm(Guid formId)
        {
            var form = await this._formService.GetFormAsync(formId);
            var formVM = _mapper.Map<FormViewModel>(form);

            var textQuestionsVM = _mapper.Map<ICollection<QuestionViewModel>>(form.TextQuestions);
            var optionQuestionsVM = _mapper.Map<ICollection<QuestionViewModel>>(form.OptionQuestions);
            var documentQuestionsVM = _mapper.Map<ICollection<QuestionViewModel>>(form.DocumentQuestions);
            if (textQuestionsVM != null)
            {
                formVM.Questions.AddRange(textQuestionsVM);
            }
            if (optionQuestionsVM != null)
            {
                formVM.Questions.AddRange(optionQuestionsVM);
            }
            if (documentQuestionsVM != null)
            {
                formVM.Questions.AddRange(documentQuestionsVM);
            }

            return View("DisplayFormView", formVM);
        }

        public async Task<IActionResult> ShareForm(Guid formId, string owner, string mails)
        {
            var result = await this._formService.ShareFormAsync(formId,owner,mails);
            return Ok();
        }
        public IActionResult Create()
        {
            var model = new FormViewModel();
            model.Title = "Untitled";
            return View("CreateFormView", model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FormViewModel form)
        {
            FormDTO formDTO = _mapper.Map<FormDTO>(form);
            Guid userId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            FormDTO newForm = await _formService.CreateFormAsync(formDTO, userId);
            Guid formId = newForm.Id;
            if(form.Questions.Where(q=>q.Type.Equals(QuestionType.Text)).Count() > 0)
            {
                var result = await _textQuestionService.CreateTextQuestionAsync(_mapper.Map<ICollection<TextQuestionDTO>>(form.Questions), formId);
                if(!result)
                {
                    throw new ArgumentException();
                }
            }
            if (form.Questions.Where(q => q.Type.Equals(QuestionType.Option)).Count() > 0)
            {
                var result = await _optionQuestionService.CreateOptionQuestionAsync(_mapper.Map<ICollection<OptionQuestionDTO>>(form.Questions), formId);
                if (!result)
                {
                    throw new ArgumentException();
                }
            }
            if(form.Questions.Where(q => q.Type.Equals(QuestionType.Document)).Count() > 0)
            {
                var result = await _documentQuestionService.CreateDocumentQuestionAsync(_mapper.Map<ICollection<DocumentQuestionDTO>>(form.Questions), formId);
                if (!result)
                {
                    throw new ArgumentException();
                }
            }
            return View("SubmissionSuccessfulView");
        }
        public async Task<IActionResult> Update(Guid formId)
        {
            FormDTO form = await _formService.GetFormAsync(formId);
            FormViewModel result = _mapper.Map<FormViewModel>(form);
            result.UpdateMode = true;

            return View("CreateFormView", result);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteQuestion(FormViewModel form)
        {
            if(form.UpdateMode)
            {

            }
            else
            {
                QuestionViewModel question = form.Questions.FirstOrDefault(q => q.OrderNumber == form.Current);
                form.Questions.Remove(question);
            }

            return PartialView("_QuestionPartial", form);
        }
    }
}