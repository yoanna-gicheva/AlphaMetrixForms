using AlphaMetrixForms.Data.Context;
using AlphaMetrixForms.Data.Entities;
using AlphaMetrixForms.Services.Contracts;
using AlphaMetrixForms.Services.DTOmappers;
using AlphaMetrixForms.Services.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<FormDTO> CreateFormAsync(FormDTO formDTO, Guid ownerId)
        {
            User owner = await context.Users.Include(u => u.Forms).FirstOrDefaultAsync(u => u.Id == ownerId);
            bool check = owner.Forms.Any(f => f.Title == formDTO.Title && f.IsDeleted == false);
            
            if(check)
            {
                throw new ArgumentException($"This user has already created a form with Title: {formDTO.Title}");
            }

            Form form = FormMapper.GetEntity(formDTO);
            form.OwnerId = ownerId;
            await context.Forms.AddAsync(form);
            await context.SaveChangesAsync();

            formDTO.Id = form.Id;
            return formDTO;
        }

        public async Task<bool> DeleteFormAsync(Guid formId)
        {
            Form form = await context.Forms.FirstOrDefaultAsync(f => f.Id == formId && f.IsDeleted == false);

            if(form == null)
            {
                return false;
            }

            form.IsDeleted = true;
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<FormDTO>> GetAllFormsForUserAsync(Guid ownerId)
        {
            User owner = await context.Users.FirstOrDefaultAsync(u => u.Id == ownerId && u.IsDeleted == false);
            var forms = owner.Forms;

            return FormMapper.GetDtos(forms);
        }

        public async Task<FormDTO> GetFormAsync(Guid formId)
        {
            Form form = await context.Forms.FirstOrDefaultAsync(f => f.Id == formId && f.IsDeleted == false);
            return FormMapper.GetDto(form);
        }

        public async Task<FormDTO> UpdateFormAsync(Guid formId, FormDTO formDTO)
        {
            Form form = context.Forms.FirstOrDefaultAsync(f => f.Id == formId && f.IsDeleted == false).Result;

            if(form == null)
            {
                throw new ArgumentNullException($"There is no such form with ID: {formId}");
            }

            form = FormMapper.GetEntity(formDTO);
            form.TextQuestions = TextQuestionMapper.GetEntities(formDTO.TextQuestions);
            form.OptionQuestions = OptionQuestionMapper.GetEntities(formDTO.OptionQuestions);
            form.DocumentQuestions = DocumentQuestionMapper.GetEntities(formDTO.DocumentQuestions);
            form.Responses = ResponseMapper.GetEntities(formDTO.Responses);
            await context.SaveChangesAsync();

            return formDTO;
        }
    }
}
