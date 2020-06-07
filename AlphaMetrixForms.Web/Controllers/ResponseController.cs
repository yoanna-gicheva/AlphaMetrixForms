using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AlphaMetrixForms.Services.Contracts;
using AlphaMetrixForms.Services.DTOs;
using AlphaMetrixForms.Web.Models.Enums;
using AlphaMetrixForms.Web.Models.Form;
using AlphaMetrixForms.Web.Models.Question;
using AlphaMetrixForms.Web.Models.Response;
using AlphaMetrixForms.Web.Models.User;
using AlphaMetrixForms.Web.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlphaMetrixForms.Web.Controllers
{
    public class ResponseController : Controller
    {
        private readonly IFormService _formService;
        private readonly ITextQuestionService _textQuestionService;
        private readonly IOptionQuestionService _optionQuestionService;
        private readonly IDocumentQuestionService _documentQuestionService;
        private readonly IResponseService _responseService;
        private readonly IMapper _mapper;


        public ResponseController(IFormService formService, ITextQuestionService textQuestionService, IOptionQuestionService optionQuestionService,
            IDocumentQuestionService documentQuestionService, IResponseService responseService, IMapper mapper)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _textQuestionService = textQuestionService ?? throw new ArgumentNullException(nameof(textQuestionService));
            _optionQuestionService = optionQuestionService ?? throw new ArgumentNullException(nameof(optionQuestionService));
            _documentQuestionService = documentQuestionService ?? throw new ArgumentNullException(nameof(documentQuestionService));
            _responseService = responseService ?? throw new ArgumentNullException(nameof(responseService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpPost]
        public async Task<IActionResult> SubmitResponse(ResponseViewModel response)
        {
            string _errorMessage = Validator.ResponseValidation_Message(response);
            if (_errorMessage != null)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return Json(new { success = false, responseText = _errorMessage });
            }
            var responseGuid = await _responseService.CreateResponseAsync(response.FormId);

            if (response.Questions.Where(q => q.Type.Equals(QuestionType.Text)).Count() > 0)
            {
                var textQuestions = response.Questions
                    .Where(q => q.Type.Equals(QuestionType.Text))
                    .ToList();
                for (int i = 0; i < textQuestions.Count; i++)
                {
                    await _textQuestionService.CreateTextQuestionAnswerAsync(responseGuid, textQuestions[i].Id, textQuestions[i].TextAnswer);
                }
            }
            if (response.Questions.Where(q => q.Type.Equals(QuestionType.Option)).Count() > 0)
            {
                var optionQuestions = response.Questions
                    .Where(q => q.Type.Equals(QuestionType.Option))
                    .ToList();
                foreach (var item in optionQuestions)
                {
                    if (item.OptionQuestionAnswerRadio!=null)
                    {
                        await _optionQuestionService.CreateOptionQuestionAnswerRadioAsync(responseGuid, item.Id, item.OptionQuestionAnswerRadio);
                    }
                    else
                    {
                        await _optionQuestionService.CreateOptionQuestionAnswerCheckboxAsync(responseGuid, item.Id, item.OptionQuestionAnswerCheckbox);
                    }
                }
            }
            if (response.Questions.Where(q => q.Type.Equals(QuestionType.Document)).Count() > 0)
            {
                var documentQuestions = response.Questions
                    .Where(q => q.Type.Equals(QuestionType.Document))
                    .ToList();
                for (int i = 0; i < documentQuestions.Count; i++)
                {
                    await _documentQuestionService.CreateDocumentQuestionAnswerAsync(responseGuid, documentQuestions[i].Id, documentQuestions[i].DocumentAnswer);
                }
            }
            return Ok();
        }
        public async Task<IActionResult> ViewAnswers(Guid id)
        {
            return null;
        }

        [Route("Response/{formId}")]
        public async Task<IActionResult> DisplayForm(Guid formId)
        {
            var form = await this._formService.GetFormAsync(formId);
            if(form == null)
            {
                return NotFound();
            }
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
                foreach (var question in optionQuestionsVM)
                {
                    foreach(var option in question.Options)
                    {
                        question.OptionQuestionAnswerCheckbox.Add(false);
                    }
                    question.Type = Models.Enums.QuestionType.Option;
                }
                formVM.Questions.AddRange(optionQuestionsVM);
            }
            if (documentQuestionsVM != null)
            {
                foreach (var question in documentQuestionsVM)
                {
                    question.Type = Models.Enums.QuestionType.Document;
                }
                formVM.Questions.AddRange(documentQuestionsVM);
            }

            ResponseViewModel response = new ResponseViewModel();
            response.FormId = formVM.Id;
            response.Title = formVM.Title;
            response.Description = formVM.Description;
            response.Questions = formVM.Questions.OrderBy(q=>q.OrderNumber).ToList();

            return View("DisplayFormView", response);
        }

        [Route("Answer/{formId}")]
        public async Task<IActionResult> RetrieveResponse()
        {
            var Id = Guid.Parse("8A50AB5F-0EB5-4EAA-916E-DC241A19A3ED");
            var responseId = Guid.Parse("9AB530C5-2EE3-40C9-1E9C-08D807EF3156");
            var VAR = await _responseService.RetrieveResponseAsync(responseId, Id);
            var vm = _mapper.Map<FormViewModel>(VAR);
            var textQuestionsVM = _mapper.Map<ICollection<QuestionViewModel>>(VAR.TextQuestions);

            var optionQuestionsVM = _mapper.Map<ICollection<QuestionViewModel>>(VAR.OptionQuestions);
            var documentQuestionsVM = _mapper.Map<ICollection<QuestionViewModel>>(VAR.DocumentQuestions);

            if (textQuestionsVM != null)
            {
                vm.Questions.AddRange(textQuestionsVM);
            }

            return View("DisplayFormView", VAR);
        }
    }
}
