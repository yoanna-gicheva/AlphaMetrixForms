using AlphaMetrixForms.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Services.Contracts
{
    public interface ITextQuestionService
    {
        Task<TextQuestionDTO> GetTextQuestionAsync(int questionId);
        Task<TextQuestionDTO> UpdateTextQuestionAsync(int questionId, string newText);
        Task<TextQuestionDTO> CreateTextQuestionAsync(TextQuestionDTO questionDTO);

        //Task<ICollection<TextQuestionDTO>> GetAllTextQuestionsAsync();
        Task<bool> DeleteTextQuestionAsync(int questionId);
    }
}
