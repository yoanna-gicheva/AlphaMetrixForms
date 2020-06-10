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
    public class ResponseService : IResponseService
    {
        private readonly FormsContext context;
        private readonly ITextQuestionService textQuestionService;
        private readonly IOptionQuestionService optionQuestionService;
        private readonly IDocumentQuestionService documentQuestionService;

        public ResponseService(FormsContext context, ITextQuestionService textQuestionService, IOptionQuestionService optionQuestionService, IDocumentQuestionService documentQuestionService)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.textQuestionService = textQuestionService ?? throw new ArgumentNullException(nameof(textQuestionService));
            this.optionQuestionService = optionQuestionService ?? throw new ArgumentNullException(nameof(optionQuestionService));
            this.documentQuestionService = documentQuestionService ?? throw new ArgumentNullException(nameof(documentQuestionService));
        }

        public async Task<Guid> CreateResponseAsync(Guid formId)
        {
            Form form = await this.context.Forms
               .FirstOrDefaultAsync(f => f.Id == formId && f.IsClosed == false);

            if (form == null)
            {
                throw new ArgumentException($"Form with id {formId} does not exist.");
            }

            Response response = new Response()
            {
                FormId = formId,
                CreatedOn = DateTime.UtcNow
            };

            await this.context.Responses.AddAsync(response);
            await this.context.SaveChangesAsync();

            await SendNotificationToUserAsync(form, response.Id);
            return response.Id;
        }

        public async Task<FormDTO> RetrieveResponseForFormAsync(Guid formId)
        {
            Form form = await this.context.Forms
                .Include(f => f.Owner)
                .Include(f => f.Responses).ThenInclude(r=>r.TextQuestionAnswers)
                .Include(f => f.Responses).ThenInclude(r=>r.OptionQuestionAnswers)
                .Include(f => f.Responses).ThenInclude(r=>r.DocumentQuestionAnswers)
                .FirstOrDefaultAsync(f => f.Id == formId);

            return form.GetDto();
        }
        public async Task<FormDTO> RetrieveResponseAsync(Guid responseId, Guid formId)
        {
            Form form = await this.context.Forms
                .Include(f => f.Owner)
                .Include(f => f.TextQuestions)
                .Include(f => f.OptionQuestions).ThenInclude(o=>o.Options)
                .Include(f => f.DocumentQuestions)
                .FirstOrDefaultAsync(f => f.Id == formId && f.IsDeleted == false);

            this.context.Entry(form)
                .Collection(f => f.Responses)
                .Query()
                .Where(r => r.Id == responseId)
                .Include(r => r.TextQuestionAnswers)
                .Include(r => r.DocumentQuestionAnswers)
                .Include(r => r.OptionQuestionAnswers)
                .Load();

            return form.GetDto();
        }
        private async Task<bool> SendNotificationToUserAsync(Form form, Guid responseId)
        {
            string userEmail = await UserEmailAsync(form.OwnerId);
            bool sent = await EmailNotificationAsync(userEmail, form.Id, responseId);
            return sent;
        }
        private async Task<string> UserEmailAsync(Guid ownerId)
        {
            User owner = await context.Users.FirstOrDefaultAsync(u => u.Id == ownerId);
            if(owner == null)
            {
                return null;
            }
            return owner.Email;
        }
        private async Task<bool> EmailNotificationAsync(string mail, Guid formId, Guid responseId)
        {
            Email email = new Email();

            email.Subject = "An answer to your form has been submitted!";
            email.Greeting = $"Dear Sir/Madam,\r\nHere is the answer:\r\n";
            email.Content = $"https://localhost:44366/RetrieveResponse/{responseId}?formId={formId}";
            email.Closing = "\r\nKind regards,\r\nAlphaMetrix Team";

            MailMessage message = new MailMessage();
            message.To.Add(mail);
            message.Subject = email.Subject;
            message.Body = email.Greeting + email.Content + email.Closing;
            message.From = new MailAddress("alphametrixforms@gmail.com");
            message.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("alphametrixforms@gmail.com", "yoanna13");
            smtp.Send(message);

            return true;
        }

    }
}
