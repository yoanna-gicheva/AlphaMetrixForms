using AlphaMetrixForms.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Services.Contracts
{
    public interface IOptionQuestionService
    {
        Task<OptionQuestionDTO> GetOptionQuestionAsync(Guid questionId);
        Task<OptionQuestionDTO> UpdateOptionQuestionAsync(Guid questionId, OptionQuestionDTO questionDTO);
        Task<OptionQuestionDTO> CreateOptionQuestionAsync(OptionQuestionDTO questionDTO, Guid formId);
        Task<ICollection<OptionQuestionDTO>> GetAllOptionQuestionsAsync(Guid formId);
        Task<bool> DeleteOptionQuestionAsync(Guid questionId);

        Task<bool> AddOptionToOptionQuestionAsync(OptionDTO optionDTO);
        Task<bool> RemoveOptionFromOptionQuestionAsync(OptionDTO optionDTO);
        Task<bool> UpdateOptionForOptionQuestionAsync(OptionDTO optionDTO);

    }
}
