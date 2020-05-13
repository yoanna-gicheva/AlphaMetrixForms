using AlphaMetrixForms.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Services.Contracts
{
    public interface IFormService
    {
        Task<FormDTO> GetFormAsync(int formId);
        Task<FormDTO> UpdateFormAsync(int formId, string newTitle, string newDescription);
        Task<FormDTO> CreateFormAsync(FormDTO formDTO);
        Task<ICollection<FormDTO>> GetAllFormsForUserAsync(int userId);
        Task<bool> DeleteFormAsync(int formId);
    }
}
