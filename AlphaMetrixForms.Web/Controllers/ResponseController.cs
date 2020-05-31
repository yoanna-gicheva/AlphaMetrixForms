using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AlphaMetrixForms.Services.Contracts;
using AlphaMetrixForms.Services.DTOs;
using AlphaMetrixForms.Web.Models.Form;
using AlphaMetrixForms.Web.Models.Question;
using AlphaMetrixForms.Web.Models.Response;
using AlphaMetrixForms.Web.Models.User;
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
        private readonly IMapper _mapper;


        public ResponseController(IFormService formService, ITextQuestionService textQuestionService, IOptionQuestionService optionQuestionService,
            IDocumentQuestionService documentQuestionService, IMapper mapper)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _textQuestionService = textQuestionService ?? throw new ArgumentNullException(nameof(textQuestionService));
            _optionQuestionService = optionQuestionService ?? throw new ArgumentNullException(nameof(optionQuestionService));
            _documentQuestionService = documentQuestionService ?? throw new ArgumentNullException(nameof(documentQuestionService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpPost]
        public async Task<IActionResult> SubmitResponse(ResponseViewModel response)
        {
            throw new NotImplementedException();

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
            response.Questions = formVM.Questions;

            return View("DisplayFormView", response);
        }
    }
}
