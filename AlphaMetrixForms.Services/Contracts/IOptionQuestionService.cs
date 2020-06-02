using AlphaMetrixForms.Services.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Services.Contracts
{
    public interface IOptionQuestionService
    {
        Task<OptionQuestionDTO> UpdateOptionQuestionAsync(Guid questionId, OptionQuestionDTO questionDTO);
        Task<OptionQuestionDTO> CreateOptionQuestionAsync(OptionQuestionDTO questionDTO, Guid formId);
        Task<bool> CreateOptionQuestionAsync(ICollection<OptionQuestionDTO> questionDTOs, Guid formId);
        Task OptionQuestion_DetectChanges(Guid formId, ICollection<OptionQuestionDTO> questions);

    }
}
