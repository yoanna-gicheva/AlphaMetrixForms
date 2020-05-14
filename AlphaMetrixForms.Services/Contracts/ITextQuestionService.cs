using AlphaMetrixForms.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Services.Contracts
{
    public interface ITextQuestionService
    {
        Task<TextQuestionDTO> GetTextQuestionAsync(Guid questionId);
        Task<TextQuestionDTO> UpdateTextQuestionAsync(Guid questionId, TextQuestionDTO textQuestionDTO);
        Task<TextQuestionDTO> CreateTextQuestionAsync(TextQuestionDTO questionDTO, Guid formId);
        Task<ICollection<TextQuestionDTO>> GetAllTextQuestionsAsync(Guid formId);
        Task<bool> DeleteTextQuestionAsync(Guid questionId);
    }
}
