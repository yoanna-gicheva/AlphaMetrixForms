using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Services.Contracts
{
    public interface IResponseService
    {
        Task<Guid> CreateResponseAsync(Guid formId);
    }
}
