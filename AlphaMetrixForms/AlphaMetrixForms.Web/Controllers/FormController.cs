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
using AlphaMetrixForms.Web.Utils;
using AlphaMetrixForms.Web.Models.Response;
using System.Text;
using AlphaMetrixForms.Web.Utils.Contracts;

namespace AlphaMetrixForms.Web.Controllers
{
    [Authorize]
    public class FormController : Controller
    {
        private readonly IFormService _formService;
        private readonly ITextQuestionService _textQuestionService;
        private readonly IOptionQuestionService _optionQuestionService;
        private readonly IDocumentQuestionService _documentQuestionService;
        private readonly IFactory _factory;
        private readonly IMapper _mapper;

        public FormController(IFormService formService, ITextQuestionService textQuestionService, IOptionQuestionService optionQuestionService,
            IDocumentQuestionService documentQuestionService, IMapper mapper, IFactory factory)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _textQuestionService = textQuestionService ?? throw new ArgumentNullException(nameof(textQuestionService));
            _optionQuestionService = optionQuestionService ?? throw new ArgumentNullException(nameof(optionQuestionService));
            _documentQuestionService = documentQuestionService ?? throw new ArgumentNullException(nameof(documentQuestionService));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index(int? pageNumber)
        {
            var forms = await this._formService.GetAllFormsAsync();
            var formsVM = _mapper.Map<IEnumerable<FormViewModel>>(forms);

            int pageSize = 9;
            return View("Index", PaginatedList<FormViewModel>.CreateAsync(formsVM.OrderByDescending(f=>f.CreatedOn), pageNumber ?? 1, pageSize));
        }
        
        [HttpPost]
        public async Task<IActionResult> Share(EmailProvider emailList)
        {
            var result = await _formService.ShareFormAsync(emailList.Emails, emailList.FormId);
            if(result)
            {
                return Ok();
            }
            return BadRequest();
        }

        public IActionResult Create()
        {
            var model = new FormViewModel();
            return View("ModifyFormView", model);
        }


        [HttpPost]
        public async Task<IActionResult> Create(FormViewModel form)
        {
            string _errorMessage = Validator.ModifyModelValidation_Message(form);
            if (_errorMessage != null)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return Json(new { success = false, responseText = _errorMessage });
            }

            FormDTO formDTO = _mapper.Map<FormDTO>(form);
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            FormDTO newForm = await _formService.CreateFormAsync(formDTO, userId);
            Guid formId = newForm.Id;

            await _factory.CreateTextQuestions(form, formId, _textQuestionService, _mapper);
            await _factory.CreateOptionQuestions(form, formId, _optionQuestionService, _mapper);
            await _factory.CreateDocumentQuestions(form, formId, _documentQuestionService, _mapper);

            return Ok();
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            
            FormDTO form = await _formService.GetFormAsync(id);
            FormViewModel result = ModelGenerator.ViewModel_Generator(form, _mapper);
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
            FormDTO formDTO = ModelGenerator.DataTransferObject_Generator(form, _mapper);
            FormDTO updated = await _formService.UpdateFormAsync(form.Id, formDTO);
            FormViewModel result = ModelGenerator.ViewModel_Generator(updated, _mapper);
            Questions_SetEditMode(result.Questions);
            result.EditMode = true;

            if (updated == null)
            {
                throw new ArgumentException();
            }

            return View("ModifyFormView", result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _formService.DeleteFormAsync(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteQuestion(FormViewModel form)
        {
            QuestionViewModel question = form.Questions.FirstOrDefault(q => q.OrderNumber == form.Current);
            form.Questions.Remove(question);

            for (int i = 0; i < form.Questions.Count; i++)
            {
                form.Questions[i].OrderNumber = i;
            }

            return PartialView("_QuestionPartial", form);
        }

        public async Task<IActionResult> SearchForms (string title, int? pageNumber)
        {
            if(title != null)
            {
                var forms = await _formService.SearchForms(title);
                var formsVM = _mapper.Map<IEnumerable<FormViewModel>>(forms);

                int pageSize = 9;
                return View("Index", PaginatedList<FormViewModel>.CreateAsync(formsVM.OrderByDescending(f => f.CreatedOn), pageNumber ?? 1, pageSize));
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult FormPreview(FormViewModel form)
        {
         
            foreach(var question in form.Questions)
            {
                question.PreviewMode = true;
                question.EditMode = false;
            }

            return PartialView("_PreviewFormPartial", form);
        }
    }
}
