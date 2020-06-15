using AlphaMetrixForms.Services.Contracts;
using AlphaMetrixForms.Services.DTOs;
using AlphaMetrixForms.Web.Models.Enums;
using AlphaMetrixForms.Web.Models.Form;
using AlphaMetrixForms.Web.Models.Response;
using AlphaMetrixForms.Web.Utils.Contracts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Web.Utils
{
    public class Factory : IFactory
    {
        public async Task CreateTextQuestions(FormViewModel form, Guid formId, ITextQuestionService _textQuestionService, IMapper _mapper)
        {
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
        }
        public async Task CreateDocumentQuestions(FormViewModel form, Guid formId, IDocumentQuestionService _documentQuestionService, IMapper _mapper)
        {
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
        }
        public async Task CreateOptionQuestions(FormViewModel form, Guid formId, IOptionQuestionService _optionQuestionService, IMapper _mapper)
        {
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
        }

        public async Task CreateTextQuestionResponse(ResponseViewModel response, Guid responseId, ITextQuestionService _textQuestionService)
        {
            if (response.Questions.Where(q => q.Type.Equals(QuestionType.Text)).Count() > 0)
            {
                var textQuestions = response.Questions
                    .Where(q => q.Type.Equals(QuestionType.Text))
                    .ToList();
                for (int i = 0; i < textQuestions.Count; i++)
                {
                    await _textQuestionService.CreateTextQuestionAnswerAsync(responseId, textQuestions[i].Id, textQuestions[i].TextAnswer);
                }
            }
        }
        public async Task CreateOptionQuestionResponse(ResponseViewModel response, Guid responseId, IOptionQuestionService _optionQuestionService)
        {
            if (response.Questions.Where(q => q.Type.Equals(QuestionType.Option)).Count() > 0)
            {
                var optionQuestions = response.Questions
                    .Where(q => q.Type.Equals(QuestionType.Option))
                    .ToList();
                foreach (var item in optionQuestions)
                {
                    if (item.OptionQuestionAnswerRadio != null)
                    {
                        await _optionQuestionService.CreateOptionQuestionAnswerRadioAsync(responseId, item.Id, item.OptionQuestionAnswerRadio);
                    }
                    else
                    {
                        await _optionQuestionService.CreateOptionQuestionAnswerCheckboxAsync(responseId, item.Id, item.OptionQuestionAnswerCheckbox);
                    }
                }
            }
        }
        public async Task CreateDocumentQuestionResponse(ResponseViewModel response, Guid responseId, IDocumentQuestionService _documentQuestionService)
        {
            if (response.Questions.Where(q => q.Type.Equals(QuestionType.Document)).Count() > 0)
            {
                var documentQuestions = response.Questions
                    .Where(q => q.Type.Equals(QuestionType.Document))
                    .ToList();
                for (int i = 0; i < documentQuestions.Count; i++)
                {
                    await _documentQuestionService.CreateDocumentQuestionAnswerAsync(responseId, documentQuestions[i].Id, documentQuestions[i].DocumentAnswer);
                }
            }
        }
    }
}

