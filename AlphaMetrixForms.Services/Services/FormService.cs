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

        public FormService(FormsContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            textQuestionService = new TextQuestionService(context);
            optionQuestionService = new OptionQuestionService(context);
            documentQuestionService = new DocumentQuestionService(context);
        }

        public async Task<FormDTO> CreateFormAsync(FormDTO formDTO, Guid ownerId)
        {
            //User owner = await this.context.Users
            //    .Include(u => u.Forms)
            //    .FirstOrDefaultAsync(u => u.Id == formDTO.OwnerId/*ownerId*/);

            //not sure if we need to check if the form is deleted.
            //I suppose we won't allow creating one with the same title even if it is deleted.
            //bool check = owner.Forms
            //    .Any(f => f.Title == formDTO.Title && f.IsDeleted == false);

            //if(check)
            //{
            //    throw new ArgumentException($"This user has already created a form with Title: {formDTO.Title}");
            //}

            Form form = new Form()
            {
                Title = formDTO.Title,
                Description = formDTO.Description,
                CreatedOn = DateTime.UtcNow,
                //OwnerId = formDTO.OwnerId,
                OwnerId = ownerId
            };
            form.ModifiedOn = form.CreatedOn;

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
            List<Form> forms = await this.context.Forms
                .Where(f => f.OwnerId == ownerId && f.IsDeleted == false)
                .ToListAsync();

            return forms.GetDtos();
        }

        public async Task<ICollection<FormDTO>> GetAllFormsAsync()
        {
            List<Form> forms = await this.context.Forms
                .Include(f=>f.Owner)
                .Where(f => f.IsDeleted == false)
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
                throw new ArgumentNullException($"There is no such Form with ID: {formId}");
            }

            return form.GetDto();
        }

        public async Task<FormDTO> UpdateFormAsync(Guid formId, FormDTO formDTO, IMapper mapper)
        {
            Form form = await this.context.Forms
                .FirstOrDefaultAsync(f => f.Id == formDTO.Id && f.IsDeleted == false);

            if(form == null)
            {
                throw new ArgumentNullException($"There is no such form with ID: {formDTO.Id}");
            }
            form.Title = formDTO.Title;
            form.Description = formDTO.Description;
            form.ModifiedOn = DateTime.UtcNow;

            await TextQuestion_DetectChanges(formId, formDTO.TextQuestions, mapper);
            await OptionQuestion_DetectChanges(formId, formDTO.OptionQuestions, mapper);
            await DocumentQuestion_DetectChanges(formId, formDTO.DocumentQuestions, mapper);


            await context.SaveChangesAsync();

            return formDTO;
        }
        private async Task TextQuestion_DetectChanges(Guid formId, ICollection<TextQuestionDTO> questions, IMapper mapper)
        {
            foreach(var question in questions)
            {
                if(context.TextQuestions.Any(q=>q.Id == question.Id))
                {
                    await textQuestionService.UpdateTextQuestionAsync(question.Id, question);
                }
                else
                {
                    await textQuestionService.CreateTextQuestionAsync(question, formId);
                }
            }

        }
        private async Task OptionQuestion_DetectChanges(Guid formId, ICollection<OptionQuestionDTO> questions, IMapper mapper)
        {
            foreach (var question in questions)
            {
                if (context.OptionQuestions.Any(q => q.Id == question.Id))
                {
                    await optionQuestionService.UpdateOptionQuestionAsync(question.Id, question);
                }
                else
                {
                    await optionQuestionService.CreateOptionQuestionAsync(question, formId);
                }
            }
        }
        private async Task DocumentQuestion_DetectChanges(Guid formId, ICollection<DocumentQuestionDTO> questions, IMapper mapper)
        {
            foreach (var question in questions)
            {
                if (context.DocumentQuestions.Any(q => q.Id == question.Id))
                {
                    await documentQuestionService.UpdateDocumentQuestionAsync(question.Id, question);
                }
                else
                {
                    await documentQuestionService.CreateDocumentQuestionAsync(question, formId);
                }
            }
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
