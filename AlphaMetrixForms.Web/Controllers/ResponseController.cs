﻿using System;
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
        [Route("RetrieveResponse/{responseId}")]
        public async Task<IActionResult> RetrieveResponse(Guid responseId, Guid formId)
        {
            var formDTO = await _responseService.RetrieveResponseAsync(responseId, formId);
            var vm = new ResponseDisplayModel();
            vm.Title = formDTO.Title;
            vm.Description = formDTO.Description;
            foreach (var textQuestion in formDTO.TextQuestions)
            {
                var vm2 = new AnswerViewModel();
                vm2.Text = textQuestion.Text;
                vm2.OrderNumber = textQuestion.OrderNumber;
                vm2.Id = textQuestion.Id;
                vm2.Type = QuestionType.Text;
                foreach (var response in formDTO.Responses)
                {
                    foreach (var textQuestionAnswer in response.TextQuestionAnswers)
                    {
                        if (vm2.Id==textQuestionAnswer.TextQuestionId)
                        {
                            vm2.Answer=textQuestionAnswer.Answer;
                        }
                    }
                }
                vm.Answers.Add(vm2);
            }
            foreach (var documentQuestion in formDTO.DocumentQuestions)
            {
                var vm2 = new AnswerViewModel();
                vm2.Text = documentQuestion.Text;
                vm2.OrderNumber = documentQuestion.OrderNumber;
                vm2.Id = documentQuestion.Id;
                vm2.Type = QuestionType.Document;
                vm.Answers.Add(vm2);
                foreach (var response in formDTO.Responses)
                {
                    foreach (var documentQuestionAnswer in response.DocumentQuestionAnswers)
                    {
                        if (vm2.Id == documentQuestionAnswer.DocumentQuestionId)
                        {
                            vm2.Answers.Add(documentQuestionAnswer.Answer);
                        }
                    }
                }
            }
            foreach (var optionQuestion in formDTO.OptionQuestions)
            {
                var vm2 = new AnswerViewModel();
                vm2.Text = optionQuestion.Text;
                vm2.OrderNumber = optionQuestion.OrderNumber;
                vm2.Id = optionQuestion.Id;
                vm2.Type = QuestionType.Option;
                vm.Answers.Add(vm2);
                foreach (var response in formDTO.Responses)
                {
                    foreach (var optionQuestionAnswer in response.OptionQuestionAnswers)
                    {
                        if (vm2.Id == optionQuestionAnswer.OptionQuestionId)
                        {
                            vm2.Answers.Add(optionQuestionAnswer.Answer);
                        }
                    }
                }
            }

            return View("DisplayResponseView", vm);
        }
    }
}
