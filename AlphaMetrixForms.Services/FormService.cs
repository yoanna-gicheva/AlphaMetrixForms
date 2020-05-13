using AlphaMetrixForms.Data.Context;
using AlphaMetrixForms.Services.Contracts;
using AlphaMetrixForms.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Services
{
    public class FormService : IFormService
    {
        private readonly FormsContext context;
        public FormService(FormsContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Task<FormDTO> CreateFormAsync(FormDTO formDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFormAsync(int formId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<FormDTO>> GetAllFormsForUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<FormDTO> GetFormAsync(int formId)
        {
            throw new NotImplementedException();
        }

        public Task<FormDTO> UpdateFormAsync(int formId, string newTitle, string newDescription)
        {
            throw new NotImplementedException();
        }
    }
}
