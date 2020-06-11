using AlphaMetrixForms.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Services.Contracts
{
    public interface IResponseService
    {
        Task<Guid> CreateResponseAsync(Guid formId);

        Task<FormDTO> RetrieveResponseAsync(Guid responseId, Guid formId);

        Task<FormDTO> RetrieveResponseForFormAsync(Guid formId);

    }
}
