using AlphaMetrixForms.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Services.Contracts
{
    public interface IOptionsQuestionService
    {
        Task<OptionQuestionDTO> GetOptionsQuestionAsync(Guid questionId);
        Task<OptionQuestionDTO> UpdateOptionsQuestionAsync(Guid questionId, OptionQuestionDTO questionDTO);
        Task<OptionQuestionDTO> CreateOptionsQuestionAsync(OptionQuestionDTO questionDTO, Guid formId);
        Task<ICollection<OptionQuestionDTO>> GetAllOptionsQuestionsAsync(Guid formId);
        Task<bool> DeleteOptionsQuestionAsync(Guid questionId);
    }
}
