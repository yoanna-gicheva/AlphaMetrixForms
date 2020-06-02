using AlphaMetrixForms.Data.Context;
using AlphaMetrixForms.Data.Entities;
using AlphaMetrixForms.Services.Contracts;
using AlphaMetrixForms.Services.DTOmappers;
using AlphaMetrixForms.Services.DTOs;
using AlphaMetrixForms.Services.Providers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Services.Services
{
    public class FormService : IFormService
    {
        private readonly FormsContext context;
        private readonly ITextQuestionService textQuestionService;
        private readonly IOptionQuestionService optionQuestionService;
        private readonly IDocumentQuestionService documentQuestionService;

        public FormService(FormsContext context, ITextQuestionService textQuestionService, IOptionQuestionService optionQuestionService, IDocumentQuestionService documentQuestionService)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.textQuestionService = textQuestionService ?? throw new ArgumentNullException(nameof(textQuestionService));
            this.optionQuestionService = optionQuestionService ?? throw new ArgumentNullException(nameof(optionQuestionService));
            this.documentQuestionService = documentQuestionService ?? throw new ArgumentNullException(nameof(documentQuestionService));
        }

        public async Task<FormDTO> CreateFormAsync(FormDTO formDTO, Guid ownerId)
        {
            User owner = await this.context.Users
               .FirstOrDefaultAsync(u => u.Id == ownerId);

            if (owner==null)
            {
                throw new ArgumentException($"User with id {ownerId} does not exist.");
            }
            if (formDTO.Title==null)
            {
                throw new ArgumentException($"Form title cannot be null.");
            }

            Form form = new Form()
            {
                Title = formDTO.Title,
                Description = formDTO.Description,
                CreatedOn = DateTime.UtcNow,
                ModifiedOn = DateTime.UtcNow,
                OwnerId = ownerId
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

        //Not used anywhere yet
        //
        //public async Task<ICollection<FormDTO>> GetAllFormsForUserAsync(Guid ownerId)
        //{
        //    List<Form> forms = await this.context.Forms
        //        .Where(f => f.OwnerId == ownerId && f.IsDeleted == false)
        //        .ToListAsync();

        //    return forms.GetDtos();
        //}

        public async Task<ICollection<FormDTO>> GetAllFormsAsync()
        {
            List<Form> forms = await this.context.Forms
                .Include(f=>f.Owner)
                .Include(f => f.Responses).ThenInclude(r => r.TextQuestionAnswers)
                .Include(f => f.Responses).ThenInclude(r => r.DocumentQuestionAnswers)
                .Include(f => f.Responses).ThenInclude(r => r.OptionQuestionAnswers)
                .Where(f => f.IsDeleted == false && f.IsClosed == false)
                .ToListAsync();

            return forms.GetDtos();
        }

        public async Task<FormDTO> GetFormAsync(Guid formId)
        {
            Form form = await this.context.Forms
                .Include(f => f.Owner)
                .Include(f =>f.TextQuestions)
                .Include(f =>f.DocumentQuestions)
                .Include(f =>f.OptionQuestions)
                .ThenInclude(q => q.Options)
                .FirstOrDefaultAsync(f => f.Id == formId && f.IsDeleted == false);

            if (form == null)
            {
                return null;
            }

            return form.GetDto();
        }

        public async Task<FormDTO> UpdateFormAsync(Guid formId, FormDTO formDTO)
        {
            Form form = await this.context.Forms
                .FirstOrDefaultAsync(f => f.Id == formDTO.Id && f.IsDeleted == false);

            if(form == null)
            {
                throw new ArgumentException($"Form with ID: {formId} does not exist.");
            }

            form.Title = formDTO.Title;
            form.Description = formDTO.Description;
            form.ModifiedOn = DateTime.UtcNow;

            await textQuestionService.TextQuestion_DetectChanges(formId, formDTO.TextQuestions);
            await optionQuestionService.OptionQuestion_DetectChanges(formId, formDTO.OptionQuestions);
            await documentQuestionService.DocumentQuestion_DetectChanges(formId, formDTO.DocumentQuestions);

            await context.SaveChangesAsync();

            return formDTO;
        }

        public async Task<bool> ShareFormAsync (Guid formId, string owner, string mails)
        {
            Email email = new Email();
            //mails should be converted here
            email.To = mails;

            email.Subject = "You were invited to complete a form!";
            email.Greeting = $"Dear Received,\r\nYou were invited by {owner} to fill the following form:\r\n";
            email.Link = $"https://localhost:44366/Answer/{formId}";
            email.Closing = "\r\nKind regards,\r\nAlphaMetrix Team";

            MailMessage message = new MailMessage();
            message.To.Add(email.To);
            message.Subject = email.Subject;
            message.Body = email.Greeting+email.Link+email.Closing;
            message.From = new MailAddress("alphametrixforms@gmail.com");
            message.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("alphametrixforms@gmail.com", "passwordShouldBeHere");
            smtp.Send(message);

            return true;
        }
    }
}
