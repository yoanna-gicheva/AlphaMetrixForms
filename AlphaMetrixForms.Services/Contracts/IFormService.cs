﻿using AlphaMetrixForms.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Services.Contracts
{
    public interface IFormService
    {
        Task<FormDTO> GetFormAsync(Guid formId);
        Task<FormDTO> UpdateFormAsync(Guid formId, FormDTO formDTO);
        Task<FormDTO> CreateFormAsync(FormDTO formDTO/*, Guid ownerId*/);
        Task<ICollection<FormDTO>> GetAllFormsForUserAsync(Guid ownerId);
        Task<bool> DeleteFormAsync(Guid formId);
    }
}
