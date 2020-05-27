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
using Microsoft.AspNetCore.Authorization;

namespace AlphaMetrixForms.Web.Controllers
{
    //[Authorize]
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
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var forms = await this._formService.GetAllFormsAsync();
            var formsVM = _mapper.Map<ICollection<FormViewModel>>(forms);

            return View(formsVM);
        }
        [Route("Answer/{formId}")]
        [AllowAnonymous]
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
        [AllowAnonymous]
        public async Task<IActionResult> ShareForm(Guid formId, string owner, string mails)
        {
            var result = await this._formService.ShareFormAsync(formId, owner, mails);
            return Ok();
        }

        [Authorize]
        public IActionResult Create()
        {
            var model = new FormViewModel();
            model.Title = "Untitled";
            return View("CreateFormView", model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(FormViewModel form)
        {
            FormDTO formDTO = _mapper.Map<FormDTO>(form);
            Guid userId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            FormDTO newForm = await _formService.CreateFormAsync(formDTO, userId);
            Guid formId = newForm.Id;
            if (form.Questions.Where(q => q.Type.Equals(QuestionType.Text)).Count() > 0)
            {
                var textQuestions = form.Questions.Where(q => q.Type.Equals(QuestionType.Text)).ToList();
                var result = await _textQuestionService.CreateTextQuestionAsync(_mapper.Map<ICollection<TextQuestionDTO>>(textQuestions), formId);
                if (!result)
                {
                    throw new ArgumentException();
                }
            }
            if (form.Questions.Where(q => q.Type.Equals(QuestionType.Option)).Count() > 0)
            {
                var optionQuestions = form.Questions.Where(q => q.Type.Equals(QuestionType.Option)).ToList();
                var result = await _optionQuestionService.CreateOptionQuestionAsync(_mapper.Map<ICollection<OptionQuestionDTO>>(optionQuestions), formId);
                if (!result)
                {
                    throw new ArgumentException();
                }
            }
            if (form.Questions.Where(q => q.Type.Equals(QuestionType.Document)).Count() > 0)
            {
                var documentQuestions = form.Questions.Where(q => q.Type.Equals(QuestionType.Document)).ToList();
                var result = await _documentQuestionService.CreateDocumentQuestionAsync(_mapper.Map<ICollection<DocumentQuestionDTO>>(documentQuestions), formId);
                if (!result)
                {
                    throw new ArgumentException();
                }
            }
            return View("SubmissionSuccessfulView");
        }
        [Authorize]
        public async Task<IActionResult> Edit(Guid id)
        {
            FormDTO form = await _formService.GetFormAsync(id);
            FormViewModel result = ViewModel_Generator(form);
            result.EditMode = true;
            Questions_SetEditMode(result.Questions);


            return View("CreateFormView", result);
        }
        private void Questions_SetEditMode(ICollection<QuestionViewModel> questions)
        {
            foreach(var question in questions)
            {
                question.EditMode = true;
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SaveChanges(FormViewModel form)
        {
            FormDTO formDTO = DataTransferObject_Generator(form);
            FormDTO updated = await _formService.UpdateFormAsync(form.Id, formDTO, _mapper);
            FormViewModel result = ViewModel_Generator(updated);
            Questions_SetEditMode(result.Questions);
            result.EditMode = true;

            if (updated == null)
            {
                throw new ArgumentException();
            }

            return View("CreateFormView", result);
        }
        private FormDTO DataTransferObject_Generator(FormViewModel form)
        {
            FormDTO formDTO = _mapper.Map<FormDTO>(form);
            formDTO.TextQuestions = _mapper.Map<ICollection<TextQuestionDTO>>(form.Questions.Where(q => q.Type == QuestionType.Text));
            formDTO.OptionQuestions = _mapper.Map<ICollection<OptionQuestionDTO>>(form.Questions.Where(q => q.Type == QuestionType.Option));
            formDTO.DocumentQuestions = _mapper.Map<ICollection<DocumentQuestionDTO>>(form.Questions.Where(q => q.Type == QuestionType.Document));

            return formDTO;
        }
        private FormViewModel ViewModel_Generator(FormDTO formDTO)
        {
            FormViewModel result = _mapper.Map<FormViewModel>(formDTO);
            result.Questions.AddRange(_mapper.Map<ICollection<QuestionViewModel>>(formDTO.TextQuestions));
            result.Questions.AddRange(_mapper.Map<ICollection<QuestionViewModel>>(formDTO.OptionQuestions));
            result.Questions.AddRange(_mapper.Map<ICollection<QuestionViewModel>>(formDTO.DocumentQuestions));

            return result;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteQuestion(FormViewModel form)
        {
            QuestionViewModel question = form.Questions.FirstOrDefault(q => q.OrderNumber == form.Current);
            form.Questions.Remove(question);
            FormViewModel newForm = new FormViewModel();
            newForm.Title = form.Title;
            newForm.Description = form.Description;
            newForm.EditMode = form.EditMode;
            newForm.Questions = form.Questions;

            return PartialView("_QuestionPartial", newForm);
        }
    }
}