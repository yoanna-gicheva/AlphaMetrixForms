using AlphaMetrixForms.Services.Contracts;
using AlphaMetrixForms.Web.Models.Form;
using AlphaMetrixForms.Web.Models.Response;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Web.Utils.Contracts
{
    public interface IFactory
    {
        Task CreateTextQuestions(FormViewModel form, Guid formId, ITextQuestionService _textQuestionService, IMapper _mapper);
        Task CreateDocumentQuestions(FormViewModel form, Guid formId, IDocumentQuestionService _documentQuestionService, IMapper _mapper);
        Task CreateOptionQuestions(FormViewModel form, Guid formId, IOptionQuestionService _optionQuestionService, IMapper _mapper);
        Task CreateTextQuestionResponse(ResponseViewModel response, Guid responseId, ITextQuestionService _textQuestionService);
        Task CreateOptionQuestionResponse(ResponseViewModel response, Guid responseId, IOptionQuestionService _optionQuestionService);
        Task CreateDocumentQuestionResponse(ResponseViewModel response, Guid responseId, IDocumentQuestionService _documentQuestionService);
    }
}
