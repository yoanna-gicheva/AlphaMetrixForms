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
        Task<FormDTO> GetFormAsync(Guid formId);
        Task<FormDTO> UpdateFormAsync(Guid formId, FormDTO formDTO, IMapper mapper);
        Task<FormDTO> CreateFormAsync(FormDTO formDTO, Guid ownerId);
        Task<ICollection<FormDTO>> GetAllFormsForUserAsync(Guid ownerId);

        Task<ICollection<FormDTO>> GetAllFormsAsync();
        Task<bool> DeleteFormAsync(Guid formId);

        Task<bool> ShareFormAsync(Guid formId, string owner, string mails);
    }
}
