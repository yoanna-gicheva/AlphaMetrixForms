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
using AlphaMetrixForms.Web.Utils.Contracts;
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
        private readonly IFactory _factory;
        private readonly IModelGenerator _modelGenerator;
        private readonly IMapper _mapper;


        public ResponseController(IFormService formService, ITextQuestionService textQuestionService, IOptionQuestionService optionQuestionService,
            IDocumentQuestionService documentQuestionService, IResponseService responseService, IMapper mapper, IFactory factory, IModelGenerator modelGenerator)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _textQuestionService = textQuestionService ?? throw new ArgumentNullException(nameof(textQuestionService));
            _optionQuestionService = optionQuestionService ?? throw new ArgumentNullException(nameof(optionQuestionService));
            _documentQuestionService = documentQuestionService ?? throw new ArgumentNullException(nameof(documentQuestionService));
            _responseService = responseService ?? throw new ArgumentNullException(nameof(responseService));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _modelGenerator = modelGenerator ?? throw new ArgumentNullException(nameof(factory));
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
            var responseId = await _responseService.CreateResponseAsync(response.FormId);

            await _factory.CreateTextQuestionResponse(response, responseId, _textQuestionService);
            await _factory.CreateOptionQuestionResponse(response, responseId, _optionQuestionService);
            await _factory.CreateDocumentQuestionResponse(response, responseId, _documentQuestionService);
            return Ok();
        }

        [Route("ViewAnswers/{formId}")]
        public async Task<IActionResult> ViewAnswers(Guid formId)
        {
            var result = await this._responseService.RetrieveResponseForFormAsync(formId);
            var vm = _mapper.Map<FormViewModel>(result);
            return View("ViewAnswersView",vm);
        }

        [Route("Response/{formId}")]
        public async Task<IActionResult> DisplayForm(Guid formId)
        {
            var form = await this._formService.GetFormAsync(formId);
            var formVM = _mapper.Map<FormViewModel>(form);

            var textQuestionsVM = _mapper.Map<ICollection<QuestionViewModel>>(form.TextQuestions);
            var optionQuestionsVM = _mapper.Map<ICollection<QuestionViewModel>>(form.OptionQuestions);
            var documentQuestionsVM = _mapper.Map<ICollection<QuestionViewModel>>(form.DocumentQuestions);

            SetQuestionType(QuestionType.Text, formVM, textQuestionsVM);
            SetQuestionType(QuestionType.Option, formVM, optionQuestionsVM);
            SetQuestionType(QuestionType.Document, formVM, documentQuestionsVM);

            ResponseViewModel response = new ResponseViewModel();
            response.FormId = formVM.Id;
            response.Title = formVM.Title;
            response.Description = formVM.Description;
            response.Questions = formVM.Questions.OrderBy(q=>q.OrderNumber).ToList();

            return View("DisplayFormView", response);
        }
        private void SetQuestionType(QuestionType type, FormViewModel formVM, ICollection<QuestionViewModel> questions)
        {
            if (questions != null)
            {
                foreach (var question in questions)
                {
                    if(type == QuestionType.Option)
                    {
                        for (int i = 0; i < question.Options.Count; i++)
                        {
                            question.OptionQuestionAnswerCheckbox.Add(false);
                        }
                    }
                    question.Type = type;
                }
                formVM.Questions.AddRange(questions);
            }
        }

        [Route("RetrieveResponse/{responseId}")]
        public async Task<IActionResult> RetrieveResponse(Guid responseId, Guid formId)
        {
            var formDTO = await _responseService.RetrieveResponseAsync(responseId, formId);
            var vm = new ResponseDisplayModel();
            vm.Title = formDTO.Title;
            vm.Description = formDTO.Description;
            _modelGenerator.Response_TextRelationship(formDTO, vm);
            _modelGenerator.Response_OptionRelationship(formDTO, vm);
            _modelGenerator.Response_DocumentRelationship(formDTO, vm);

            return View("DisplayResponseView", vm);
        }
    }
}
