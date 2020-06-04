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

    }
}
