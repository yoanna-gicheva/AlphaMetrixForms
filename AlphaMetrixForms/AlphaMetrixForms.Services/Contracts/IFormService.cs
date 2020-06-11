using AlphaMetrixForms.Services.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Services.Contracts
{
    public interface IFormService
    {
        Task<FormDTO> CreateFormAsync(FormDTO formDTO, Guid ownerId);

        Task<bool> DeleteFormAsync(Guid formId);

        Task<ICollection<FormDTO>> GetAllFormsAsync();

        Task<FormDTO> GetFormAsync(Guid formId);

        Task<bool> ShareFormAsync(ICollection<string> mails, Guid formId);

        Task<FormDTO> UpdateFormAsync(Guid formId, FormDTO formDTO);

        Task<ICollection<FormDTO>> SearchForms(string title);
        //Task<ICollection<FormDTO>> GetAllFormsForUserAsync(Guid ownerId);

    }
}
