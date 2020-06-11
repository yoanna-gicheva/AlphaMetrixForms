using AlphaMetrixForms.Services.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Services.Contracts
{
    public interface ITextQuestionService
    {
        Task<TextQuestionDTO> UpdateTextQuestionAsync(Guid questionId, TextQuestionDTO textQuestionDTO);
        Task<TextQuestionDTO> CreateTextQuestionAsync(TextQuestionDTO questionDTO, Guid formId);
        Task<bool> CreateTextQuestionAsync(ICollection<TextQuestionDTO> questionDTOs, Guid formId);

        Task TextQuestion_DetectChanges(Guid formId, ICollection<TextQuestionDTO> questions);

        Task CreateTextQuestionAnswerAsync(Guid responseId, Guid questionId, string answer);
    }
}
