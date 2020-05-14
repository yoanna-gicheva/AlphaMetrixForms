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

namespace AlphaMetrixForms.Services.Services
{
    public class FormService : IFormService
    {
        private readonly FormsContext context;
        public FormService(FormsContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<FormDTO> CreateFormAsync(FormDTO formDTO/*, Guid ownerId*/)
        {
            User owner = await this.context.Users
                .Include(u => u.Forms)
                .FirstOrDefaultAsync(u => u.Id == formDTO.OwnerId/*ownerId*/);

            //not sure if we need to check if the form is deleted.
            //I suppose we won't allow creating one with the same title even if it is deleted.
            bool check = owner.Forms
                .Any(f => f.Title == formDTO.Title /*&& f.IsDeleted == false*/);
            
            if(check)
            {
                throw new ArgumentException($"This user has already created a form with Title: {formDTO.Title}");
            }

            Form form = new Form() 
            {
                Title = formDTO.Title,
                Description = formDTO.Description,
                CreatedOn = DateTime.UtcNow,
                OwnerId = formDTO.OwnerId,
                //OwnerId = ownerId
            };

            await this.context.Forms.AddAsync(form);
            await this.context.SaveChangesAsync();

            formDTO.Id = form.Id;
            return formDTO;
        }

        public async Task<bool> DeleteFormAsync(Guid formId)
        {
            Form form = await this.context.Forms
                .FirstOrDefaultAsync(f => f.Id == formId && f.IsDeleted == false);

            if(form == null)
            {
                return false;
            }

            form.IsDeleted = true;
            form.DeletedOn = DateTime.UtcNow;
            await this.context.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<FormDTO>> GetAllFormsForUserAsync(Guid ownerId)
        {
            //User owner = await context.Users
            //    .FirstOrDefaultAsync(u => u.Id == ownerId && u.IsDeleted == false);
            //var forms = owner.Forms;

            List<Form> forms = await this.context.Forms
                .Where(f => f.OwnerId == ownerId && f.IsDeleted == false)
                .ToListAsync();

            //return FormMapper.GetDtos(forms);
            return forms.GetDtos();
        }

        public async Task<FormDTO> GetFormAsync(Guid formId)
        {
            //added few includes for types of questions which may come in use later
            Form form = await this.context.Forms
                .Include(f =>f.TextQuestions)
                .Include(f =>f.DocumentQuestions)
                .Include(f =>f.OptionQuestions)
                .ThenInclude(q => q.Options)
                .FirstOrDefaultAsync(f => f.Id == formId && f.IsDeleted == false);

            if (form == null)
            {
                throw new ArgumentNullException($"There is no such Form with ID: {formId}");
            }

            //return FormMapper.GetDto(form);
            return form.GetDto();
        }

        public async Task<FormDTO> UpdateFormAsync(Guid formId, FormDTO formDTO)
        {
            Form form = await this.context.Forms
                .FirstOrDefaultAsync(f => f.Id == formDTO.Id && f.IsDeleted == false);

            if(form == null)
            {
                throw new ArgumentNullException($"There is no such form with ID: {formDTO.Id}");
            }
            //I am not sure what is the idea of the below rows. 
            //I was thinking that this method should allow us to change the title or description of the form only.

            //form = FormMapper.GetEntity(formDTO);
            //form.TextQuestions = TextQuestionMapper.GetEntities(formDTO.TextQuestions);
            //form.OptionQuestions = OptionQuestionMapper.GetEntities(formDTO.OptionQuestions);
            //form.DocumentQuestions = DocumentQuestionMapper.GetEntities(formDTO.DocumentQuestions);
            //form.Responses = ResponseMapper.GetEntities(formDTO.Responses);

            form.Title = formDTO.Title;
            form.Description = formDTO.Description;
            form.ModifiedOn = DateTime.UtcNow;

            await this.context.SaveChangesAsync();

            return formDTO;
        }
    }
}
