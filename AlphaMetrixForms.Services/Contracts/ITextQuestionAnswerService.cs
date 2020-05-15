using AlphaMetrixForms.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Services.Contracts
{
    public interface ITextQuestionAnswerService
    {
        Task<TextQuestionAnswerDTO> GetTextQuestionAnswerAsync(Guid questionId);
        Task<TextQuestionAnswerDTO> UpdateTextQuestionAnswerAsync(Guid questionId, TextQuestionAnswerDTO textQuestionDTO);
        Task<TextQuestionAnswerDTO> CreateTextQuestionAnswerAsync(TextQuestionAnswerDTO questionDTO, Guid formId);
        Task<ICollection<TextQuestionAnswerDTO>> GetAllTextQuestionsAnswerAsync(Guid formId);
        Task<bool> DeleteTextQuestionAnswerAsync(Guid questionId);
    }
}
