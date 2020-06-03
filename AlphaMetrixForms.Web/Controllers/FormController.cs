﻿using System;
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
using AlphaMetrixForms.Web.Utils;
using AlphaMetrixForms.Web.Models.Response;

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
        public async Task<IActionResult> Index(int? pageNumber)
        {
            var forms = await this._formService.GetAllFormsAsync();
            var formsVM = _mapper.Map<IEnumerable<FormViewModel>>(forms);

            int pageSize = 9;
            return View("Index", PaginatedList<FormViewModel>.CreateAsync(formsVM.OrderBy(f=>f.CreatedOn), pageNumber ?? 1, pageSize));
        }
        

        [HttpPost]
        public async Task<IActionResult> Share(EmailProvider emailList)
        {
            var result = await this._formService.ShareFormAsync(emailList.Emails, emailList.FormId);
            return Ok();
        }

        [Authorize]
        public IActionResult Create()
        {
            var model = new FormViewModel();
            //model.Title = "Untitled";
            return View("ModifyFormView", model);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(FormViewModel form)
        {
            string _errorMessage = Validator.ModifyModelValidation_Message(form);
            if (_errorMessage != null)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return Json(new { success = false, responseText = _errorMessage });
            }

            FormDTO formDTO = _mapper.Map<FormDTO>(form);
            Guid userId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));

            FormDTO newForm = await _formService.CreateFormAsync(formDTO, userId);
            Guid formId = newForm.Id;

            if (form.Questions.Where(q => q.Type.Equals(QuestionType.Text)).Count() > 0)
            {
                var textQuestions = form.Questions
                    .Where(q => q.Type.Equals(QuestionType.Text))
                    .ToList();
                var textQuestionsDTOs = _mapper.Map<ICollection<TextQuestionDTO>>(textQuestions);
                var result = await _textQuestionService.CreateTextQuestionAsync(textQuestionsDTOs, formId);
                if (!result)
                {
                    throw new ArgumentException();
                }
            }
            if (form.Questions.Where(q => q.Type.Equals(QuestionType.Option)).Count() > 0)
            {
                var optionQuestions = form.Questions
                    .Where(q => q.Type.Equals(QuestionType.Option))
                    .ToList();
                var optionQuestionsDTOs = _mapper.Map<ICollection<OptionQuestionDTO>>(optionQuestions);
                var result = await _optionQuestionService.CreateOptionQuestionAsync(optionQuestionsDTOs, formId);
                if (!result)
                {
                    throw new ArgumentException();
                }
            }
            if (form.Questions.Where(q => q.Type.Equals(QuestionType.Document)).Count() > 0)
            {
                var documentQuestions = form.Questions
                    .Where(q => q.Type.Equals(QuestionType.Document))
                    .ToList();
                var documentQuestionsDTOs = _mapper.Map<ICollection<DocumentQuestionDTO>>(documentQuestions);
                var result = await _documentQuestionService.CreateDocumentQuestionAsync(documentQuestionsDTOs, formId);
                if (!result)
                {
                    throw new ArgumentException();
                }
            }
            return Ok();
        }

        
        [Authorize]
        public async Task<IActionResult> Edit(Guid id)
        {
            
            FormDTO form = await _formService.GetFormAsync(id);
            FormViewModel result = ViewModel_Generator(form);
            result.EditMode = true;
            Questions_SetEditMode(result.Questions);
            result.Questions = result.Questions.OrderBy(q => q.OrderNumber).ToList();

            return View("ModifyFormView", result);
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
            string _errorMessage = Validator.ModifyModelValidation_Message(form);
            if (_errorMessage != null)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return Json(new { success = false, responseText = _errorMessage });
            }
            if (!form.EditMode)
            {
                throw new ArgumentException("Edit mode mistaken!");
            }
            FormDTO formDTO = DataTransferObject_Generator(form);
            FormDTO updated = await _formService.UpdateFormAsync(form.Id, formDTO);
            FormViewModel result = ViewModel_Generator(updated);
            Questions_SetEditMode(result.Questions);
            result.EditMode = true;

            if (updated == null)
            {
                throw new ArgumentException();
            }

            return View("ModifyFormView", result);
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
            result.Questions.AddRange(_mapper.Map<ICollection<QuestionViewModel>>(formDTO.OptionQuestions));
            QuestionType_Set(result.Questions, QuestionType.Option);
            result.Questions.AddRange(_mapper.Map<ICollection<QuestionViewModel>>(formDTO.DocumentQuestions));
            QuestionType_Set(result.Questions, QuestionType.Document);
            result.Questions.AddRange(_mapper.Map<ICollection<QuestionViewModel>>(formDTO.TextQuestions));

            return result;
        }
        private void QuestionType_Set(ICollection<QuestionViewModel> questions, QuestionType type)
        {
            foreach(var question in questions)
            {
                if(question.Type == QuestionType.Text)
                {
                    question.Type = type;
                }
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _formService.DeleteFormAsync(id);
            return Ok();
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

        [HttpPost]
        public IActionResult FormPreview(FormViewModel form)
        {
            foreach(var question in form.Questions)
            {
                question.PreviewMode = true;
            }
            
            return PartialView("_QuestionPartial", form);
        }
    }
}